using Microsoft.EntityFrameworkCore;
using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
        }
    }
}
