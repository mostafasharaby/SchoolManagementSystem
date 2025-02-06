using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Services.Abstracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    public class GetStudentDtoHandler : IRequestHandler<GetStudentDtoQuery, List<StudentDto>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public GetStudentDtoHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }     
        public async Task<List<StudentDto>> Handle(GetStudentDtoQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentAsync();
            return _mapper.Map<List<StudentDto>>(studentList);
        }
    }
}
