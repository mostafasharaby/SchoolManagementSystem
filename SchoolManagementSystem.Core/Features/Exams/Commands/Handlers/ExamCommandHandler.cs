using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Exams.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Exams.Commands.Handlers
{
    internal class ExamCommandHandler : IRequestHandler<AddExamCommand, Response<string>>,
                                        IRequestHandler<UpdateExamCommand, Response<string>>,
                                        IRequestHandler<DeleteExamCommand, Response<string>>

    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamCommandHandler(IMapper mapper, ResponseHandler responseHandler, IExamService examService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _examService = examService;
        }

        public async Task<Response<string>> Handle(AddExamCommand request, CancellationToken cancellationToken)
        {
            var exam = _mapper.Map<Exam>(request);
            await _examService.AddExamAsync(exam);
            return _responseHandler.Created("Exam created successfully.");
        }

        public async Task<Response<string>> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exam = _mapper.Map<Exam>(request);
                await _examService.UpdateExamAsync(exam);
                return _responseHandler.Success("Exam updated successfully.");
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
        public async Task<Response<string>> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var result = await _examService.DeleteExamAsync(request.ExamID);
            if (!result)
                return _responseHandler.NotFound<string>("Exam not found.");

            return _responseHandler.Success("Exam deleted successfully.");
        }

    }
}
