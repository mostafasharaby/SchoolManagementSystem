using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;
        public RegisterHandler(UserManager<AppUser> userManager, IMapper mapper, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return _responseHandler.BadRequest<string>("Email is already in use.");
            }

            var user = _mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            return _responseHandler.Success(user.Id, "User registered successfully.");
        }
    }
}
