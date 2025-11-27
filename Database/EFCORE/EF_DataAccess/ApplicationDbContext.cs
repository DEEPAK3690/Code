using Microsoft.EntityFrameworkCore;
using EF_DataModel.Models;

namespace EF_DataAccess
{
    public class ApplicationDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TRSDUK0\DEMOSERVER;Database=EFCoreDB2;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

    }
}
