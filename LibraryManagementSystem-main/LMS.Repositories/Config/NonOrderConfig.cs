using Microsoft.EntityFrameworkCore;
using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class NonOrderConfig : IEntityTypeConfiguration<NonOrder>
    {
        public void Configure(EntityTypeBuilder<NonOrder> builder)
        {
            builder.HasKey(x => x.NonOrderId);
        }
    }
}
