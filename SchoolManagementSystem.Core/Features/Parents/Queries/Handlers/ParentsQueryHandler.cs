using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Parents.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Parents.Queries.Handlers
{
    public class ParentQueryHandler : IRequestHandler<GetParentByIdQuery, Response<Parent>>,
                                      IRequestHandler<GetAllParentsQuery, Response<List<Parent>>>,
                                      IRequestHandler<GetStudentsByParentQuery, Response<List<StudentDto>>>,
                                      IRequestHandler<GetFeePaymentHistoryByParentQuery, Response<List<FeeDto>>>

    {
        private readonly IParentService _parentService;
        private readonly ResponseHandler _responseHandler;
        private readonly IMapper _mapper;
        public ParentQueryHandler(IParentService parentService, ResponseHandler responseHandler, IMapper mapper)
        {
            _parentService = parentService;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }

        public async Task<Response<Parent>> Handle(GetParentByIdQuery request, CancellationToken cancellationToken)
        {
            var parent = await _parentService.GetParentsByIdAsync(request.ParentID);
            if (parent == null)
                return _responseHandler.NotFound<Parent>("Parent not found.");

            return _responseHandler.Success(parent);
        }

        public async Task<Response<List<Parent>>> Handle(GetAllParentsQuery request, CancellationToken cancellationToken)
        {
            var parents = await _parentService.GetAllParentsAsync();
            return _responseHandler.Success(parents);
        }

        public async Task<Response<List<StudentDto>>> Handle(GetStudentsByParentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var students = await _parentService.GetStudentsByParentAsync(request.ParentID);
                var feeDtos = _mapper.Map<List<StudentDto>>(students);
                return _responseHandler.Success(feeDtos);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<StudentDto>>(ex.Message);
            }
        }

        public async Task<Response<List<FeeDto>>> Handle(GetFeePaymentHistoryByParentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var feePayments = await _parentService.GetFeePaymentHistoryByParentAsync(request.ParentID);
                var feeDtos = _mapper.Map<List<FeeDto>>(feePayments);
                return _responseHandler.Success(feeDtos);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<FeeDto>>(ex.Message);
            }
        }
    }
}
