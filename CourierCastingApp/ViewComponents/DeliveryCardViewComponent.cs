using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.ViewComponents
{
    public class DeliveryCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DeliveryModel delivery)
        {
            return View(delivery);
        }
    }
}
