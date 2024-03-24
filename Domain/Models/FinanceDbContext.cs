using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class FinanceDbContext : DbContext
{
    public FinanceDbContext()
    {
    }

    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GTOV1R1;Database=FinanceDB;User id=samar;Password=123qwe; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC0768C89238");

            entity.ToTable("Account");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.AccountType).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountTypeId)
                .HasConstraintName("FK__Account__Account__3B75D760");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Account__UserId__3C69FB99");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountT__3214EC078170A725");

            entity.ToTable("AccountType");

            entity.Property(e => e.AccountType1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AccountType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC070B143C0B");

            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
