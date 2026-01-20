# API Factura Service (Diego)

Servicio REST con **Minimal API (.NET 9)** + **Entity Framework Core 9** + **PostgreSQL (Supabase)**.

## Objetivo

- Arquitectura en capas: **Presentation**, **Application**, **Domain**, **Infrastructure**.
- 6 entidades (tablas): **Cliente**, **Categoria**, **Producto**, **Pedido**, **PedidoDetalle**, **Pago**.
- La base de datos se crea desde **EF Core Migrations** (no se crean tablas manualmente).
- Validaciones para evitar JSON inválidos.
- Documentación en Swagger.

## Requisitos

- .NET SDK 9
- Proyecto en Supabase (PostgreSQL)

## Configuración de conexión (Supabase)

Editar `api.service.factura.presentation/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=[SERVER];Port=6543;Database=postgres;Username=[USERNAME];Password=[PASSWORD];"
}
```

En Supabase, los datos suelen estar en **Project Settings → Database**.

## Crear la base de datos desde EF Core

Desde la carpeta de la solución:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update --project api.service.factura.infrastructure --startup-project api.service.factura.presentation
```

> Las migraciones ya vienen en `api.service.factura.infrastructure/Migrations`.

## Ejecutar la API

```bash
dotnet run --project api.service.factura.presentation
```

La documentación queda en:

- `http://localhost:3000/swagger`

## Deploy en Firebase Studio / App Hosting

1) Importa el repo en Firebase Studio.
2) Configura una variable de entorno con la cadena de conexión:

`ConnectionStrings__DefaultConnection`

3) Ejecuta / despliega el proyecto `api.service.factura.presentation`.

La app usa el puerto por la variable `PORT` (cuando existe) y por defecto 3000.
