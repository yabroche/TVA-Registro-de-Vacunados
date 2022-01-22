using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVA_Registro_de_Vacunados.Data.DataInterface;
using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Data
{
    public class Repositorio : IRepositorio
    {
        private readonly DataContext _context;
        public Repositorio(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        //
        public async Task<IEnumerable<Vacuna>> GetVacunaAsync()
        {
            var vacunas = await _context.Vacunas.ToListAsync();
            return vacunas;
        }
        public async Task<Vacuna> GetVacunaByIdVacunaAsync(int id)
        {
            var vacuna = await _context.Vacunas.FirstOrDefaultAsync(u => u.IdVacuna == id);
            return vacuna;

        }
        public async Task<Vacuna> GetVacunaByNombreVacunaAsync(string nombre)
        {
            var vacuna = await _context.Vacunas.FirstOrDefaultAsync(u => u.NombreVacuna == nombre);
            return vacuna;

        }
        
        //
        public async Task<Trabajador> GetTrabajadorByIdTrabajadorAsync(int id)
        {
            var trabajador = await _context.Trabajadores.FirstOrDefaultAsync(u => u.IdTrabajador == id);
            return trabajador;
        }
        public async Task<Trabajador> GetTrabajadorByNombreTrabajadorAsync(string nombre)
        {
            var trabajador = await _context.Trabajadores.FirstOrDefaultAsync(u => u.NombreTrabajador == nombre);
            return trabajador;
        }

        public async Task<IEnumerable<Trabajador>> GetTrabajadorAsync()
        {
            var trabajadores = await _context.Trabajadores.ToListAsync();
            return trabajadores;
        }
        
        //
        public async Task<Usuario> GetUsuarioByIdUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
            return usuario;
        }
        public async Task<Usuario> GetUsuarioByNombreUsuarioAsync(string nombre)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombre);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
        {
            var usuario = await _context.Usuarios.ToListAsync();
            return usuario;
        }

        //
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;

        }

       
    }
}
