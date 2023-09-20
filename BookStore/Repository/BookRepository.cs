using BookStore.Models;
using static BookStore.Repository.BookRepository;

namespace BookStore.Repository
{
    public class BookRepository
    {
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
