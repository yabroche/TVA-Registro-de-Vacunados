using System;

namespace TVA_Registro_de_Vacunados.DTO
{
    public class UsuarioRegistroDTO
    {

        public string CorreoUsuario { get; set; }
        public string Password { get; set;}
        public string NombreUsuario { get; set; }
        public DateTime FechaCreadoUsuario { get; set; }

        public UsuarioRegistroDTO()
        {
            FechaCreadoUsuario = DateTime.Now;
        }


    }
}
