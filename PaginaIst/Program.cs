using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaginaIst.AccesoDatos.Data.Repository;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Data;



var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString( "ConexionSQL" ) ?? throw new InvalidOperationException( "Connexion string 'DefaultConnection' not found" );

builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer( connectionString ) );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultUI();

builder.Services.AddDefaultIdentity<IdentityUser>( options => options.SignIn.RequireConfirmedAccount = false )
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

//Agregar contendedor de trabajo al contendero IoC de inyección de dependencias
builder.Services.AddScoped<IContenedorTrabajo , ContenedorTrabajo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
    app.UseMigrationsEndPoint();
    }
else
    {
    app.UseExceptionHandler( "/Home/Error" );
    }
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default" ,
    pattern: "{area=Usuario}/{controller=Home}/{action=Index}/{id?}" );
app.MapRazorPages();

app.Run();
