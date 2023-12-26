using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.ViewModels;

namespace CourierCastingApp.Services
{
    public interface IDeliveryConverter
    {
        public DeliveryDto VmToDto(DeliveryVm vm);
    }

    public class DeliveryConverter : IDeliveryConverter
    {
        public DeliveryDto VmToDto(DeliveryVm vm)
        {
            return new DeliveryDto()
            {
                Id = vm.Id,
                ClientId = vm.ClientId,
                Name = vm.Name,
                FinishedDeliveryTime = vm.FinishedDeliveryTime,
                EndLocation = new LocationDto()
                {
                    City = vm.EndLocation.City,
                    Country = vm.EndLocation.Country,
                    PostCode = vm.EndLocation.PostCode,
                    Street = vm.EndLocation.Street,
                    StreetNumber = vm.EndLocation.StreetNumber
                },
                StartLocation = new LocationDto()
                {
                    City = vm.StartLocation.City,
                    Country = vm.StartLocation.Country,
                    PostCode = vm.StartLocation.PostCode,
                    Street = vm.StartLocation.Street,
                    StreetNumber = vm.StartLocation.StreetNumber
                },
                PickedUpTime = vm.PickedUpTime,
                Status = vm.Status
            };
        }
    }
}
