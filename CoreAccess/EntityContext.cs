using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAccess
{
    public class EntityContext : DbContext, IEntityContext, IDisposable
    {
        private bool _disposed;

        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //LazyLoadingEnabled, ProxyCreationEnabled

            //You can change the behavior when an include operator is ignored to either throw or do nothing.
            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Mapper.Initialize(config => { config.AllowNullCollections = true; config.AllowNullDestinationValues = true; config.CreateMissingTypeMaps = true; });
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override void Dispose()
        {
            if (!this._disposed)
            {
                IDbConnection dbConnection = base.Database.GetDbConnection();
                if (dbConnection != null && dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
                this._disposed = true;
            }
            base.Dispose();
        }
    }
}
