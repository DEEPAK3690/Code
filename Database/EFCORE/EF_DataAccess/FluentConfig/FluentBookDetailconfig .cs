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
    public class FluentBookDetailconfig : IEntityTypeConfiguration<F_BookDetail>
    {
        public void Configure(EntityTypeBuilder<F_BookDetail> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookDetails");//table name cahnge
            modelBuilder.Property(p => p.Weight).HasColumnName("bookweight"); //column name change
            modelBuilder.Property(p => p.NumberOfChapters).IsRequired(); //required key
            modelBuilder.HasKey(p => p.BookDetail_Id);//key
            modelBuilder.HasOne(b => b.Book).WithOne(b => b.BookDetail).HasForeignKey<F_BookDetail>(b => b.BookId); // one to one relationship
        }
    }
}
