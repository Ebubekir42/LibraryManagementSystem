using Microsoft.EntityFrameworkCore;
using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.HasData(
                new Category() { CategoryId = 1, CategoryName = "Roman" },
                new Category() { CategoryId = 2, CategoryName = "Mühendislik" },
                new Category() { CategoryId = 3, CategoryName = "Bilgisayar" },
                new Category() { CategoryId = 4, CategoryName = "Şiir" },
                new Category() { CategoryId = 5, CategoryName = "Öykü" },
                new Category() { CategoryId = 6, CategoryName = "Ders Kitabı" },
                new Category() { CategoryId = 7, CategoryName = "Tarih" },
                new Category() { CategoryId = 8, CategoryName = "Mimari" },
                new Category() { CategoryId = 9, CategoryName = "Bilim" },
                new Category() { CategoryId = 10, CategoryName = "Deneme" },
                new Category() { CategoryId = 11, CategoryName = "Matematik" },
                new Category() { CategoryId = 12, CategoryName = "Biyografi" },
                new Category() { CategoryId = 13, CategoryName = "Felsefe" },
                new Category() { CategoryId = 14, CategoryName = "Edebiyat" },
                new Category() { CategoryId = 15, CategoryName = "Mimarlık" },
                new Category() { CategoryId = 16, CategoryName = "Psikoloji" },
                new Category() { CategoryId = 17, CategoryName = "Hikaye" },
                new Category() { CategoryId = 18, CategoryName = "Dergi" },
                new Category() { CategoryId = 19, CategoryName = "Yüksek Lisans" },
                new Category() { CategoryId = 20, CategoryName = "Drama" },
                new Category() { CategoryId = 21, CategoryName = "Komik" });
        }
    }
}
