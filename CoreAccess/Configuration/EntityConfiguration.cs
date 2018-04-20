using CoreCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess.Configuration
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(entity => entity.ID);
            //ValueGeneratedNever = [DatabaseGenerated(DatabaseGeneratedOption.None)]
            //ValueGeneratedOnAdd = [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            //ValueGeneratedOnAddOrUpdate = [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            builder.Property(entity => entity.ID).UseSqlServerIdentityColumn().HasColumnName("ID").ValueGeneratedOnAdd().HasColumnType("int").IsRequired();
        }
    }
}
