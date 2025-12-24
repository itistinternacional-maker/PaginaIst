using Microsoft.AspNetCore.Mvc.Rendering;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Data;
using PaginaIst.Models;

namespace PaginaIst.AccesoDatos.Data.Repository
    {
    public class RentadosRepository : Repository<Rentados>, IRentadosRepository
        {
        private readonly ApplicationDbContext _db;

        public RentadosRepository ( ApplicationDbContext db ) : base ( db )
            {
            _db = db;
            }

        public IEnumerable<SelectListItem> GetAll ()
            {
            throw new NotImplementedException ( );
            }

        public IEnumerable<SelectListItem> GetListaCategorias ()
            {
            return _db.Mantenimiento.Select ( i => new SelectListItem ( )
                {
                Text = i.Comentario ,
                Value = i.Id.ToString ( )
                } );
            }


        public void Update ( Rentados rentado )
            {
            var
            objDesdeDb = _db.Mantenimiento.FirstOrDefault( s => s.Id == rentado.Id );
            objDesdeDb.Fecha = rentado.Fecha;
            objDesdeDb.Placa = rentado.Placa;
            objDesdeDb.Tipo_mantto = rentado.Tipo_mantto;
            objDesdeDb.Comentario = rentado.Comentario;
            objDesdeDb.Ruta_evidencias = rentado.Ruta_evidencias;

            _db.SaveChanges ( );
            }
        }

    }

