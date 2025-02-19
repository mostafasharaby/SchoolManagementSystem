using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsScore.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Queries.Handler
{
    public class ExamScoreQueryHandler : IRequestHandler<GetExamScoreByIdQuery, Response<ExamScoreDto>>,
                                         IRequestHandler<GetExamScoresQuery, Response<List<ExamScoreDto>>>,
                                         IRequestHandler<GetExamScoresByExamQuery, Response<List<ExamScoreDto>>>,
                                         IRequestHandler<GetExamScoresByStudentQuery, Response<List<ExamScoreDto>>>
    {
        private readonly IExamScoreService _examScoreService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamScoreQueryHandler(IMapper mapper, ResponseHandler responseHandler, IExamScoreService examScoreService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _examScoreService = examScoreService;
        }

        public async Task<Response<ExamScoreDto>> Handle(GetExamScoreByIdQuery request, CancellationToken cancellationToken)
        {
            var examScore = await _examScoreService.GetExamScoreByIdAsync(request.ExamScoreID);
            if (examScore == null)
                return _responseHandler.NotFound<ExamScoreDto>("Exam score not found.");

            var dto = _mapper.Map<ExamScoreDto>(examScore);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<ExamScoreDto>>> Handle(GetExamScoresQuery request, CancellationToken cancellationToken)
        {
            var examScores = await _examScoreService.GetAllExamScoresAsync();
            var dtoList = _mapper.Map<List<ExamScoreDto>>(examScores);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<ExamScoreDto>>> Handle(GetExamScoresByExamQuery request, CancellationToken cancellationToken)
        {
            var examScores = await _examScoreService.GetExamScoresByExamIdAsync(request.ExamID);
            var dtoList = _mapper.Map<List<ExamScoreDto>>(examScores);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<ExamScoreDto>>> Handle(GetExamScoresByStudentQuery request, CancellationToken cancellationToken)
        {
            var examScores = await _examScoreService.GetExamScoresByStudentIdAsync(request.StudentID);
            var dtoList = _mapper.Map<List<ExamScoreDto>>(examScores);
            return _responseHandler.Success(dtoList);
        }
    }

}
