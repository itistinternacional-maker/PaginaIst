namespace PaginaIst.AccesoDatos.Data.Repository.IRepository
    {
    public interface IContenedorTrabajo : IDisposable
        {
        //Aqui se deben ir agregando los diferentes metodos
        ImantenimientoRepository Mantenimiento { get; }
       
        IPaginasIstRepository PaginasIst { get; }

        IEquipoIstRepository EquiposIst { get; }

        //IRecursoRepository Recursos { get; }

        void Save ();
        }
    }
