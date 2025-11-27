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
    public class FluentAuthorconfig : IEntityTypeConfiguration<F_Author>
    {
        public void Configure(EntityTypeBuilder<F_Author> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Author");//table name cahnge
            modelBuilder.HasKey(p => p.Author_Id);
            modelBuilder.Ignore(p => p.FullName); //ignoring full name property
        }
    }
}
