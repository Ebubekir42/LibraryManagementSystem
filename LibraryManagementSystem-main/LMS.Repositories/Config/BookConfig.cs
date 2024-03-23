using Microsoft.EntityFrameworkCore;
using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
        }
    }
}
