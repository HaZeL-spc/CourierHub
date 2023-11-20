using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.ViewComponents
{
    public class NavigationBarViewComponent:ViewComponent
    {
        Dictionary<ClientStatus, List<NavBarViewModel>> dictionaryNavBar = new Dictionary<ClientStatus, List<NavBarViewModel>>();

        public NavigationBarViewComponent()
        {
            // Initialize the dictionary with default values
            dictionaryNavBar = new Dictionary<ClientStatus, List<NavBarViewModel>>
        {
            { ClientStatus.Client, new List<NavBarViewModel>
                {
                    new NavBarViewModel { Text = "Start", Url = "/", ControllerName = "Home"},
                    new NavBarViewModel { Text = "Dostarcz Paczkę", Url = "/DeliverParcel", ControllerName = "DeliverParcel" },
                    new NavBarViewModel { Text = "Historia Zamówień", Url = "/OrderHistory", ControllerName = "OrderHistory" },
                }
            },
            { ClientStatus.Courier, new List<NavBarViewModel>
                {
                    new NavBarViewModel { Text = "Start", Url = "/", ControllerName = "Home"},
                    new NavBarViewModel { Text = "Zamówienia", Url = "/Deliveries", ControllerName = "Deliveries" }
                }
            },
            { ClientStatus.OfficeWorker, new List<NavBarViewModel>
                {
                    new NavBarViewModel { Text = "Start", Url = "/", ControllerName = "Home"},
                    new NavBarViewModel { Text = "Wyszukania", Url = "/Inquiries", ControllerName = "Inquiries" },
                    new NavBarViewModel { Text = "Zamówienia", Url = "/OfferRequests", ControllerName = "OfferRequests" },
                }
            },
        };
        }

        public IViewComponentResult Invoke()
        {
            // We must provide there some kind of getting from database of status or just getting from model 
            ClientStatus userRole = ClientStatus.OfficeWorker;

            return View(dictionaryNavBar[userRole]);
        }
    }
}
