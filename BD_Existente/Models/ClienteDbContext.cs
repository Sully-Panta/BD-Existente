using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BD_Existente.Models;

public partial class ClienteDbContext : DbContext
{
    public ClienteDbContext()
    {
    }

    public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-RGRGUHEM\\SQLEXPRESS; DataBase=ClienteDB;Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cliente_1");

            entity.ToTable("Cliente");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion).HasMaxLength(50);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.ToTable("DetalleFactura");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreArticulo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioTotal).HasColumnName("Precio_Total");
            entity.Property(e => e.PrecioUnitario).HasColumnName("Precio_Unitario");

            entity.HasOne(d => d.FacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.Factura)
                .HasConstraintName("FK_DetalleFactura_DetalleFactura");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.ToTable("Factura");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Cliente)
                .HasConstraintName("FK_Factura_Factura");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
