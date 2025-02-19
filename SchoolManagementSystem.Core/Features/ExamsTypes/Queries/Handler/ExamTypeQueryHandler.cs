using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.ExamsTypes.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Queries.Handler
{
    internal class ExamTypeQueryHandler : IRequestHandler<GetExamTypeByIdQuery, Response<ExamTypeDto>>,
                                          IRequestHandler<GetAllExamTypesQuery, Response<List<ExamTypeDto>>>
    {
        private readonly IExamTypeService _examTypeService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public ExamTypeQueryHandler(IMapper mapper, ResponseHandler responseHandler, IExamTypeService examTypeService)
        {
            _mapper = mapper;
            _responseHandler = responseHandler;
            _examTypeService = examTypeService;
        }
        public async Task<Response<ExamTypeDto>> Handle(GetExamTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var examType = await _examTypeService.GetExamTypeByIdAsync(request.ExamTypeID);
            if (examType == null)
                return _responseHandler.NotFound<ExamTypeDto>("Exam Type not found.");

            var dto = _mapper.Map<ExamTypeDto>(examType);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<ExamTypeDto>>> Handle(GetAllExamTypesQuery request, CancellationToken cancellationToken)
        {
            var examTypes = await _examTypeService.GetAllExamTypesAsync();
            var dtoList = _mapper.Map<List<ExamTypeDto>>(examTypes);
            return _responseHandler.Success(dtoList);
        }
    }
}
