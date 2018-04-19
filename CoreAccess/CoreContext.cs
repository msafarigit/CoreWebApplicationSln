using CoreAccess.Configuration;
using CoreCommon.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess
{
    public class CoreContext : DbContext
    {
        private IConfigurationRoot _config;

        //when use OnConfiguring, must be passed DbContextOptions instance to base.
        public CoreContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //if (!optionsBuilder.IsConfigured)

            //when use appsetting.json: _config["connectionStrings:CoreDb"]
            //when use app.config: ConfigurationManager.ConnectionStrings["CoreDb"].ConnectionString
            optionsBuilder.UseSqlServer(_config["connectionStrings:CoreDb"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new CityConfiguration());
        }
    }
}
