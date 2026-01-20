using api.service.factura.infrastructure;
using api.service.factura.application;
using api.service.factura.presentation.endpoints;


var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var url = $"http://0.0.0.0:{port}";

#region servicios
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();

#endregion servicios

var app = builder.Build();

#region middleware

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("/v1/cliente").MapCliente();
app.MapGroup("/v1/categoria").MapCategoria();
app.MapGroup("/v1/producto").MapProducto();
app.MapGroup("/v1/pedido").MapPedido();
app.MapGroup("/v1/pago").MapPago();

#endregion middleware

app.Run(url);
