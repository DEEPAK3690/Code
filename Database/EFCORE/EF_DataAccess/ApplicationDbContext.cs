using Microsoft.EntityFrameworkCore;
using EF_DataModel.Models;
using EF_DataModel.FluentModels;

namespace EF_DataAccess
{
    public class ApplicationDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TRSDUK0\DEMOSERVER;Database=EFCoreDB2;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//fluent api configurations
        {

            modelBuilder.Entity<F_Book>().ToTable("Fluent_Book");//table name cahnge
            modelBuilder.Entity<F_Book>().Property(p => p.Price).HasColumnName("BookPrice"); //column name change
            modelBuilder.Entity<F_Book>().Property(p => p.Title).IsRequired(); //required key
            modelBuilder.Entity<F_Book>().HasKey(p => p.BookId);

            modelBuilder.Entity<F_BookDetail>().ToTable("Fluent_BookDetails");//table name cahnge
            modelBuilder.Entity<F_BookDetail>().Property(p => p.Weight).HasColumnName("bookweight"); //column name change
            modelBuilder.Entity<F_BookDetail>().Property(p => p.NumberOfChapters).IsRequired(); //required key
            modelBuilder.Entity<F_BookDetail>().HasKey(p => p.BookDetail_Id);

            modelBuilder.Entity<F_Author>().ToTable("Fluent_Author");//table name cahnge
            modelBuilder.Entity<F_Author>().HasKey(p => p.Author_Id);
            modelBuilder.Entity<F_Author>().Ignore(p => p.FullName); //ignoring full name property

            modelBuilder.Entity<F_Publisher>().ToTable("Fluent_Publisher");//table name cahnge
            modelBuilder.Entity<F_Publisher>().HasKey(p => p.Publisher_Id);
            modelBuilder.Entity<F_Publisher>().Ignore(p => p.Location); //ignoring full name property

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

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<F_BookDetail> f_BookDetails { get; set; }
        public DbSet<F_Author> F_authors { get; set; }
        public DbSet<F_Publisher> F_Publishers { get; set; }

        public DbSet<F_Book> FluentBooks { get; set; }
    }
}
