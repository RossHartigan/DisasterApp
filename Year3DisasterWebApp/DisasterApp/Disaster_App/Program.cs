using Disaster_App.Data;
using Disaster_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connection = String.Empty;
if(builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    connection = Environment.GetEnvironmentVariable("DefaultConnection");
}

builder.Services.AddDbContext<DisasterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<Disaster_App.Services.DisasterService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/Users", (DisasterContext context) =>
{
    return context.Users.ToList();
})
.WithName("GetUser");

app.MapPost("/Users", (User user, DisasterContext context) =>
{
    context.Add(user);
    context.SaveChanges();
})
.WithName("CreateUser");

app.Run();
