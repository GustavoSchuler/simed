using SisMed.WebUI.Security;
using System.Web.Mvc;

namespace SisMed.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new BasicAuth());
        }
    }
}
