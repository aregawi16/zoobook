using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using Zoobook.API.Extensions;
using Zoobook.Infrastracture.Context;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
//builder.Services.


builder.Services.AddDbContext<ZoobookContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ZoobookConnection"));
});
builder.Services.AddApplicationServices();
builder.Services.AddControllers().AddNewtonsoftJson();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
