using System;
using System.ComponentModel.DataAnnotations;

namespace TVA_Registro_de_Vacunados.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public DateTime FechaCreadoUsuario { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
