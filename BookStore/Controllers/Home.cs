using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class Home : Controller
    {
        public ViewResult Index()
        {
            ViewBag.title = 123;
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Akil"; 
            //ViewBag.data =  new { Id=1, Name="Akil"};
            ViewBag.Data = data;

            ViewBag.book = new BookModel() { Id = 1, Author = "Akil" };
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
