using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TVA_Registro_de_Vacunados.Data.DataInterface;
using TVA_Registro_de_Vacunados.DTO;
using TVA_Registro_de_Vacunados.Models;
using TVA_Registro_de_Vacunados.Services.Interfaz;

namespace TVA_Registro_de_Vacunados.Controllers
{
    
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        
        private readonly IAuthRepositorio _repo;
        private readonly ITokenServices _tokenServices;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepositorio repo, ITokenServices tokenServices, IMapper mapper)
        {
            _repo = repo;
            _tokenServices = tokenServices;
            _mapper = mapper;

        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro(UsuarioRegistroDTO usuarioDto)
        {
            usuarioDto.CorreoUsuario = usuarioDto.CorreoUsuario.ToLower();
            if (await _repo.ExisteUsuario(usuarioDto.CorreoUsuario))
                return BadRequest("El usuario ya existe");

            var usuarioNuevo = _mapper.Map<Usuario>(usuarioDto);
            var usuarioCreado = await _repo.Registrar(usuarioNuevo, usuarioDto.Password);
            var usuarioCreadoDto = _mapper.Map<UsuarioListDTO>(usuarioCreado);
            return Ok(usuarioCreadoDto);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            var usuarioFromRepo = await _repo.Login(usuarioLoginDTO.CorreoUsuario, usuarioLoginDTO.Password);
            if (usuarioFromRepo == null)
                return Unauthorized();
            var usuario = _mapper.Map<UsuarioListDTO>(usuarioFromRepo);
            var token = _tokenServices.CreateToken(usuarioFromRepo);

            return Ok(new
            {
                token = token,
                usuario = usuario

            });


        }
    }
}
