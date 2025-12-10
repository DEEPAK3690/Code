using Microsoft.EntityFrameworkCore;
using EF_DataModel.Models;
using EF_DataModel.FluentModels;
using EF_DataAccess.FluentConfig;
using Microsoft.Extensions.Logging;

namespace EF_DataAccess
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-TRSDUK0\DEMOSERVER;Database=EFCoreDB2;Trusted_Connection=True;TrustServerCertificate=True;").LogTo(Console.WriteLine, LogLevel.Information); // added in appsettings.json

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//fluent api configurations
        {
            modelBuilder.ApplyConfiguration(new FluentBookconfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailconfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorconfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherconfig());

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
               new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
               new Book { BookId = 2, Title = "Fortune of time", ISBN = "12123B12", Price = 11.99m, Publisher_Id = 1 }
           );

            var bookList = new Book[]
            {
                 new Book { BookId = 3, Title = "Fake Sunday", ISBN = "77652", Price = 20.99m, Publisher_Id=2 },
                 new Book { BookId = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m , Publisher_Id=3},
                 new Book { BookId = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m , Publisher_Id=3}
            };
            modelBuilder.Entity<Book>().HasData(bookList);


            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
                );

            var categories = new Category[]
            {
                new Category { CategoryId = 1, CategoryName = "Horror" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" }
            };
            modelBuilder.Entity<Category>().HasData(categories);

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<F_BookDetail> f_BookDetails { get; set; }
        public DbSet<F_Author> F_authors { get; set; }
        public DbSet<F_Publisher> F_Publishers { get; set; }

        public DbSet<F_Book> FluentBooks { get; set; }
    }
}
