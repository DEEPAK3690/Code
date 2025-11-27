using EF_DataAccess;
using Microsoft.EntityFrameworkCore;
namespace EF_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ApplicationDbcontext())
            {
                //context.Database.EnsureCreated();

                //if (context.Database.GetPendingMigrations().Count() > 0)// to enusure migration is created
                //{
                //    context.Database.Migrate();
                //}

                getallbooks(context);

            }

        }

        static void getallbooks(ApplicationDbcontext applicationDbcontext)
        {
            var books = applicationDbcontext.Books.ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"Book Id: {book.BookId}, Book Title: {book.Title}");
            }
        }
    }
}
