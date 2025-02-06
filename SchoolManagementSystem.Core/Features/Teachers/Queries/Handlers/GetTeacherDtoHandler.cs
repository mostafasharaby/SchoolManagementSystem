using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Results;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Handlers
{
    internal class GetTeacherDtoHandler : IRequestHandler<GetTeacherDtoQuery, List<TeacherDto>>
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public GetTeacherDtoHandler(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public async Task<List<TeacherDto>> Handle(GetTeacherDtoQuery request, CancellationToken cancellationToken)
        {
            var TeacherList = await _teacherService.GetTeachersAsync();
            return _mapper.Map<List<TeacherDto>>(TeacherList);
          
        }
    }
}
