using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Services.Interfaz
{
    public interface ITokenServices
    {
        string CreateToken(Usuario usuario);
    }
}
