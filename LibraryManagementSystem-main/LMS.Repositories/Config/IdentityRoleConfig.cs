using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace LMS.Repositories.Config
{
    internal class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { Name = "User", NormalizedName = "USER" },
                new IdentityRole() { Name = "Kargo", NormalizedName = "KARGO" },
                new IdentityRole() { Name = "Personel", NormalizedName = "PERSONEL" },
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" });
        }
    }
}
