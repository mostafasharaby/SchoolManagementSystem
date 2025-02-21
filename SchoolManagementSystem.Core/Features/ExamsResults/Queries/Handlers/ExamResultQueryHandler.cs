using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsResults.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Queries.Handlers
{
    internal class ExamResultQueryHandler : IRequestHandler<GetExamResultByIdQuery, Response<ExamResultDto>>,
                                           IRequestHandler<GetExamResultsByExamQuery, Response<List<ExamResultDto>>>,
                                           IRequestHandler<GetExamResultsByStudentQuery, Response<List<ExamResultDto>>>,
                                           IRequestHandler<GetAllExamResultsQuery, Response<List<ExamResultDto>>>
    {
        private readonly IExamResultService _examResultService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamResultQueryHandler(IMapper mapper, ResponseHandler responseHandler, IExamResultService examResultService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _examResultService = examResultService;
        }
        public async Task<Response<ExamResultDto>> Handle(GetExamResultByIdQuery request, CancellationToken cancellationToken)
        {
            var examResult = await _examResultService.GetExamResultByIdAsync(request.ExamResultID);
            if (examResult == null)
                return _responseHandler.NotFound<ExamResultDto>("Exam result not found.");

            var dto = _mapper.Map<ExamResultDto>(examResult);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<ExamResultDto>>> Handle(GetExamResultsByExamQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var examResults = await _examResultService.GetExamResultsByExamAsync(request.ExamID);
                var dtoList = _mapper.Map<List<ExamResultDto>>(examResults);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<ExamResultDto>>(ex.Message);
            }
        }

        public async Task<Response<List<ExamResultDto>>> Handle(GetExamResultsByStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var examResults = await _examResultService.GetExamResultsByStudentAsync(request.StudentID);
                var dtoList = _mapper.Map<List<ExamResultDto>>(examResults);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<ExamResultDto>>(ex.Message);
            }
        }

        public async Task<Response<List<ExamResultDto>>> Handle(GetAllExamResultsQuery request, CancellationToken cancellationToken)
        {
            var examResults = await _examResultService.GetAllExamResultsAsync();
            var dtoList = _mapper.Map<List<ExamResultDto>>(examResults);
            return _responseHandler.Success(dtoList);
        }
    }
}
