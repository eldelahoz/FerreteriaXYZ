using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_FerreteriaXYZ.Models;

public partial class DbFerreteriaContext : DbContext
{
    public DbFerreteriaContext()
    {
    }

    public DbFerreteriaContext(DbContextOptions<DbFerreteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DireccionCliente> DireccionClientes { get; set; }

    public virtual DbSet<EstadoFactura> EstadoFacturas { get; set; }

    public virtual DbSet<EstadoProducto> EstadoProductos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    public virtual DbSet<Unidad> Unidades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Clientes", "Customers");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("smalldatetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoDireccionNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CodigoDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_DireccionClientes");

            entity.HasOne(d => d.TipoDocumentoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.TipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_TiposDocumento");
        });

        modelBuilder.Entity<DireccionCliente>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("DireccionClientes", "Customers");

            entity.Property(e => e.Barrio)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoFactura>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("EstadoFactura", "Storage");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoProducto>(entity =>
        {
            entity.ToTable("EstadoProductos", "Storage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Inventario", "Storage");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.Pcodigo).HasColumnName("PCodigo");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_EstadoProductos");

            entity.HasOne(d => d.PcodigoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.Pcodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Productos");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Pedidos", "Invoicing");

            entity.Property(e => e.FechaActualizacion).HasColumnType("smalldatetime");
            entity.Property(e => e.FechaCierre).HasColumnType("smalldatetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Productos", "Storage");

            entity.Property(e => e.FechaActualizacion).HasColumnType("smalldatetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ValorUnitario).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.VolumenEmpaque).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_EstadoProductos");

            entity.HasOne(d => d.UnidadCodigoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.UnidadCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Unidades");
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("TiposDocumento", "Customers");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Unidades", "Storage");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
