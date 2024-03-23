using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class FormatConfig : IEntityTypeConfiguration<Format>
    {
        public void Configure(EntityTypeBuilder<Format> builder)
        {
            builder.HasKey(f => f.FormatId);
            builder.HasData(
                new Format() { FormatId = 1, FormatName = "Kitaplar" },
                new Format() { FormatId = 2, FormatName = "Kağıt Kapaklı Olan Kitaplar" },
                new Format() { FormatId = 3, FormatName = "Büyük Basılı" },
                new Format() { FormatId = 4, FormatName = "Junior Basılı Materyal" },
                new Format() { FormatId = 5, FormatName = "CD'li Çocuk Kitabı" },
                new Format() { FormatId = 6, FormatName = "Grafik Romanlar" },
                new Format() { FormatId = 7, FormatName = "Dergiler" },
                new Format() { FormatId = 8, FormatName = "e-Kitaplar" },
                new Format() { FormatId = 9, FormatName = "CD'deki Sesli Kitaplar" },
                new Format() { FormatId = 10, FormatName = "e-Sesli Kitaplar" },
                new Format() { FormatId = 11, FormatName = "Müzik CD'si" },
                new Format() { FormatId = 12, FormatName = "DVD" },
                new Format() { FormatId = 13, FormatName = "Video Oyunları" }
                );
        }
    }
}
