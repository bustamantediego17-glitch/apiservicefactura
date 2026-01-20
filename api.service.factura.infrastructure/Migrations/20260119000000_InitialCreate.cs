using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api.service.factura.infrastructure.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "poo");

        migrationBuilder.CreateTable(
            name: "categorias",
            schema: "poo",
            columns: table => new
            {
                categoria_id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                nombre = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                estado = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                fecha_insert = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                fecha_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("categorias_pkey", x => x.categoria_id);
            });

        migrationBuilder.CreateTable(
            name: "clientes",
            schema: "poo",
            columns: table => new
            {
                cliente_id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                direccion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                estado = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                fecha_insert = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                fecha_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("clientes_pkey", x => x.cliente_id);
            });

        migrationBuilder.CreateTable(
            name: "productos",
            schema: "poo",
            columns: table => new
            {
                producto_id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                precio = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                categoria_id = table.Column<int>(type: "integer", nullable: false),
                estado = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                fecha_insert = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                fecha_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("productos_pkey", x => x.producto_id);
                table.ForeignKey(
                    name: "fk_producto_categoria",
                    column: x => x.categoria_id,
                    principalSchema: "poo",
                    principalTable: "categorias",
                    principalColumn: "categoria_id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "pedidos",
            schema: "poo",
            columns: table => new
            {
                pedido_id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                cliente_id = table.Column<int>(type: "integer", nullable: false),
                fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                total = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true, defaultValueSql: "0"),
                estado = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                fecha_insert = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                fecha_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pedidos_pkey", x => x.pedido_id);
                table.ForeignKey(
                    name: "fk_pedido_cliente",
                    column: x => x.cliente_id,
                    principalSchema: "poo",
                    principalTable: "clientes",
                    principalColumn: "cliente_id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "pagos",
            schema: "poo",
            columns: table => new
            {
                pago_id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                pedido_id = table.Column<int>(type: "integer", nullable: false),
                metodo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                monto = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                estado = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                fecha_insert = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                fecha_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pagos_pkey", x => x.pago_id);
                table.ForeignKey(
                    name: "fk_pago_pedido",
                    column: x => x.pedido_id,
                    principalSchema: "poo",
                    principalTable: "pedidos",
                    principalColumn: "pedido_id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "pedido_detalle",
            schema: "poo",
            columns: table => new
            {
                detalle_id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                pedido_id = table.Column<int>(type: "integer", nullable: false),
                producto_id = table.Column<int>(type: "integer", nullable: false),
                cantidad = table.Column<int>(type: "integer", nullable: false),
                precio_unitario = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                subtotal = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true, computedColumnSql: "((cantidad)::numeric * precio_unitario)", stored: true),
                estado = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                fecha_insert = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                fecha_update = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pedido_detalle_pkey", x => x.detalle_id);
                table.ForeignKey(
                    name: "fk_detalle_pedido",
                    column: x => x.pedido_id,
                    principalSchema: "poo",
                    principalTable: "pedidos",
                    principalColumn: "pedido_id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_detalle_producto",
                    column: x => x.producto_id,
                    principalSchema: "poo",
                    principalTable: "productos",
                    principalColumn: "producto_id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_pedidos_cliente_id",
            schema: "poo",
            table: "pedidos",
            column: "cliente_id");

        migrationBuilder.CreateIndex(
            name: "IX_pagos_pedido_id",
            schema: "poo",
            table: "pagos",
            column: "pedido_id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_pedido_detalle_pedido_id",
            schema: "poo",
            table: "pedido_detalle",
            column: "pedido_id");

        migrationBuilder.CreateIndex(
            name: "IX_pedido_detalle_producto_id",
            schema: "poo",
            table: "pedido_detalle",
            column: "producto_id");

        migrationBuilder.CreateIndex(
            name: "IX_productos_categoria_id",
            schema: "poo",
            table: "productos",
            column: "categoria_id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "pedido_detalle",
            schema: "poo");

        migrationBuilder.DropTable(
            name: "pagos",
            schema: "poo");

        migrationBuilder.DropTable(
            name: "productos",
            schema: "poo");

        migrationBuilder.DropTable(
            name: "pedidos",
            schema: "poo");

        migrationBuilder.DropTable(
            name: "categorias",
            schema: "poo");

        migrationBuilder.DropTable(
            name: "clientes",
            schema: "poo");
    }
}
