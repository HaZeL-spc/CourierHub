using CourierAPI.Models;

namespace CourierAPI.Services.Converters
{
    public interface IInquiryModelToDtoConverter
    {
        public InquiryDTO Convert(InquiryModel inquiryDTO);
    }

    public class InquiryModelToDtoConverter : IInquiryModelToDtoConverter
    {
        public InquiryDTO Convert(InquiryModel inquiryModel)
        {
            return new InquiryDTO()
            {
                DimX = inquiryModel.DimX,
                DimY = inquiryModel.DimY,
                DimZ = inquiryModel.DimZ,
                Weight = inquiryModel.Weight,
                WeekendDelivery = inquiryModel.WeekendDelivery,
                HightPriority = inquiryModel.HightPriority,
                DeliveryDate = inquiryModel.DeliveryDate,
                Id = inquiryModel.Id,
                Name = inquiryModel.Name,
                StartLocation = new LocationDTO()
                {
                    Street = inquiryModel.StartLocation.Street,
                    StreetNumber = inquiryModel.StartLocation.StreetNumber,
                    City = inquiryModel.StartLocation.City,
                    Country = inquiryModel.StartLocation.Country,
                    PostCode = inquiryModel.StartLocation.PostCode,
                    Id = inquiryModel.Id,
                },
                EndLocation = new LocationDTO() 
                {
                    Street = inquiryModel.EndLocation.Street,
                    StreetNumber = inquiryModel.EndLocation.StreetNumber,
                    City = inquiryModel.EndLocation.City,
                    Country = inquiryModel.EndLocation.Country,
                    PostCode = inquiryModel.EndLocation.PostCode,
                    Id = inquiryModel.Id,
                },
                InquiryStatus = inquiryModel.InquiryStatus
            };
        }
    }
}
