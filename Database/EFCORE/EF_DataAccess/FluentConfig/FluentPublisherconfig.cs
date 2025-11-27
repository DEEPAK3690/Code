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
    public class FluentPublisherconfig : IEntityTypeConfiguration<F_Publisher>
    {
        public void Configure(EntityTypeBuilder<F_Publisher> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Publisher");//table name cahnge
            modelBuilder.HasKey(p => p.Publisher_Id);
        }
    }
}
