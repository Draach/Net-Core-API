using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Repository;
using RestAPI.Infrastructure;
using RestAPI.Infrastructure.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceConnection"))
);

// Add repositories.
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<CategoriesRepository>();




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ECommerceDBContext>();
    dataContext.Database.Migrate();
}
    
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
