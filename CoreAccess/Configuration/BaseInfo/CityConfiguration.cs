using CoreCommon.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("tbl_city");
            //.HasDefaultValueSql("GetDate()");
            builder.Property(c => c.Name).HasColumnName("Name").HasColumnType("nvarchar(200)").IsRequired();
        }
    }
}
