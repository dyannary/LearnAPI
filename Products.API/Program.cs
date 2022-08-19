global using Microsoft.EntityFrameworkCore;
using Products.Persistence.Context;
using MediatR;
using System.Reflection;
using Products.Application.Products.AddProduct;
using Products.Application.Services;
using Products.Application.Services.Implementations;
using Products.Application.Products.GetProducts;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
        x => x.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name));
});

builder.Services.AddMediatR(typeof(AddProductCommand));
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssembly(typeof(AddProductCommand).GetTypeInfo().Assembly);
    });

builder.Services.AddAutoMapper(typeof(AddProductCommand)); //Automapper 
//builder.Services.AddMediatR(typeof(AddProductCommand)); //Mediator 
//builder.Services.AddControllers();
//builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services
builder.Services.AddMediatR(typeof(GetAllProductsQuery));
builder.Services.AddTransient<IMathService, MathService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
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
