using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsScore.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Commands.Handler
{
    public class ExamScoreCommandHandler : IRequestHandler<AddExamScoreCommand, Response<string>>,
                                            IRequestHandler<UpdateExamScoreCommand, Response<string>>,
                                            IRequestHandler<DeleteExamScoreCommand, Response<string>>

    {
        private readonly IExamScoreService _examScoreService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamScoreCommandHandler(IMapper mapper, ResponseHandler responseHandler, IExamScoreService examScoreService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _examScoreService = examScoreService;
        }

        public async Task<Response<string>> Handle(AddExamScoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var examScore = _mapper.Map<ExamScore>(request);
                await _examScoreService.AddExamScoreAsync(examScore);
                return _responseHandler.Created("Exam score added successfully");
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

        public async Task<Response<string>> Handle(UpdateExamScoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var examScore = _mapper.Map<ExamScore>(request);
                await _examScoreService.UpdateExamScoreAsync(examScore);
                return _responseHandler.Success("Exam score updated successfully.");
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

        public async Task<Response<string>> Handle(DeleteExamScoreCommand request, CancellationToken cancellationToken)
        {
            var result = await _examScoreService.DeleteExamScoreAsync(request.ExamScoreID);
            if (!result)
                return _responseHandler.NotFound<string>("Exam score not found.");

            return _responseHandler.Success("Exam score deleted successfully.");
        }
    }
}
