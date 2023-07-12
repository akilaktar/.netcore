using BookStore.Models;

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
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title,string authorname)
        {
            return DataSource().Where(x=>x.Title.Contains(title) && x.Author.Contains(authorname)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>() { 
            new BookModel(){Id=1,Title="MVC",Author="Akil"},
            new BookModel(){Id=2,Title="MVC .net",Author="Ak"},
            new BookModel(){Id=3,Title="MVC .net core",Author="Aktar"},
            new BookModel(){Id=4,Title="MVC c#",Author="Aki"}
            };
        }
    }
}
