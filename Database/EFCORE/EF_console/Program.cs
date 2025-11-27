using EF_DataAccess;
using EF_DataModel.Models;
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

                //getallbooks(context);
                //ADDbooks(context);
                //Getbook(context);
                updatebook(context);
            }

        }

        static void Getbook(ApplicationDbcontext applicationDbcontext)
        {
            var books = applicationDbcontext.Books.Where(x => x.BookId == 1).ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"Book Id: {book.BookId}, Book Title: {book.Title}");
            }
        }
        static void updatebook(ApplicationDbcontext applicationDbcontext)
        {
            var book = applicationDbcontext.Books.FirstOrDefault(b => b.BookId == 8);
            if (book != null)
            {
                book.Title = "ikigai";
                book.Price = 1000;
                applicationDbcontext.SaveChanges();
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
        static void ADDbooks(ApplicationDbcontext applicationDbcontext)
        {
            Book book = new Book() { Title = "new EF core book", Price = 500, ISBN = "1234", Publisher_Id = 1 };

            applicationDbcontext.Books.Add(book);

            applicationDbcontext.SaveChanges();

        }
    }
}
