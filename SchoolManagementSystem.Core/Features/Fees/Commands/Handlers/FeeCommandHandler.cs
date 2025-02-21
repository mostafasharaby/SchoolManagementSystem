using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Fees.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Fees.Commands.Handlers
{
    internal class FeeCommandHandler : IRequestHandler<CreateFeeCommand, Response<string>>,
                                       IRequestHandler<UpdateFeeCommand, Response<string>>,
                                       IRequestHandler<DeleteFeeCommand, Response<string>>
    {
        private readonly IFeeService _feeService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public FeeCommandHandler(IFeeService feeService, IMapper mapper, ResponseHandler responseHandler)
        {
            _feeService = feeService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> Handle(CreateFeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fee = _mapper.Map<Fee>(request);
                await _feeService.AddFeesAsync(fee);
                return _responseHandler.Created("created successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }
        public async Task<Response<string>> Handle(UpdateFeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fee = _mapper.Map<Fee>(request);
                await _feeService.UpdatelFeesAsync(fee);
                return _responseHandler.Success("Fee updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }
        public async Task<Response<string>> Handle(DeleteFeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _feeService.DeletelFeesAsync(request.FeeID);
            if (!result)
                return _responseHandler.NotFound<string>("Fee not found.");

            return _responseHandler.Success("Fee deleted successfully.");
        }


    }
}
