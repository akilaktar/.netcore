using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        [HttpPost]
        public async Task<ViewResult> AddNewBook(BookModel book)
        {
            //if(ModelState.IsValid)
            //{
                if(book.ImageFile != null)
                {
                    string folder = "books/cover/";
                    folder += book.ImageFile.FileName + Guid.NewGuid().ToString();
                    string serverfolder = Path.Combine(_hostEnvironment.WebRootPath, folder);
                    await book.ImageFile.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
                }
                await _bookrepository.AddNewBook(book);
            //}
            return View();
        }
    }
}
