using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Handler
{
    public class ExamTypeCommandHandler : IRequestHandler<AddExamTypeCommand, Response<string>>,
                                            IRequestHandler<UpdateExamTypeCommand, Response<string>>,
                                            IRequestHandler<DeleteExamTypeCommand, Response<string>>


    {
        private readonly IExamTypeService _examTypeService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamTypeCommandHandler(IMapper mapper, ResponseHandler responseHandler, IExamTypeService examTypeService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _examTypeService = examTypeService;
        }

        public async Task<Response<string>> Handle(AddExamTypeCommand request, CancellationToken cancellationToken)
        {
            var examType = _mapper.Map<ExamType>(request);
            var id = await _examTypeService.AddExamTypeAsync(examType);
            return _responseHandler.Created("Exam Type score added successfully");
        }

        public async Task<Response<string>> Handle(UpdateExamTypeCommand request, CancellationToken cancellationToken)
        {
            var examType = _mapper.Map<ExamType>(request);
            var result = await _examTypeService.UpdateExamTypeAsync(examType);
            return result ? _responseHandler.Success("Exam Type updated successfully.") :
                            _responseHandler.NotFound<string>("Exam Type not found.");
        }

        public async Task<Response<string>> Handle(DeleteExamTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _examTypeService.DeleteExamTypeAsync(request.ExamTypeID);
            return result ? _responseHandler.Success("Exam Type deleted successfully.") :
                            _responseHandler.NotFound<string>("Exam Type not found.");
        }


    }

}
