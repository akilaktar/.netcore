using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Security.AccessControl;
using static BookStore.Repository.BookRepository;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
            
        public BookRepository(BookStoreContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel book)
        {
            var newBook = new Books()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                Language = book.Language,
                Address = book.Address,
                TotalPages = book.TotalPages,
                CreatedOn = book.CreatedOn,
                UpdatedOn = book.UpdatedOn,
                FileName = book.FileName,
                City=book.City,
                Gender=book.Gender,
            };
            
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            var data = DataSource().Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public List<BookModel> SearchBook(string title, string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorname)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return
            new List<BookModel>() {
            new BookModel(){Id=1,Title="MVC",Author="Akil",Description="MVC book Description",Category="Programming",Language="English",TotalPages=134},
            new BookModel(){Id=2,Title="MVC .net",Author="Ak",Description="MVC book Description",Category="Programming",Language="English",TotalPages=134},
            new BookModel(){Id=3,Title="MVC .net core",Author="Aktar", Description = ">.Net book Description",Category="Programming",Language="English",TotalPages=134},
            new BookModel(){Id=4,Title="MVC c#",Author="Aki", Description = "C# book Description",Category="Programming",Language="English",TotalPages=134},
            new BookModel(){Id=5,Title="JQuery",Author="Aki", Description = "JQuery book Description",Category="Programming",Language="English",TotalPages=134},
             new BookModel(){Id=6,Title="JQuery",Author="Aki", Description = "JQuery book Description",Category="Programming",Language="English",TotalPages=134}
            };
        }
    }

}
