using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreAccess.EntityFramework
{
    public partial class EntityContext : DbContext, IEntityContextAsync, IEntityContext, IDisposable
    {
        private bool _disposed;
        private IConfigurationRoot _config;

        //when use OnConfiguring, must be passed DbContextOptions instance to base.
        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        public EntityContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
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

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        //override from DbContext
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
            base.Dispose();//base is DbContext!
        }

    }
}
