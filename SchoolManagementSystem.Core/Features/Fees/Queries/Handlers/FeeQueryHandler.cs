using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Fees.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Fees.Queries.Handlers
{
    internal class FeeQueryHandler : IRequestHandler<GetFeeByIdQuery, Response<FeeDto>>,
                                     IRequestHandler<GetAllFeesQuery, Response<List<FeeDto>>>,
                                     IRequestHandler<GetOutstandingFeesQuery, Response<List<FeeDto>>>
    {
        private readonly IFeeService _feeService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public FeeQueryHandler(IFeeService feeService, IMapper mapper, ResponseHandler responseHandler)
        {
            _feeService = feeService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<Response<List<FeeDto>>> Handle(GetAllFeesQuery request, CancellationToken cancellationToken)
        {
            var fees = await _feeService.GetAllFeessAsync();
            var feeDtos = _mapper.Map<List<FeeDto>>(fees);
            return _responseHandler.Success(feeDtos);
        }

        public async Task<Response<FeeDto>> Handle(GetFeeByIdQuery request, CancellationToken cancellationToken)
        {
            var fee = await _feeService.GetFeesByIdAsync(request.FeeID);
            if (fee == null)
                return _responseHandler.NotFound<FeeDto>("Fee not found.");

            var feeDto = _mapper.Map<FeeDto>(fee);
            return _responseHandler.Success(feeDto);
        }

        public async Task<Response<List<FeeDto>>> Handle(GetOutstandingFeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var fees = await _feeService.GetOutstandingFeesAsync(request.StudentID);
                var feeDto = _mapper.Map<List<FeeDto>>(fees);
                return _responseHandler.Success(feeDto);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<FeeDto>>(ex.Message);
            }
        }
    }
}
