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
    public class VacunaController : ControllerBase
    {
        private readonly IRepositorio _repo;
        private readonly IMapper _mapper;
        public VacunaController(IRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vacuna = await _repo.GetVacunaAsync();
            
            return Ok(vacuna);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vacuna = await _repo.GetVacunaByIdVacunaAsync(id);

            if (vacuna == null)
                return NotFound("Identificador no válido.");

            var muestravacunaDTO = new MuestraVacunaDTO();

            muestravacunaDTO.IdVacuna = vacuna.IdVacuna;
            muestravacunaDTO.NombreVacuna = vacuna.NombreVacuna;
            muestravacunaDTO.LoteVacuna = vacuna.LoteVacuna;
            muestravacunaDTO.DosisVacuna = vacuna.DosisVacuna;
            muestravacunaDTO.FechaVacuna = vacuna.FechaVacuna;

            return Ok(muestravacunaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreaVacunaDTO vacunaDTO)
        {
           
            var creavacunadto = _mapper.Map<Vacuna>(vacunaDTO);

            _repo.Add(creavacunadto);
                if (await _repo.SaveAll())
                    return Ok(creavacunadto);
                return BadRequest();
                                  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ActulizaVacunaDTO vacunaDTO)
        {
            if (id != vacunaDTO.IdVacuna)
                return BadRequest("Los Id no coinciden");
            var vacunasToUpdate = await _repo.GetVacunaByIdVacunaAsync(vacunaDTO.IdVacuna);
            if (vacunasToUpdate == null)
                return BadRequest();

            _mapper.Map(vacunaDTO, vacunasToUpdate);

            if (!await _repo.SaveAll())
                return NoContent();

            return Ok(vacunasToUpdate);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vacuna = await _repo.GetVacunaByIdVacunaAsync(id);
            if (vacuna == null)
                return NotFound("Identificador no valido");

            _repo.Delete(vacuna);
            if (!await _repo.SaveAll())
                return BadRequest("No se pudo borrar la vacuna con Id: " + id);
            return Ok("Borrado de la vacuna con Id: " + id + " efectuado correctamente");


        }


    }
}
