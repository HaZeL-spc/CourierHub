using CourierAPI.Helpers;
using CourierAPI.Models;
using CourierAPI.Services;
using CourierAPI.Services.Converters;
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
        private readonly IInquiryModelToDtoConverter _MtoDtoConverter;

        public InquiriesLogic(IInquiryRepository inquiryRepository, IInquiryModelToDtoConverter MtoDtoConverter)
        {
            _inquiryRepository = inquiryRepository;
            _MtoDtoConverter = MtoDtoConverter;
        }

        public async Task<Result> AcceptInquiry(InquiryDTO inquiry, CancellationToken cancellationToken)
        {
            var getResponse = await _inquiryRepository.GetById(inquiry.Id, cancellationToken);
            if (getResponse.Success)
            {
                InquiryModel model = new InquiryModel(inquiry);
                
                model.SetAcceptedByOfficeWorker();

                inquiry = _MtoDtoConverter.Convert(model);

                var updateResponse = await _inquiryRepository.Update(inquiry);

                return updateResponse.Success 
                    ? Result.Ok() 
                    : Result.Fail(updateResponse.Error);
            }
            else
                return Result.Fail($"Repository error: {getResponse.Error}");
        }
    }
}
