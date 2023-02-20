using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Creation des instances pour le projet web

    // Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //Commit pour persistance
builder.Services.AddScoped<Type>(t => typeof(GenericRepository<>));// methodes crud
builder.Services.AddDbContext<DbContext, AMContext>();//connexion à la base


builder.Services.AddScoped<IServiceFlight, ServiceFlight>(); // creation d'une instance: IService flight x=new services flight()
builder.Services.AddScoped<IServicePlane, ServicePlane>(); // creation d'une instance: IService plane x=new services plane()



//Le bloc de code suivant est automatiquement généré
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();