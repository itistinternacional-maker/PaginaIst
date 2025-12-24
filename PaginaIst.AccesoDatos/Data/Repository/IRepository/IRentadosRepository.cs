using PaginaIst.Models;

namespace PaginaIst.AccesoDatos.Data.Repository.IRepository
    {
    public interface IRentadosRepository : IRepository<Rentados>
        {
        void Update ( Rentados rentados );

        //    IEnumerable<SelectListItem> GetListaCategorias ();
        //    void add (Mantenimiento mantenimiento);
        //
        }
    }
