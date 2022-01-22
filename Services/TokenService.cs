
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TVA_Registro_de_Vacunados.Models;
using TVA_Registro_de_Vacunados.Services.Interfaz;

namespace TVA_Registro_de_Vacunados.Services
{
    public class TokenService : ITokenServices
    {
        private readonly SymmetricSecurityKey _ssKey;

        public TokenService(IConfiguration config)
        {
            _ssKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenLlave"]));
        }
        public string CreateToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.CorreoUsuario)
            };
            var credenciales = new SigningCredentials(_ssKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }


    }
}
