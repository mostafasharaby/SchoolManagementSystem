using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Claims.Commands.Models;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Services.Abstracts;
using System.Security.Claims;

namespace SchoolManagementSystem.Core.Features.Claims.Commands.Handler
{
    public class UserClaimsHandler : IRequestHandler<UpdateUserClaimsCommand, Response<string>>,
                                           IRequestHandler<AddUserClaimCommand, Response<string>>,
                                           IRequestHandler<DeleteUserClaimCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IClaimService _claimService;
        private readonly ResponseHandler _responseHandler;

        public UserClaimsHandler(UserManager<AppUser> userManager, IClaimService claimService, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _claimService = claimService;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.BadRequest<string>("User not found");

            if (request.Claim == null)
                return _responseHandler.BadRequest<string>("Claim cannot be null");

            var existingClaim = await _claimService.ClaimTypeExistsAsync(user, request.Claim.Type);

            if (existingClaim == null)
                return _responseHandler.BadRequest<string>($"Claim '{request.Claim.Type}' not found.");

            var removeResult = await _userManager.RemoveClaimAsync(user, existingClaim);
            if (!removeResult.Succeeded)
                return _responseHandler.BadRequest<string>($"Failed to remove old claim '{request.Claim.Type}'.");


            var addResult = await _userManager.AddClaimAsync(user, new Claim(request.Claim.Type, request.Claim.Value));
            if (!addResult.Succeeded)
                return _responseHandler.BadRequest<string>($"Failed to add new claim '{request.Claim.Type}'.");

            return _responseHandler.Success("Claim updated successfully.");
        }


        public async Task<Response<string>> Handle(AddUserClaimCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.BadRequest<string>("User not found");

            if (request.Claim == null)
                return _responseHandler.BadRequest<string>("Claim cannot be null");

            var result = await _claimService.AddOnlyClaimAsync(user, request.Claim);
            if (!result)
                return _responseHandler.BadRequest<string>("Failed to add claim");

            return _responseHandler.Success("Claim added successfully");

        }

        public async Task<Response<string>> Handle(DeleteUserClaimCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return _responseHandler.NotFound<string>("User not found");

            if (request.Claim == null)
                return _responseHandler.BadRequest<string>("Claim cannot be null");


            var existingClaim = await _claimService.ClaimTypeExistsAsync(user, request.Claim.Type);
            if (existingClaim == null)
                return _responseHandler.BadRequest<string>($"Claim type '{request.Claim.Type}' does not exist for this user.");


            var result = await _claimService.DeleteClaimAsync(user, request.Claim);
            if (!result)
                return _responseHandler.BadRequest<string>("Failed to delete claim");

            return _responseHandler.Success("Claim deleted successfully");
        }
    }
}
