using System.Web.Mvc;

namespace MimAcher.WebService
{
    public class FilterConfig
    {
        protected FilterConfig()
        {
            
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
