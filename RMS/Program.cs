using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using RMS_DAL.RMSDBContext;
using RMS_DAL.Interfaces;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("RMSConnection");
builder.Services.AddDbContext<RMSContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddTransient<IRMSContext, RMSContext>();

builder.Services.AddCors();
//builder.Services.AddControllers();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(

    options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    //.AllowCredentials()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader();
                          });
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseCors(MyAllowSpecificOrigins);
app.Run();