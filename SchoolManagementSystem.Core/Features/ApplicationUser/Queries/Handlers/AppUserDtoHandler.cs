using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Models;
using SchoolManagementSystem.Core.Wrapper;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Handlers
{
    internal class AppUserDtoHandler : IRequestHandler<AppUserDtoCommamd, Response<AppUserDto>>,
                                       IRequestHandler<GetUsersDtoCommand, PaginatedResult<AppUserDto>>


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

        public async Task<PaginatedResult<AppUserDto>> Handle(GetUsersDtoCommand request, CancellationToken cancellationToken)
        {
            var allUsers = _userManager.Users.AsQueryable();
            // _mapper.Map<AppUserDto>(allUsers) is incorrect because allUsers is an IQueryable<AppUser>, but Map<T>() expects a single object or a collection (like List<T>).            
            // i can use _mapper.Map<List<AppUserDto>>(allUsers.ToList()) and it will work but Instead of first retrieving data into memory and then mapping it, we can let AutoMapper handle the transformation within the database query itself.
            // another reason for using  ProjectTo<AppUserDto instead of Map<List<AppUserDto>> is that ToPaginatedListAsync takes IQuarable as a source 
            // for remainding that ToPaginatedListAsync is an exention method so any IQuarable cam call it 
            var paginatedResult = _mapper.ProjectTo<AppUserDto>(allUsers).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return await paginatedResult;
        }




    }
}
