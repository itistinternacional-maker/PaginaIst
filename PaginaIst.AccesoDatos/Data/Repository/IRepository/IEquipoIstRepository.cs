using PaginaIst.Models;

namespace PaginaIst.AccesoDatos.Data.Repository.IRepository
    {
    public interface IEquipoIstRepository : IRepository<EquiposIst>
        {
        void Update ( EquiposIst equiposIst );

        //IEnumerable<SelectListItem> GetAll ();
        ////void add (PaginasIst paginasIst);
        }
    }
