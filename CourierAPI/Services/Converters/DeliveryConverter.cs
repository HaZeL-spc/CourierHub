using CourierAPI.Models;

namespace CourierAPI.Services.Converters
{
    public interface IDeliveryConverter
    {
        public DeliveryDto ModelToDto(DeliveryModel model);
    }

    public class DeliveryConverter : IDeliveryConverter
    {
        public DeliveryDto ModelToDto(DeliveryModel model)
        {
            return new DeliveryDto()
            {
                Id = model.Id,
                FinishedDeliveryTime = model.FinishedDeliveryTime,
                ClientId = model.ClientId,
                EndLocation = new LocationDTO()
                {
                    City = model.EndLocation.City,
                    Id = model.EndLocation.Id,
                    PostCode = model.EndLocation.PostCode,
                    Country = model.EndLocation.Country,
                    Street = model.EndLocation.Street,
                    StreetNumber = model.EndLocation.StreetNumber
                },
                StartLocation = new LocationDTO()
                {
                    City = model.StartLocation.City,
                    Id = model.StartLocation.Id,
                    PostCode = model.StartLocation.PostCode,
                    Country = model.StartLocation.Country,
                    Street = model.StartLocation.Street,
                    StreetNumber = model.StartLocation.StreetNumber
                },
                Name = model.Name,
                PickedUptime = model.PickedUpDeliveryTime,
                Status = model.Status
            };
        }
    }
}
