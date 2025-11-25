using Microsoft.AspNetCore.Mvc.Rendering;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Data;
using PaginaIst.Models;

namespace PaginaIst.AccesoDatos.Data.Repository
    {
    public class PaginasIstRepository : Repository<PaginasIst>, IPaginasIstRepository
        {
        private readonly ApplicationDbContext _db;

        public PaginasIstRepository ( ApplicationDbContext db ) : base ( db )
            {

            _db = db;
            }
        public IEnumerable<SelectListItem> GetAll ()
            {
            throw new NotImplementedException ( );
            }

        public IEnumerable<SelectListItem> GetListaPaginas ()
            {
            return _db.PaginasIsts.Select ( i => new SelectListItem ( )
                {
                Text = i.Url ,
                Value = i.Id.ToString ( )
                } );
            }

        public void Update ( PaginasIst paginasIst )
            {
            var objDesdeDb = _db.PaginasIsts.FirstOrDefault( s => s.Id == paginasIst.Id );
            objDesdeDb.Url = paginasIst.Url;
            objDesdeDb.Descripcion = paginasIst.Descripcion;
            objDesdeDb.Observacion = paginasIst.Observacion;
            objDesdeDb.Usuario = paginasIst.Usuario;
            objDesdeDb.Contraseña = paginasIst.Contraseña;

            //_db.SaveChanges();
            }
        }
    }
