using DateAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.EntitiesConfiguration
{
    public class CarConfiguration: IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ModelCar)
                .HasMaxLength(150)
                .IsRequired(); //означає обов'язковий

            builder.Property(x => x.Discription)
                .HasMaxLength(1024);  //Опис не буде довший за 1024       
        }
    }
}
