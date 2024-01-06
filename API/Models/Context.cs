using System;
using System.Collections.Generic;
using API.Models.DataBase.Tables;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MotoTune;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
