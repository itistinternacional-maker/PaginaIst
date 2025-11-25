using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Data;

namespace PaginaIst.AccesoDatos.Data.Repository
    {
    public class ContenedorTrabajo : IContenedorTrabajo, IDisposable
        {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo ( ApplicationDbContext db )
            {
            _db = db;
            Mantenimiento = new MantenimientoRepository ( _db );

            PaginasIst = new PaginasIstRepository ( _db );

            EquiposIst = new EquiposIstRepository ( _db );

            //Recursos = new RecursoRepository ( _db );

            }

        public ImantenimientoRepository Mantenimiento { get; private set; }
        public IPaginasIstRepository PaginasIst { get; private set; }
        public IEquipoIstRepository EquiposIst { get; private set; }

        //public IRecursoRepository Recursos { get; private set; }


        public void Dispose ()
            {
            _db.Dispose ( );
            }

        public void Save ()
            {
            _db.SaveChanges ( );
            }

        }
    }