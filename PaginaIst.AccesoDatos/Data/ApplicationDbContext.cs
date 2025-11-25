using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaginaIst.Models;

namespace PaginaIst.Data
    {
    public class ApplicationDbContext : IdentityDbContext
        {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
            : base( options )
            {
            }
        public DbSet<Area> Area { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<EquiposIst> Equipos { get; set; }
        public DbSet<Historia_Mantenimiento> Historia_Mantenimientos { get; set; }
        public DbSet<Historia_Empleado> Historia_Empleado { get; set; }
        public DbSet<Equipo_Software> Equipo_Software { get; set; }
        public DbSet<Historia_Salario> Historia_Salario { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<PaginasIst> PaginasIsts { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Recursos> Recursos { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Tipo_Equipo> Tipo_Equipo { get; set; }
        public DbSet<Tipo_Mantenimiento> Tipo_Mantenimiento { get; set; }
        public DbSet<Tipo_Software> Tipo_Software { get; set; }
        }
    }
