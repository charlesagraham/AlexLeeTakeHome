using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlexLeeTakeHomeCore.Models;

public partial class AlexLeeTakeHomeContext : DbContext
{
    public AlexLeeTakeHomeContext()
    {
    }

    public AlexLeeTakeHomeContext(DbContextOptions<AlexLeeTakeHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PurchaseDetailItem> PurchaseDetailItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Database=AlexLeeTakeHome;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B82BBCC041");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerData).IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF156AED307");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceNumber).HasName("PK__Invoices__D776E9801C74153E");

            entity.Property(e => e.InvoiceNumber).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFC31CEC58");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PurchaseDetailItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PurchaseDetailItem");

            entity.Property(e => e.ItemDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedByUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.PurchaseDetailItemAutoId).ValueGeneratedOnAdd();
            entity.Property(e => e.PurchaseOrderNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
