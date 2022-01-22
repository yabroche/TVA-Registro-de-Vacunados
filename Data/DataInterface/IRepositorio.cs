using System.Collections.Generic;
using System.Threading.Tasks;
using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Data.DataInterface
{
    public interface IRepositorio
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<IEnumerable<Trabajador>> GetTrabajadorAsync();
        Task<Trabajador> GetTrabajadorByIdTrabajadorAsync(int id);
        Task<Trabajador> GetTrabajadorByNombreTrabajadorAsync(string nombre);
        
        Task<IEnumerable<Vacuna>> GetVacunaAsync();
        Task<Vacuna> GetVacunaByIdVacunaAsync(int id);
        Task<Vacuna> GetVacunaByNombreVacunaAsync(string nombre);

        Task<IEnumerable<Usuario>> GetUsuarioAsync();
        Task<Usuario> GetUsuarioByIdUsuarioAsync(int id);
        Task<Usuario> GetUsuarioByNombreUsuarioAsync(string nombre);

    }
}
