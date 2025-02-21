using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Exams.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Exams.Queries.Handlers
{
    internal class ExamQueryHandler : IRequestHandler<GetExamByIdQuery, Response<ExamDto>>,
                                      IRequestHandler<GetAllExamsQuery, Response<List<ExamDto>>>,
                                      IRequestHandler<GetExamsByCourseQuery, Response<List<ExamDto>>>
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamQueryHandler(IMapper mapper, ResponseHandler responseHandler, IExamService examService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _examService = examService;
        }
        public async Task<Response<ExamDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var exam = await _examService.GetExamByIdAsync(request.ExamID);
            if (exam == null)
                return _responseHandler.NotFound<ExamDto>("Exam not found.");

            var dto = _mapper.Map<ExamDto>(exam);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<ExamDto>>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
        {
            var exams = await _examService.GetAllExamsAsync();
            var dtoList = _mapper.Map<List<ExamDto>>(exams);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<ExamDto>>> Handle(GetExamsByCourseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exams = await _examService.GetExamsByCourseAsync(request.CourseID);
                var dtoList = _mapper.Map<List<ExamDto>>(exams);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<ExamDto>>(ex.Message);
            }
        }
    }
}
