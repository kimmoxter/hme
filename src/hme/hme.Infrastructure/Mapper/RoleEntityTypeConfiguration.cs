using hme.Domain.Authentication;
using System.Data.Entity.ModelConfiguration;

namespace hme.Infrastructure.Mapper
{
    internal class RoleEntityTypeConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityTypeConfiguration()
        {
            this.HasKey(x => x.Id)
              .Property(x => x.Id)
              .IsRequired();

            this.HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("RoleId");
                    x.MapRightKey("UserId");
                });
        }
    }
}
