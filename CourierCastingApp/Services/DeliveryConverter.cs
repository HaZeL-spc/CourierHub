using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Models;
using CourierCastingApp.ViewModels;

namespace CourierCastingApp.Services
{
    public interface IDeliveryConverter
    {
        public ICollection<DeliveryVm> DtoToVmList(IEnumerable<DeliveryDto> deliveries);
    }
    public class DeliveryConverter : IDeliveryConverter
    {
        public ICollection<DeliveryVm> DtoToVmList(IEnumerable<DeliveryDto> deliveries)
        {
            ICollection<DeliveryVm> vms = new List<DeliveryVm>();
            foreach (var delivery in deliveries) 
            {
                vms.Add(new DeliveryVm(delivery));
            }
            return vms;
        }
    }
}
