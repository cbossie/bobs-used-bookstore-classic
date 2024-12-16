using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Web.Areas
{
    public class AdminAreaRegistration
    {
        public static string AreaName => "Admin";

        public static void RegisterArea(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin_default",
                    areaName: AreaName,
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}