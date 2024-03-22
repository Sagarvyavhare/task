using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nikhilTask.Models;

public partial class NikhilTaskContext : DbContext
{
    public NikhilTaskContext()
    {
    }

    public NikhilTaskContext(DbContextOptions<NikhilTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addresstbl> Addresstbls { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=SAGAR\\SQLEXPRESS;database=nikhil_task;trusted_connection=true;encrypt=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Addresstbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__addresst__3213E83F95B76B96");

            entity.ToTable("addresstbl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Line1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("line1");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FB23D7C2E");

            entity.ToTable("customer");

            entity.HasIndex(e => e.Mobilenumber, "UQ__customer__AAEB39828143A0A6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(false)
                .HasColumnName("active");
            entity.Property(e => e.Addressid).HasColumnName("addressid");
            entity.Property(e => e.Createdtimestamp)
                .HasColumnType("datetime")
                .HasColumnName("createdtimestamp");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Emailid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Lastupdatedtimestamp)
                .HasColumnType("datetime")
                .HasColumnName("lastupdatedtimestamp");
            entity.Property(e => e.Mobilenumber).HasColumnName("mobilenumber");
            entity.Property(e => e.Thumbnailurl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("thumbnailurl");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Addressid)
                .HasConstraintName("FK__customer__addres__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
