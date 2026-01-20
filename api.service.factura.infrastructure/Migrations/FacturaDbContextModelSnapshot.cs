using System;
using api.service.factura.domain.clases;
using api.service.factura.infrastructure.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api.service.factura.infrastructure.Migrations;

[DbContext(typeof(FacturaDbContext))]
public partial class FacturaDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "9.0.4")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity<Categoria>(b =>
        {
            b.Property<int>("CategoriaId")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("categoria_id");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoriaId"));

            b.Property<string>("Nombre")
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnType("character varying(80)")
                .HasColumnName("nombre");

            b.Property<bool?>("Estado")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnName("estado");

            b.Property<DateTime?>("FechaInsert")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_insert");

            b.Property<DateTime?>("FechaUpdate")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_update");

            b.HasKey("CategoriaId").HasName("categorias_pkey");

            b.ToTable("categorias", "poo");
        });

        modelBuilder.Entity<Cliente>(b =>
        {
            b.Property<int>("ClienteId")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("cliente_id");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClienteId"));

            b.Property<string>("Nombre")
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("character varying(150)")
                .HasColumnName("nombre");

            b.Property<string?>("Direccion")
                .HasMaxLength(200)
                .HasColumnType("character varying(200)")
                .HasColumnName("direccion");

            b.Property<string?>("Telefono")
                .HasMaxLength(20)
                .HasColumnType("character varying(20)")
                .HasColumnName("telefono");

            b.Property<bool?>("Estado")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnName("estado");

            b.Property<DateTime?>("FechaInsert")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_insert");

            b.Property<DateTime?>("FechaUpdate")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_update");

            b.HasKey("ClienteId").HasName("clientes_pkey");

            b.ToTable("clientes", "poo");
        });

        modelBuilder.Entity<Producto>(b =>
        {
            b.Property<int>("ProductoId")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("producto_id");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductoId"));

            b.Property<string>("Nombre")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("character varying(100)")
                .HasColumnName("nombre");

            b.Property<decimal>("Precio")
                .HasPrecision(10, 2)
                .HasColumnType("numeric(10,2)")
                .HasColumnName("precio");

            b.Property<int>("CategoriaId")
                .HasColumnType("integer")
                .HasColumnName("categoria_id");

            b.Property<bool?>("Estado")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnName("estado");

            b.Property<DateTime?>("FechaInsert")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_insert");

            b.Property<DateTime?>("FechaUpdate")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_update");

            b.HasKey("ProductoId").HasName("productos_pkey");

            b.HasIndex("CategoriaId").HasDatabaseName("IX_productos_categoria_id");

            b.ToTable("productos", "poo");
        });

        modelBuilder.Entity<Pedido>(b =>
        {
            b.Property<int>("PedidoId")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("pedido_id");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PedidoId"));

            b.Property<int>("ClienteId")
                .HasColumnType("integer")
                .HasColumnName("cliente_id");

            b.Property<DateTime?>("Fecha")
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha");

            b.Property<decimal?>("Total")
                .HasPrecision(12, 2)
                .HasColumnType("numeric(12,2)")
                .HasDefaultValueSql("0")
                .HasColumnName("total");

            b.Property<bool?>("Estado")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnName("estado");

            b.Property<DateTime?>("FechaInsert")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_insert");

            b.Property<DateTime?>("FechaUpdate")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_update");

            b.HasKey("PedidoId").HasName("pedidos_pkey");

            b.HasIndex("ClienteId").HasDatabaseName("IX_pedidos_cliente_id");

            b.ToTable("pedidos", "poo");
        });

        modelBuilder.Entity<Pago>(b =>
        {
            b.Property<int>("PagoId")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("pago_id");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PagoId"));

            b.Property<int>("PedidoId")
                .HasColumnType("integer")
                .HasColumnName("pedido_id");

            b.Property<string>("Metodo")
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("character varying(30)")
                .HasColumnName("metodo");

            b.Property<decimal>("Monto")
                .HasPrecision(12, 2)
                .HasColumnType("numeric(12,2)")
                .HasColumnName("monto");

            b.Property<bool?>("Estado")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnName("estado");

            b.Property<DateTime?>("FechaInsert")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_insert");

            b.Property<DateTime?>("FechaUpdate")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_update");

            b.HasKey("PagoId").HasName("pagos_pkey");

            b.HasIndex("PedidoId")
                .IsUnique()
                .HasDatabaseName("IX_pagos_pedido_id");

            b.ToTable("pagos", "poo");
        });

        modelBuilder.Entity<PedidoDetalle>(b =>
        {
            b.Property<int>("DetalleId")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer")
                .HasColumnName("detalle_id");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DetalleId"));

            b.Property<int>("PedidoId")
                .HasColumnType("integer")
                .HasColumnName("pedido_id");

            b.Property<int>("ProductoId")
                .HasColumnType("integer")
                .HasColumnName("producto_id");

            b.Property<int>("Cantidad")
                .HasColumnType("integer")
                .HasColumnName("cantidad");

            b.Property<decimal>("PrecioUnitario")
                .HasPrecision(10, 2)
                .HasColumnType("numeric(10,2)")
                .HasColumnName("precio_unitario");

            b.Property<decimal?>("Subtotal")
                .HasPrecision(12, 2)
                .HasColumnType("numeric(12,2)")
                .HasColumnName("subtotal")
                .HasComputedColumnSql("((cantidad)::numeric * precio_unitario)", stored: true);

            b.Property<bool?>("Estado")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnName("estado");

            b.Property<DateTime?>("FechaInsert")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_insert");

            b.Property<DateTime?>("FechaUpdate")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_update");

            b.HasKey("DetalleId").HasName("pedido_detalle_pkey");

            b.HasIndex("PedidoId").HasDatabaseName("IX_pedido_detalle_pedido_id");
            b.HasIndex("ProductoId").HasDatabaseName("IX_pedido_detalle_producto_id");

            b.ToTable("pedido_detalle", "poo");
        });

        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId)
            .HasConstraintName("fk_producto_categoria");

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .HasConstraintName("fk_pedido_cliente");

        modelBuilder.Entity<Pago>()
            .HasOne(p => p.Pedido)
            .WithOne(p => p.Pago)
            .HasForeignKey<Pago>(p => p.PedidoId)
            .HasConstraintName("fk_pago_pedido");

        modelBuilder.Entity<PedidoDetalle>()
            .HasOne(d => d.Pedido)
            .WithMany(p => p.PedidoDetalles)
            .HasForeignKey(d => d.PedidoId)
            .HasConstraintName("fk_detalle_pedido");

        modelBuilder.Entity<PedidoDetalle>()
            .HasOne(d => d.Producto)
            .WithMany(p => p.PedidoDetalles)
            .HasForeignKey(d => d.ProductoId)
            .HasConstraintName("fk_detalle_producto");
    }
}
