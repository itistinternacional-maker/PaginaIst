using Microsoft.AspNetCore.Mvc.Rendering; // ✅ Permite trabajar con elementos HTML como SelectListItem
using PaginaIst.AccesoDatos.Data.Repository.IRepository; // ✅ Interfaz que define los métodos del repositorio
using PaginaIst.AccesoDatos.Migrations;
using PaginaIst.Data; // ✅ Espacio de nombres del contexto de base de datos
using PaginaIst.Models; // ✅ Espacio de nombres del modelo `EquiposRentados`

namespace PaginaIst.AccesoDatos.Data.Repository
    {
    // ✅ El repositorio implementa la interfaz `IEquipoIstRepository` y hereda de `Repository<IEquiposRentados>`
    public class EquiposRentadoRepository : Repository<Models.EquiposRentados>, IEquipoRentadosRepository
    {
        // 🔹 Contexto de base de datos para interactuar con la BD
        private readonly ApplicationDbContext _db;

        // 🔹 Constructor que recibe el contexto de base de datos mediante inyección de dependencias
        public EquiposRentadoRepository ( ApplicationDbContext db ) : base ( db )
            {
            _db = db;
            }

        // ✅ Método para obtener una lista de equipos en formato `SelectListItem`
        public IEnumerable<SelectListItem> GetListaEquipos ()
            {
            // 🔹 Obtiene todos los registros y los convierte en una lista de SelectListItem
            return _db.Equipos.Select ( e => new SelectListItem ( )
                {
                Text = e.Hostname ,         // ✅ Muestra el hostname como texto visible
                Value = e.id.ToString ( )   // ✅ Usa el ID como valor del elemento
                } );
            }

        // ✅ Método para actualizar un equipo en la base de datos
        public void Update ( Models.EquiposRentados equiposRentados )
            {
            // 🔹 Busca en la base de datos el equipo que coincida con el ID recibido
            var objDesdeDb = _db.EquiposRentados.FirstOrDefault(e => e.id == equiposRentados.id);

            // 🔹 Si el equipo existe, se actualizan sus propiedades
            if ( objDesdeDb != null )
                {
                objDesdeDb.Placa = equiposRentados.Placa;
                objDesdeDb.Id_Empleado = equiposRentados.Id_Empleado;
                objDesdeDb.Hostname = equiposRentados.Hostname;
                objDesdeDb.Fecha_Inicial = equiposRentados.Fecha_Inicial;
                objDesdeDb.Fecha_Final = equiposRentados.Fecha_Final;
                objDesdeDb.Id_Tipoequipo = equiposRentados.Id_Tipoequipo;
                objDesdeDb.Marca = equiposRentados.Marca;
                objDesdeDb.Modelo = equiposRentados.Modelo;
                objDesdeDb.Serial = equiposRentados.Serial;
                objDesdeDb.Nit_Proveedor = equiposRentados.Nit_Proveedor; // ✅ Asegúrate de que este campo se está enviando desde el controlador/vista
                objDesdeDb.Garantia = equiposRentados.Garantia;
                objDesdeDb.Fuente = equiposRentados.Fuente;
                objDesdeDb.Capacidad_Fuente = equiposRentados.Capacidad_Fuente;
                objDesdeDb.Procesador = equiposRentados.Procesador;
                objDesdeDb.Clase_DiscoN1 = equiposRentados.Clase_DiscoN1;
                objDesdeDb.Capacidad_Disco_N1 = equiposRentados.Capacidad_Disco_N1;
                objDesdeDb.Clase_Disco_N2 = equiposRentados.Clase_Disco_N2;
                objDesdeDb.Capacidad_Disco_N2 = equiposRentados.Capacidad_Disco_N2;
                objDesdeDb.MEMORIA_RAM_N1 = equiposRentados.MEMORIA_RAM_N1;
                objDesdeDb.MEMORIA_RAM_N2 = equiposRentados.MEMORIA_RAM_N2;

                // ❗️No se ejecuta `_db.SaveChanges()` porque se espera que el `Unit of Work` lo haga
                }
            }
        }
    }
