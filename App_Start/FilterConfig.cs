using OpenB.BaseWeb;
using System.Web;
using System.Web.Mvc;

namespace OpenB.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeActionFilterAttribute());
        }
    }
}
