using Microsoft.EntityFrameworkCore;
using HybridApi.Data;
using HybridApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the DbContext
builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Este código lee la cadena de conexión de appsettings.json y configura el ApiDbContext para usar el proveedor de SQL Server. 

// Register the Typed HttpClient
builder.Services.AddHttpClient<IPublicApiService, PublicApiService>(client => {
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
