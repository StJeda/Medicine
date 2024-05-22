using CourseWorkWeb.Models.Entity.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWorkWeb.DAL.Context.Config
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Role)
                   .WithMany(r => r.Accounts)
                   .HasForeignKey(a => a.RoleId);
        }
    }
}
