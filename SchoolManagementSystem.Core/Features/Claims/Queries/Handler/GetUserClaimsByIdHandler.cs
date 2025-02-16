using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Claims.Queries.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Data.Views;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Claims.Queries.Handler
{
    internal class GetUserClaimsByIdHandler : IRequestHandler<GetUserClaimsByIdQuery, Response<UserClaims>>,
                                              IRequestHandler<UserRoleClaimQuery, Response<List<UserRolesClaimsView>>>,
                                              IRequestHandler<GetGroupedUserRoleClaimsQuery, Response<List<UserRoleClaimGroupedDto>>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IClaimService _claimService;
        private readonly ResponseHandler _responseHandler;

        public GetUserClaimsByIdHandler(UserManager<AppUser> userManager, IClaimService claimService, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _claimService = claimService;
            _responseHandler = responseHandler;
        }
        public async Task<Response<UserClaims>> Handle(GetUserClaimsByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.NotFound<UserClaims>("User not found");

            var claimsDetails = await _claimService.GetUserClaimsDetailsAsync(user);

            var userClaims = new UserClaims
            {
                UserId = request.UserId,
                ClaimsDetails = claimsDetails
            };
            return _responseHandler.Success(userClaims, "User claims retrieved successfully");
        }
        public async Task<Response<List<UserRolesClaimsView>>> Handle(UserRoleClaimQuery request, CancellationToken cancellationToken)
        {
            var roleClaims = await _claimService.GetUserClaimsDetailsAsync();
            return _responseHandler.Success(roleClaims);
        }
        public async Task<Response<List<UserRoleClaimGroupedDto>>> Handle(GetGroupedUserRoleClaimsQuery request, CancellationToken cancellationToken)
        {
            var roleClaims = await _claimService.GetGroupedUserClaimsAsync();

            return _responseHandler.Success(roleClaims);
        }
    }

}
