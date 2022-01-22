using System.Threading.Tasks;
using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Data.DataInterface
{
    public interface IAuthRepositorio
    {
        Task<Usuario> Registrar(Usuario usuario, string password);
        Task<Usuario> Login(string Correo, string password);
        Task<bool> ExisteUsuario(string correo);

    }
}
