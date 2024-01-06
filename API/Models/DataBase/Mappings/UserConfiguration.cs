using API.Models.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace MotoTuneAPI.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure ( EntityTypeBuilder<User> entity )
        {
                entity.HasKey(e => e.UsrId);

                entity.Property(e => e.UsrId).HasColumnName("usr_ID");

                entity.Property(e => e.UsrDate)
                    .HasColumnType("datetime")
                    .HasColumnName("usr_date");

                entity.Property(e => e.UsrLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usr_Login");

                entity.Property(e => e.UsrPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usr_Password");
        }
    }
}
