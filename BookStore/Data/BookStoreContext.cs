using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
                
        }
        public DbSet<Books> Books { get; set; }
        //public IQueryable<Books> SearchCustomers(int Id)
        //{
        //    SqlParameter pContactName = new SqlParameter("@Id", Id);
        //    return this.Books.FromSqlRaw("EXECUTE SP_BookbyId_Get @Id", pContactName);
        //}
    }
}
