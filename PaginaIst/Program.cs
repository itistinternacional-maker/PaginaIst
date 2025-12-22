using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PaginaIst.AccesoDatos.Data.Repository;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Areas.Identity.Services;
using PaginaIst.Data;
using PaginaIst.Seed;
using PaginaIst.Services;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

var connectionString = builder.Configuration.GetConnectionString("ConexionSQL")
    ?? throw new InvalidOperationException("Connection string 'ConexionSQL' not found");

builder.Services.AddDbContext<ApplicationDbContext> ( options =>
    options.UseSqlServer ( connectionString ) );

builder.Services.AddDatabaseDeveloperPageExceptionFilter ( );

// ✅ Identity + Roles
builder.Services.AddDefaultIdentity<IdentityUser> ( options => options.SignIn.RequireConfirmedAccount = false )
    .AddRoles<IdentityRole> ( )
    .AddEntityFrameworkStores<ApplicationDbContext> ( );

builder.Services.AddTransient<IEmailSender , DevEmailSender> ( );

builder.Services.AddTransient<IEmailSender , SmtpEmailSender> ( );

builder.Services.AddControllersWithViews ( );
builder.Services.AddRazorPages ( ); // ✅ ya que usas Areas/Identity/Pages

builder.Services.AddScoped<IContenedorTrabajo , ContenedorTrabajo> ( );
builder.Services.AddScoped<IReporteEquipoService , ReporteEquipoService> ( );

var app = builder.Build();

// ✅ Seed roles al arrancar
using ( var scope = app.Services.CreateScope ( ) )
    {
    await RoleSeeder.SeedAsync ( scope.ServiceProvider );
    }

if ( app.Environment.IsDevelopment ( ) )
    {
    app.UseMigrationsEndPoint ( );
    }
else
    {
    app.UseExceptionHandler ( "/Home/Error" );
    }

app.UseStaticFiles ( );
app.UseRouting ( );

// ✅ faltaba
app.UseAuthentication ( );
app.UseAuthorization ( );

app.MapControllerRoute (
    name: "default" ,
    pattern: "{area=Usuario}/{controller=Home}/{action=Index}/{id?}" );

app.MapRazorPages ( );
app.Run ( );
