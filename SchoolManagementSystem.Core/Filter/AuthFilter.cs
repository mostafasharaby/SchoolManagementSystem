using AngularApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolManagementSystem.Data.Entities.Identity;
using System.Net;

namespace SchoolManagementSystem.Core.Filter
{
    public class AuthFilter : IAsyncActionFilter
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public AuthFilter(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated ?? false;

            if (isAuthenticated)
            {
                var user = await _userService.GetCurrentUserAsync();

                if (user != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    if (userRoles.All(role => role.Contains("student")))
                    {
                        context.Result = new ObjectResult(new
                        {
                            Message = "Access denied. Students are not allowed to access this resource."
                        })
                        {
                            StatusCode = (int)HttpStatusCode.Forbidden
                        };
                        return;
                    }
                }
            }

            await next();
        }
    }
}
