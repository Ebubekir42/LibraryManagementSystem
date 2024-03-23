using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class CarrierTypeConfig : IEntityTypeConfiguration<CarrierType>
    {
        public void Configure(EntityTypeBuilder<CarrierType> builder)
        {
            builder.HasKey(c => c.CarrierTypeId);
            builder.HasData(
                new CarrierType() { CarrierTypeId = 1, MediaTypeId = 1, CarrierName = "Ses Kartuşu" },
                new CarrierType() { CarrierTypeId = 2, MediaTypeId = 1, CarrierName = "Ses Kemeri" },
                new CarrierType() { CarrierTypeId = 3, MediaTypeId = 1, CarrierName = "Ses Silindiri" },
                new CarrierType() { CarrierTypeId = 4, MediaTypeId = 1, CarrierName = "Ses Diski" },
                new CarrierType() { CarrierTypeId = 5, MediaTypeId = 1, CarrierName = "Film Müziği Makarası" },
                new CarrierType() { CarrierTypeId = 6, MediaTypeId = 1, CarrierName = "Ses Rulosu" },
                new CarrierType() { CarrierTypeId = 7, MediaTypeId = 1, CarrierName = "Ses Tel Makarası" },
                new CarrierType() { CarrierTypeId = 8, MediaTypeId = 1, CarrierName = "Ses Kaseti" },
                new CarrierType() { CarrierTypeId = 9, MediaTypeId = 1, CarrierName = "Ses Bandı Makarası" },
                new CarrierType() { CarrierTypeId = 10, MediaTypeId = 1, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 12, MediaTypeId = 2, CarrierName = "Bilgisayar Kartı" },
                new CarrierType() { CarrierTypeId = 13, MediaTypeId = 2, CarrierName = "Bilgisayar Çip Kartuşu" },
                new CarrierType() { CarrierTypeId = 14, MediaTypeId = 2, CarrierName = "Bilgisayar Diski" },
                new CarrierType() { CarrierTypeId = 15, MediaTypeId = 2, CarrierName = "Bilgisayar Disk Kartuşu" },
                new CarrierType() { CarrierTypeId = 16, MediaTypeId = 2, CarrierName = "Bilgisayar Bant Kartuşu" },
                new CarrierType() { CarrierTypeId = 17, MediaTypeId = 2, CarrierName = "Bilgisayar Kaseti" },
                new CarrierType() { CarrierTypeId = 18, MediaTypeId = 2, CarrierName = "Bilgisayar Bant Makarası" },
                new CarrierType() { CarrierTypeId = 19, MediaTypeId = 2, CarrierName = "Çevrimiçi Kaynak" },
                new CarrierType() { CarrierTypeId = 20, MediaTypeId = 2, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 21, MediaTypeId = 3, CarrierName = "Diyafram Kartı" },
                new CarrierType() { CarrierTypeId = 22, MediaTypeId = 3, CarrierName = "Mikrofiş" },
                new CarrierType() { CarrierTypeId = 23, MediaTypeId = 3, CarrierName = "Mikrofiş Kaseti" },
                new CarrierType() { CarrierTypeId = 24, MediaTypeId = 3, CarrierName = "Mikrofilm Makarası" },
                new CarrierType() { CarrierTypeId = 25, MediaTypeId = 3, CarrierName = "Mikrofilm Kartuşu" },
                new CarrierType() { CarrierTypeId = 26, MediaTypeId = 3, CarrierName = "Mikrofilm Kaseti" },
                new CarrierType() { CarrierTypeId = 27, MediaTypeId = 3, CarrierName = "Mikrofilm Rulosu" },
                new CarrierType() { CarrierTypeId = 28, MediaTypeId = 3, CarrierName = "Mikrofilm Kayması" },
                new CarrierType() { CarrierTypeId = 29, MediaTypeId = 3, CarrierName = "Mikroopak" },
                new CarrierType() { CarrierTypeId = 30, MediaTypeId = 3, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 31, MediaTypeId = 4, CarrierName = "Mikroskop Lamı" },
                new CarrierType() { CarrierTypeId = 32, MediaTypeId = 4, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 33, MediaTypeId = 5, CarrierName = "Film Kartuşu" },
                new CarrierType() { CarrierTypeId = 34, MediaTypeId = 5, CarrierName = "Film Kaseti" },
                new CarrierType() { CarrierTypeId = 35, MediaTypeId = 5, CarrierName = "Film Makarası" },
                new CarrierType() { CarrierTypeId = 36, MediaTypeId = 5, CarrierName = "Film Rulosu" },
                new CarrierType() { CarrierTypeId = 37, MediaTypeId = 5, CarrierName = "Film Şeridi" },
                new CarrierType() { CarrierTypeId = 38, MediaTypeId = 5, CarrierName = "Film Şeridi Kartuşu" },
                new CarrierType() { CarrierTypeId = 39, MediaTypeId = 5, CarrierName = "Üst Şeffaflık" },
                new CarrierType() { CarrierTypeId = 40, MediaTypeId = 5, CarrierName = "Slayt" },
                new CarrierType() { CarrierTypeId = 41, MediaTypeId = 5, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 42, MediaTypeId = 6, CarrierName = "Stereogram Kartları" },
                new CarrierType() { CarrierTypeId = 43, MediaTypeId = 6, CarrierName = "Stereograf Diski" },
                new CarrierType() { CarrierTypeId = 44, MediaTypeId = 6, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 45, MediaTypeId = 7, CarrierName = "Kart" },
                new CarrierType() { CarrierTypeId = 46, MediaTypeId = 7, CarrierName = "Sunumlarda Kullanılan Büyük Yazı Kağıtları ve Tahtaları" },
                new CarrierType() { CarrierTypeId = 47, MediaTypeId = 7, CarrierName = "Rulo" },
                new CarrierType() { CarrierTypeId = 48, MediaTypeId = 7, CarrierName = "Çarşaf" },
                new CarrierType() { CarrierTypeId = 49, MediaTypeId = 7, CarrierName = "Hacim" },
                new CarrierType() { CarrierTypeId = 50, MediaTypeId = 7, CarrierName = "Nesne" },
                new CarrierType() { CarrierTypeId = 51, MediaTypeId = 7, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 52, MediaTypeId = 8, CarrierName = "Video Kartuşu" },
                new CarrierType() { CarrierTypeId = 53, MediaTypeId = 8, CarrierName = "Video Kaseti" },
                new CarrierType() { CarrierTypeId = 54, MediaTypeId = 8, CarrierName = "Video Diski" },
                new CarrierType() { CarrierTypeId = 55, MediaTypeId = 8, CarrierName = "Video Kaset Makarası" },
                new CarrierType() { CarrierTypeId = 56, MediaTypeId = 8, CarrierName = "Diğer" },
                new CarrierType() { CarrierTypeId = 57, MediaTypeId = 9, CarrierName = "Belirtilmemiş" });
        }
    }
}
