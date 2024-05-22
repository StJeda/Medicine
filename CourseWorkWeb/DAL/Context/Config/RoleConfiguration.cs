using CourseWorkWeb.Models.Entity.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWorkWeb.DAL.Context.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Accounts)
                   .WithOne(a => a.Role)
                   .HasForeignKey(a => a.RoleId);

            builder.HasMany(r => r.RolesPermissions)
                   .WithOne(rp => rp.Role)
                   .HasForeignKey(rp => rp.RoleId);
        }
    }
}
