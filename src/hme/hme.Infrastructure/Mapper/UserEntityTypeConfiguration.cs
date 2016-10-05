using hme.Domain.Authentication;
using System.Data.Entity.ModelConfiguration;

namespace hme.Infrastructure.Mapper
{
    internal class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityTypeConfiguration()
        {
            this.HasKey(x => x.Id)
                .Property(x => x.Id)                
                .IsRequired();

            this.HasMany(x => x.Roles)
               .WithMany(x => x.Users)
               .Map(x =>
               {
                   x.ToTable("UserRole");
                   x.MapLeftKey("UserId");
                   x.MapRightKey("RoleId");
               });
        }
    }
}
