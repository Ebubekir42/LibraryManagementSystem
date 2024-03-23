using Microsoft.EntityFrameworkCore;
using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class BookingOfficeConfig : IEntityTypeConfiguration<BookingOffice>
    {
        public void Configure(EntityTypeBuilder<BookingOffice> builder)
        {
            builder.HasKey(x => x.BookingOfficeId);
        }
    }
}
