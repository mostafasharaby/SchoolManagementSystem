using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsResults.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Commands.Handlers
{
    public class ExamResultCommandHandler : IRequestHandler<AddExamResultCommand, Response<string>>,
                                            IRequestHandler<UpdateExamResultCommand, Response<string>>,
                                            IRequestHandler<DeleteExamResultCommand, Response<string>>
    {

        private readonly IExamResultService _examResultService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamResultCommandHandler(IMapper mapper, ResponseHandler responseHandler, IExamResultService examResultService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _examResultService = examResultService;
        }

        public async Task<Response<string>> Handle(AddExamResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var examResult = _mapper.Map<ExamResult>(request);
                await _examResultService.AddExamResultAsync(examResult);
                return _responseHandler.Created("Exam result created successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(UpdateExamResultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var examResult = _mapper.Map<ExamResult>(request);
                await _examResultService.UpdateExamResultAsync(examResult);
                return _responseHandler.Success("Exam result updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteExamResultCommand request, CancellationToken cancellationToken)
        {
            var result = await _examResultService.DeleteExamResultAsync(request.ExamResultID);
            if (!result)
                return _responseHandler.NotFound<string>("Exam result not found.");

            return _responseHandler.Success("Exam result deleted successfully.");
        }

    }
}
