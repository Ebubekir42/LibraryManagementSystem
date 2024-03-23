using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class ContentTypeConfig : IEntityTypeConfiguration<ContentType>
    {
        public void Configure(EntityTypeBuilder<ContentType> builder)
        {
            builder.HasKey(c => c.ContentTypeId);
            builder.HasData(
                new ContentType() { ContentTypeId = 1, ContentName = "Kartografik Veri Kümesi" },
                new ContentType() { ContentTypeId = 2, ContentName = "Kartografik Görüntü" },
                new ContentType() { ContentTypeId = 3, ContentName = "Kartografik Hareketli Görüntü" },
                new ContentType() { ContentTypeId = 4, ContentName = "Kartografik Dokunsal Görüntü" },
                new ContentType() { ContentTypeId = 5, ContentName = "Kartografik Dokunsal Üç Boyutlu Form" },
                new ContentType() { ContentTypeId = 6, ContentName = "Kartografik Üç Boyutlu Form" },
                new ContentType() { ContentTypeId = 7, ContentName = "Bilgisayar Veri Kümesi" },
                new ContentType() { ContentTypeId = 8, ContentName = "Bilgisayar Programı" },
                new ContentType() { ContentTypeId = 9, ContentName = "Notasyonlu Hareket" },
                new ContentType() { ContentTypeId = 10, ContentName = "Notalı Müzik" },
                new ContentType() { ContentTypeId = 11, ContentName = "İcra Edilen Müzik" },
                new ContentType() { ContentTypeId = 12, ContentName = "Sesler" },
                new ContentType() { ContentTypeId = 13, ContentName = "Konuşulan Kelime" },
                new ContentType() { ContentTypeId = 14, ContentName = "Hareketsiz Görüntü" },
                new ContentType() { ContentTypeId = 15, ContentName = "Dokunsal Görüntü" },
                new ContentType() { ContentTypeId = 16, ContentName = "Dokunsal Notalı Hareket" },
                new ContentType() { ContentTypeId = 17, ContentName = "Dokunsal Metin" },
                new ContentType() { ContentTypeId = 18, ContentName = "Dokunsal Üç Boyutlu Form" },
                new ContentType() { ContentTypeId = 19, ContentName = "Metin" },
                new ContentType() { ContentTypeId = 20, ContentName = "Üç Boyutlu Form" },
                new ContentType() { ContentTypeId = 21, ContentName = "Üç Boyutlu Hareketli Görüntü" },
                new ContentType() { ContentTypeId = 22, ContentName = "İki Boyutlu Hareketli Görüntü" },
                new ContentType() { ContentTypeId = 23, ContentName = "Belirtilmemiş" },
                new ContentType() { ContentTypeId = 24, ContentName = "Diğer" });
        }
    }
}
