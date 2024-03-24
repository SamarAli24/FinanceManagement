
using Application.Command.Accounts;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<FinanceDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IAccountRepository,AccountRepository>();

builder.Services.AddMediatR(typeof(CreateAccountCommand).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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
