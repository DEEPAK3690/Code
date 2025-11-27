using EF_DataModel.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DataAccess.FluentConfig
{
    public class FluentBookconfig : IEntityTypeConfiguration<F_Book>
    {
        public void Configure(EntityTypeBuilder<F_Book> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Book");//table name cahnge
            modelBuilder.Property(p => p.Price).HasColumnName("BookPrice"); //column name change
            modelBuilder.Property(p => p.Title).IsRequired(); //required key
            modelBuilder.HasKey(p => p.BookId);
            modelBuilder.HasOne(b => b.Publisher).WithMany(b => b.Books).HasForeignKey(p => p.Publisher_Id); // one to many relationship
        }
    }
}
