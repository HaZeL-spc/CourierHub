using CourierCastingApp.Data;
using CourierCastingApp.Services;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourierCastingApp.Controllers
{
    public class BaseController : Controller
    {
        protected ICourierCastingAppRepository _courierRepository;

        public BaseController(ICourierCastingAppRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var IfNewSession = IsNewSession();
            if (IfNewSession)
            {
                var session = new SessionHistory(DateTime.Now);
                _courierRepository.AddSession(session);
            }


            base.OnActionExecuting(filterContext);
        }

        private bool IsNewSession()
        {
            String SessionKeyName = "isNewSession";
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "false");
                return true;
            }

            return false;
        }
    }
}
