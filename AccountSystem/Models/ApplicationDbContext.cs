﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Cashier> Cashiers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.Property(e => e.BranchName).HasDefaultValue("");

            entity.HasOne(d => d.City).WithMany(p => p.Branches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branches_Cities");
        });

        modelBuilder.Entity<Cashier>(entity =>
        {
            entity.Property(e => e.CashierName).HasDefaultValue("");

            entity.HasOne(d => d.Branch).WithMany(p => p.Cashiers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cashier_Branches");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.CityName).HasDefaultValue("");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.Property(e => e.ItemName).HasDefaultValue("");

            entity.HasOne(d => d.InvoiceHeader).WithMany(p => p.InvoiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetails_InvoiceHeader");
        });

        modelBuilder.Entity<InvoiceHeader>(entity =>
        {
            entity.Property(e => e.CustomerName).HasDefaultValue("");
            entity.Property(e => e.Invoicedate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Branch).WithMany(p => p.InvoiceHeaders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceHeader_Branches");

            entity.HasOne(d => d.Cashier).WithMany(p => p.InvoiceHeaders).HasConstraintName("FK_InvoiceHeader_Cashier");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}