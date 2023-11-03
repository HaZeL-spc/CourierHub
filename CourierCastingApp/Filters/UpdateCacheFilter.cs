using CourierCastingApp.Data;
using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.DependencyResolver;
using System;
using System.Diagnostics;

namespace CourierCastingApp.Filters
{
    public class UpdateCacheFilter : ActionFilterAttribute
    {
        protected ICourierCastingAppRepository _courierRepository;

        public UpdateCacheFilter(ICourierCastingAppRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var IfNewSession = IsNewSession(filterContext);
            if (IfNewSession)
            {
                var session = new SessionHistory(DateTime.Now);
                _courierRepository.AddSession(session);
            }
        }

        private bool IsNewSession(ActionExecutingContext filterContext)
        {
            String SessionKeyName = "isNewSession";
            if (string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString(SessionKeyName)))
            {
                filterContext.HttpContext.Session.SetString(SessionKeyName, "false");
                return true;
            }

            return false;
        }
    }
}
