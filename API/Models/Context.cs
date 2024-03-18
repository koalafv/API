using System;
using System.Collections.Generic;
using API.Models.DataBase.Tables;
using API.Models.DataBase.Views;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class Context : DbContext
{
    //string sql = "Data Source=localhost;Initial Catalog=PKM;Persist Security Info=True;User ID=sa;Password=12345678; TrustServerCertificate = true";

    string sql = @"Server=(localdb)\MSSQLLocalDB;Database=PKM;Trusted_Connection=True;";
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Messages> Messages { get; set; }
    public virtual DbSet<ReadedMessages> ReadedMessages { get; set; }
    public virtual DbSet<MessageItems> MessageItems { get; set; }
    public virtual DbSet<Instruction> Instruction { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(sql);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsrId);

            entity.Property(e => e.UsrId)
                .HasColumnName("usr_id");

            entity.Property(e => e.UsrWorkerNumber)
                .HasMaxLength(16)
                .HasColumnName("usr_workerNumber");

            entity.Property(e => e.UsrWorkerPin)
                .HasMaxLength(4)
                .HasColumnName("usr_workerPin");

            entity.Property(e => e.UserName)
                .HasColumnName("usr_name");

            entity.Property(e => e.UserSurname)
                .HasColumnName("usr_surname");

            entity.Property(e => e.UserPermisionId)
                .HasColumnName("usr_usrp_id");
        });

        modelBuilder.Entity<ReadedMessages>(entity =>
        {
            entity.HasKey(e => e.RmessId);

            entity.Property(e => e.RmessId)
               .HasColumnName("rmess_id");

            entity.Property(e => e.Rmess_messId)
                .HasColumnName("rmess_messId");

            entity.Property(e => e.Rmess_usrId)
                .HasColumnName("rmess_usrId");
        });

        modelBuilder.Entity<Messages>(entity =>
        {
            entity.HasKey(e => e.MessId);

            entity.Property(e => e.MessId)
                .HasColumnName("mess_id");

            entity.Property(e => e.Text)
                .HasColumnName("mess_text");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("mess_date");

            entity.Property(e => e.UserId)
                .HasColumnName("mess_createby_usrId");
        });

        modelBuilder.Entity<MessageItems>(entity =>
        {
            entity.HasKey(e => e.MessId);

            entity.Property(e => e.MessId)
                .HasColumnName("mess_id");

            entity.Property(e => e.DateCreated)
                            .HasColumnType("datetime")
                .HasColumnName("mess_date");

            entity.Property(e => e.Text)
                .HasColumnName("mess_text");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("mess_date");

            entity.Property(e => e.UserPermission)
                .HasColumnName("usrp_permission");
        });

        modelBuilder.Entity<Instruction>(entity =>
        {
            entity.HasKey(e=>e.Id);

            entity.Property(e => e.Id)
            .HasColumnName("instr_id");

            entity.Property(e => e.Date)
            .HasColumnType("datetime")
            .HasColumnName("instr_date");

            entity.Property(e => e.Patronage)
            .HasColumnName("instr_patronage");

            entity.Property(e => e.Number)
            .HasColumnName("instr_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
