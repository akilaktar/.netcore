using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookrepository = null;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BookController(BookRepository bookRepository, IWebHostEnvironment hostEnvironment)
        {
            _bookrepository = bookRepository;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult GetAllBooks()
        {
            var data = _bookrepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var data = _bookrepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookrepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook()
        {
            List<SelectListItem> cities = new()
            {
                new SelectListItem { Value = "1", Text = "Kolkata" },
                new SelectListItem { Value = "2", Text = "Solapur" },
                new SelectListItem { Value = "3", Text = "Nanded" },
                new SelectListItem { Value = "4", Text = "Nashik" },
                new SelectListItem { Value = "5", Text = "Nagpur" },
                new SelectListItem { Value = "6", Text = "Kolhapur" },
                new SelectListItem { Value = "7", Text = "Pune" },
                new SelectListItem { Value = "8", Text = "Mumbai" },
                new SelectListItem { Value = "9", Text = "Delhi" },
                new SelectListItem { Value = "10", Text = "Noida" }
            };
            ViewBag.cities = cities;

            List<Gender> genders = new()
            {
                new Gender {Id=1,Name="Male"},
                new Gender {Id=2,Name="Female"}
            };
            ViewBag.gender = genders;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                if (book.File != null)
                {
                    if (book.File.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(book.File.FileName);
                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);
                        var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{fileName}";
                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            book.File.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                    book.FileName = Path.GetFileName(book.File.FileName);
                }
                await _bookrepository.AddNewBook(book);
            }
            List<Gender> genders = new()
            {
                new Gender {Id=1,Name="Male"},
                new Gender {Id=2,Name="Female"}
            };
            ViewBag.gender = genders;
            return View("AddNewBook");
        }
    }
}
