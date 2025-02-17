using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Parents.Queries.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Parents.Queries.Handlers
{
    public class ParentQueryHandler : IRequestHandler<GetParentByIdQuery, Response<Parent>>,
                                      IRequestHandler<GetAllParentsQuery, Response<List<Parent>>>

    {
        private readonly IParentService _parentService;
        private readonly ResponseHandler _responseHandler;

        public ParentQueryHandler(IParentService parentService, ResponseHandler responseHandler)
        {
            _parentService = parentService;
            _responseHandler = responseHandler;
        }

        public async Task<Response<Parent>> Handle(GetParentByIdQuery request, CancellationToken cancellationToken)
        {
            var parent = await _parentService.GetParentsByIdAsync(request.ParentID);
            if (parent == null)
                return _responseHandler.NotFound<Parent>("Parent not found.");

            return _responseHandler.Success(parent);
        }

        public async Task<Response<List<Parent>>> Handle(GetAllParentsQuery request, CancellationToken cancellationToken)
        {
            var parents = await _parentService.GetAllParentsAsync();
            return _responseHandler.Success(parents);
        }
    }
}
