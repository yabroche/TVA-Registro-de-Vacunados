using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TVA_Registro_de_Vacunados.Data.DataInterface;
using TVA_Registro_de_Vacunados.DTO;
using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajadorController : ControllerBase
    {
        private readonly IRepositorio _repo;
        private readonly IMapper _mapper;
        public TrabajadorController(IRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var trabajador = await _repo.GetTrabajadorAsync();
            

            return Ok(trabajador);


        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trabajador = await _repo.GetTrabajadorByIdTrabajadorAsync(id);

            if (trabajador == null)
                return NotFound("Identificador no válido.");

            var muestratrabajadorDTO = new MuestraTrabajadorDTO();

            muestratrabajadorDTO.IdTrabajador = trabajador.IdTrabajador;
            muestratrabajadorDTO.NombreTrabajador = trabajador.NombreTrabajador;
            muestratrabajadorDTO.ApellidosTrabajador = trabajador.ApellidosTrabajador;
            muestratrabajadorDTO.EdadTrabajador = trabajador.EdadTrabajador;
            muestratrabajadorDTO.CarneITrabajador = trabajador.CarneITrabajador;
            muestratrabajadorDTO.DepartamentoTrabajador = trabajador.DepartamentoTrabajador;

            return Ok(muestratrabajadorDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreaTrabajadorDTO trabajadorDTO)
        {
            var creatrabajadordto = _mapper.Map<Trabajador>(trabajadorDTO);

            _repo.Add(creatrabajadordto);
            if (await _repo.SaveAll())
                return Ok(creatrabajadordto);
            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ActulizaTrabajadorDTO trabajadorDTO)
        {
            if (id != trabajadorDTO.IdTrabajador)
                return BadRequest("Los Id no coinciden");
            var trabajadorToUpdate = await _repo.GetTrabajadorByIdTrabajadorAsync(trabajadorDTO.IdTrabajador);
            if (trabajadorToUpdate == null)
                return BadRequest();

            _mapper.Map(trabajadorDTO, trabajadorToUpdate);

            if (!await _repo.SaveAll())
                return NoContent();

            return Ok(trabajadorToUpdate);

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trabajador = await _repo.GetTrabajadorByIdTrabajadorAsync(id);
            if (trabajador == null)
                return NotFound("Identificador no valido");

            _repo.Delete(trabajador);
            if (!await _repo.SaveAll())
                return BadRequest("No se pudo borrar el trabajador con Id: " + id);
            return Ok("Borrado del trabajador con Id: " + id + " efectuado correctamente");


        }
    }
}
