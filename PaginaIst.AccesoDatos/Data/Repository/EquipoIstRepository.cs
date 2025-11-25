using Microsoft.AspNetCore.Mvc.Rendering; // ✅ Permite trabajar con elementos HTML como SelectListItem
using PaginaIst.AccesoDatos.Data.Repository.IRepository; // ✅ Interfaz que define los métodos del repositorio
using PaginaIst.Data; // ✅ Espacio de nombres del contexto de base de datos
using PaginaIst.Models; // ✅ Espacio de nombres del modelo `EquiposIst`

namespace PaginaIst.AccesoDatos.Data.Repository
    {
    // ✅ El repositorio implementa la interfaz `IEquipoIstRepository` y hereda de `Repository<EquiposIst>`
    public class EquiposIstRepository : Repository<EquiposIst>, IEquipoIstRepository
        {
        // 🔹 Contexto de base de datos para interactuar con la BD
        private readonly ApplicationDbContext _db;

        // 🔹 Constructor que recibe el contexto de base de datos mediante inyección de dependencias
        public EquiposIstRepository ( ApplicationDbContext db ) : base ( db )
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
        public void Update ( EquiposIst equiposIst )
            {
            // 🔹 Busca en la base de datos el equipo que coincida con el ID recibido
            var objDesdeDb = _db.Equipos.FirstOrDefault(e => e.id == equiposIst.id);

            // 🔹 Si el equipo existe, se actualizan sus propiedades
            if ( objDesdeDb != null )
                {
                objDesdeDb.Placa = equiposIst.Placa;
                objDesdeDb.Id_Empleado = equiposIst.Id_Empleado;
                objDesdeDb.Hostname = equiposIst.Hostname;
                objDesdeDb.Fecha_Inicial = equiposIst.Fecha_Inicial;
                objDesdeDb.Fecha_Final = equiposIst.Fecha_Final;
                objDesdeDb.Id_Tipoequipo = equiposIst.Id_Tipoequipo;
                objDesdeDb.Marca = equiposIst.Marca;
                objDesdeDb.Modelo = equiposIst.Modelo;
                objDesdeDb.Serial = equiposIst.Serial;
                objDesdeDb.Nit_Proveedor = equiposIst.Nit_Proveedor; // ✅ Asegúrate de que este campo se está enviando desde el controlador/vista
                objDesdeDb.Garantia = equiposIst.Garantia;
                objDesdeDb.Fuente = equiposIst.Fuente;
                objDesdeDb.Capacidad_Fuente = equiposIst.Capacidad_Fuente;
                objDesdeDb.Procesador = equiposIst.Procesador;
                objDesdeDb.Clase_DiscoN1 = equiposIst.Clase_DiscoN1;
                objDesdeDb.Capacidad_Disco_N1 = equiposIst.Capacidad_Disco_N1;
                objDesdeDb.Clase_Disco_N2 = equiposIst.Clase_Disco_N2;
                objDesdeDb.Capacidad_Disco_N2 = equiposIst.Capacidad_Disco_N2;
                objDesdeDb.MEMORIA_RAM_N1 = equiposIst.MEMORIA_RAM_N1;
                objDesdeDb.MEMORIA_RAM_N2 = equiposIst.MEMORIA_RAM_N2;

                // ❗️No se ejecuta `_db.SaveChanges()` porque se espera que el `Unit of Work` lo haga
                }
            }
        }
    }
