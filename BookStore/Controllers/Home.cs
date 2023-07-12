using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class Home : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
 