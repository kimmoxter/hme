using hme.Domain.Authentication;
using hme.Domain.Core;
using hme.Infrastructure.Contracts;
using hme.Infrastructure.Mapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Infrastructure.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class HMEMainBoundContextUnitOfWork : DbContext, IQueryableUnitOfWork
    {        
        public HMEMainBoundContextUnitOfWork() 
            : base("HMEConnectionStringMySql")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
       

        public Task CommitAsync()
        {
            return this.SaveChangesAsync();
        }

        public Task CommitAsync(CancellationToken token)
        {
            return this.SaveChangesAsync(token);
        }

        public IDbSet<T> CreateSet<T>() where T : class
        {
            return this.Set<T>();
        }

        public void RollBack()
        {
            this.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.Entity.EntityState.Unchanged);
        }

        public Task Update<T>(T olderEntity, T newEntity) where T : class
        {
            this.Entry<T>(olderEntity).CurrentValues.SetValues(newEntity);
            return Task.CompletedTask;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityTypeConfiguration());
            

            base.OnModelCreating(modelBuilder);
        }

        void IUnitOfWork.Commit()
        { 
            this.SaveChanges();
        }
    }

    public class MigrationsContextFactory : IDbContextFactory<HMEMainBoundContextUnitOfWork>
    {
        public HMEMainBoundContextUnitOfWork Create()
        {
            return new HMEMainBoundContextUnitOfWork();
        }
    }
}
