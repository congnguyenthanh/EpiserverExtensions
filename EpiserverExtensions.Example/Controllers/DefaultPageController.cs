using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverExtensions.Example.Models.Pages;

namespace EpiserverExtensions.Example.Controllers
{
    public class DefaultPageController : PageController<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}