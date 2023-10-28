using CourierCastingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers
{
    public class NavigationBarController : Controller
    {
        public IActionResult GetNavBar()
        {
            var navigationItems = new NavbarViewModel { Text = "Index" };

            return PartialView("_NavBarPartial", navigationItems);
        }
    }
}
