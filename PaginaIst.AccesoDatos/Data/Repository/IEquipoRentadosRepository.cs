using PaginaIst.Models;

namespace PaginaIst.AccesoDatos.Data.Repository.IRepository
    {
    public interface IEquipoRentadosRepository : IRepository<EquiposRentados>
        {
        void Update ( EquiposRentados equiposRentados );

        //IEnumerable<SelectListItem> GetAll ();
        ////void add (PaginasIst paginasIst);
        }
    }
