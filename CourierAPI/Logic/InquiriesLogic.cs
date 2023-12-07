using CourierAPI.Helpers;
using CourierAPI.Models;
using CourierAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CourierAPI.Logic
{
    public interface IInquiriesLogic
    {
        public Task<Result> AcceptInquiry(InquiryDTO inquiry, CancellationToken cancellationToken);
    }

    public class InquiriesLogic : IInquiriesLogic
    {
        private readonly IInquiryRepository _inquiryRepository;
        public InquiriesLogic(IInquiryRepository inquiryRepository)
        {
            _inquiryRepository = inquiryRepository;
        }

        public async Task<Result> AcceptInquiry(InquiryDTO inquiry, CancellationToken cancellationToken)
        {
            var repositoryResponse = await _inquiryRepository.GetById(inquiry.Id, cancellationToken);
            if (repositoryResponse.Success)
            {
                
            }
            else
                return Result.Fail($"Repository error: {repositoryResponse.Error}");
        }
    }
}
