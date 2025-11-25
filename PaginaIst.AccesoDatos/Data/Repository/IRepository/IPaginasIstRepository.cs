using PaginaIst.Models;

namespace PaginaIst.AccesoDatos.Data.Repository.IRepository
    {
    public interface IPaginasIstRepository : IRepository<PaginasIst>
        {
        void Update ( PaginasIst paginasIst );

        //IEnumerable<SelectListItem> GetAll ();
        ////void add (PaginasIst paginasIst);
        }
    }
