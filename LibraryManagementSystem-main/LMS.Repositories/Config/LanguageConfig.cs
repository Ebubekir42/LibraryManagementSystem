using LMS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Repositories.Config
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.LanguageId);
            builder.HasData(
                new Language() { LanguageId = 1, Name = "Türkçe" },
                new Language() { LanguageId = 2, Name = "İngilizce" },
                new Language() { LanguageId = 3, Name = "Osmanlıca" },
                new Language() { LanguageId = 4, Name = "Almanca" },
                new Language() { LanguageId = 5, Name = "İtalyanca" },
                new Language() { LanguageId = 6, Name = "Arapça" },
                new Language() { LanguageId = 7, Name = "Yunanca" },
                new Language() { LanguageId = 8, Name = "Latince" },
                new Language() { LanguageId = 9, Name = "Korece" },
                new Language() { LanguageId = 10, Name = "Farsça" },
                new Language() { LanguageId = 11, Name = "Rusça" },
                new Language() { LanguageId = 12, Name = "İspanyolca" },
                new Language() { LanguageId = 13, Name = "Çince" },
                new Language() { LanguageId = 14, Name = "Fransızca" },
                new Language() { LanguageId = 15, Name = "İbranice" },
                new Language() { LanguageId = 16, Name = "Polca/Lehçe" },
                new Language() { LanguageId = 17, Name = "Ermenice" },
                new Language() { LanguageId = 18, Name = "Boşnakça" },
                new Language() { LanguageId = 19, Name = "Kazakça" });

        }
    }
}
