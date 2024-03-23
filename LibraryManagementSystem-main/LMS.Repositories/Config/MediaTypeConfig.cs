using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class MediaTypeConfig : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.HasKey(m => m.MediaTypeId);
            builder.HasData(
                new MediaType() { MediaTypeId = 1, MediaName = "Ses" },
                new MediaType() { MediaTypeId = 2, MediaName = "Bilgisayar" },
                new MediaType() { MediaTypeId = 3, MediaName = "Mikrofilm" },
                new MediaType() { MediaTypeId = 4, MediaName = "Mikroskop" },
                new MediaType() { MediaTypeId = 5, MediaName = "Projeksiyon" },
                new MediaType() { MediaTypeId = 6, MediaName = "Stereografik" },
                new MediaType() { MediaTypeId = 7, MediaName = "Aracısız" },
                new MediaType() { MediaTypeId = 8, MediaName = "Video" },
                new MediaType() { MediaTypeId = 9, MediaName = "Belirtilmemiş" });
        }
    }
}
