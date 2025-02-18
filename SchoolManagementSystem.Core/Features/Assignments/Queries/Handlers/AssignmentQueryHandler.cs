using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Assignments.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Assignments.Queries.Handlers
{
    internal class AssignmentQueryHandler : IRequestHandler<GetAssignmentByIdQuery, Response<AssignmentDto>>,
                                            IRequestHandler<GetAllAssignmentsQuery, Response<List<AssignmentDto>>>,
                                            IRequestHandler<GetAssignmentsByCourseQuery, Response<List<AssignmentDto>>>

    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public AssignmentQueryHandler(IMapper mapper, ResponseHandler responseHandler, IAssignmentService assignmentService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _assignmentService = assignmentService;
        }

        public async Task<Response<AssignmentDto>> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(request.AssignmentID);
            if (assignment == null)
                return _responseHandler.NotFound<AssignmentDto>("Assignment not found.");

            var dto = _mapper.Map<AssignmentDto>(assignment);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<AssignmentDto>>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var assignments = await _assignmentService.GetAllAssignmentsAsync();
            var dtoList = _mapper.Map<List<AssignmentDto>>(assignments);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<AssignmentDto>>> Handle(GetAssignmentsByCourseQuery request, CancellationToken cancellationToken)
        {
            var assignments = await _assignmentService.GetAssignmentsByCourseIdAsync(request.CourseID);
            var dtoList = _mapper.Map<List<AssignmentDto>>(assignments);
            return _responseHandler.Success(dtoList);
        }

    }
}
