using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Parents.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Parents.Commands.Handlers
{
    internal class ParentsCommandHandler : IRequestHandler<AddParentCommand, Response<string>>,
                                           IRequestHandler<UpdateParentCommand, Response<string>>,
                                           IRequestHandler<DeleteParentCommand, Response<string>>

    {
        private readonly IParentService _parentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ParentsCommandHandler(IParentService parentService, IMapper mapper, ResponseHandler responseHandler)
        {
            _parentService = parentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> Handle(AddParentCommand request, CancellationToken cancellationToken)
        {
            var parent = _mapper.Map<Parent>(request);
            await _parentService.AddParentAsync(parent);
            return _responseHandler.Created("Parent added successfully.");
        }

        public async Task<Response<string>> Handle(UpdateParentCommand request, CancellationToken cancellationToken)
        {
            var parent = _mapper.Map<Parent>(request);
            await _parentService.UpdateParentsAsync(parent);
            return _responseHandler.Success("Parent updated successfully.");
        }

        public async Task<Response<string>> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
        {
            var result = await _parentService.DeleteParentsAsync(request.ParentID);
            if (!result)
                return _responseHandler.NotFound<string>("Parent not found.");

            return _responseHandler.Success("Parent deleted successfully.");
        }
    }
}
