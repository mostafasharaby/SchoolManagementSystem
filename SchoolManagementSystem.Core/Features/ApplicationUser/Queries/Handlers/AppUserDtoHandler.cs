using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Models;
using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Results;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Handlers
{
    internal class AppUserDtoHandler : IRequestHandler<AppUserDtoCommamd, Response<AppUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public readonly ResponseHandler _responseHandler;
        public AppUserDtoHandler(UserManager<AppUser> userManager, IMapper mapper, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<Response<AppUserDto>> Handle(AppUserDtoCommamd request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return _responseHandler.Unauthorized<AppUserDto>();
            }

            var userDto = _mapper.Map<AppUserDto>(user);
            return _responseHandler.Success(userDto);
        }
    }
}
