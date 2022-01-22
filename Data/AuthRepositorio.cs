using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TVA_Registro_de_Vacunados.Data.DataInterface;
using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Data
{
    public class AuthRepositorio : IAuthRepositorio
    {
        
        private readonly DataContext _context;
        public AuthRepositorio(DataContext context)
        {
            this._context = context;
        }
        public async Task<bool> ExisteUsuario(string correo)
        {
            if (await _context.Usuarios.AnyAsync(x=> x.CorreoUsuario == correo))
                return true;

                return false;
        }

        public async Task<Usuario> Login(string Correo, string password)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x=> x.CorreoUsuario == Correo);
            if(usuario == null)
                return null;
            if(!VerifyPasswordHash(password, usuario.PasswordHash, usuario.PasswordSalt))
                return null;

                return usuario;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte [] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i< computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }

        }

        public async Task<Usuario> Registrar(Usuario usuario, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        
        }



    }
}
