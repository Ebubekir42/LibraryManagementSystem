using Microsoft.EntityFrameworkCore;
using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class DistrictConfig : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(x => x.DistrictId);
        }
    }
}
