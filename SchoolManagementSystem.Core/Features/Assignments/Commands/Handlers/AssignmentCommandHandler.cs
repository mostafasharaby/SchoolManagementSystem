using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Assignments.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Assignments.Commands.Handlers
{
    public class AssignmentCommandHandler : IRequestHandler<AddAssignmentCommand, Response<string>>,
                                         IRequestHandler<UpdateAssignmentCommand, Response<string>>,
                                         IRequestHandler<DeleteAssignmentCommand, Response<string>>

    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public AssignmentCommandHandler(IMapper mapper, ResponseHandler responseHandler, IAssignmentService assignmentService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _assignmentService = assignmentService;
        }

        public async Task<Response<string>> Handle(AddAssignmentCommand request, CancellationToken cancellationToken)
        {
            var assignment = _mapper.Map<Assignment>(request);
            await _assignmentService.AddAssignmentAsync(assignment);
            return _responseHandler.Created("Assignment created successfully.");
        }

        public async Task<Response<string>> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var assignment = _mapper.Map<Assignment>(request);
                await _assignmentService.UpdateAssignmentAsync(assignment);
                return _responseHandler.Success("Assignment updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest<string>("An unexpected error occurred: " + ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _assignmentService.DeleteAssignmentAsync(request.AssignmentID);
            if (!result)
                return _responseHandler.NotFound<string>("Assignment not found.");

            return _responseHandler.Success("Assignment deleted successfully.");
        }

    }

}
