using AutoMapper;
using TVA_Registro_de_Vacunados.DTO;
using TVA_Registro_de_Vacunados.Models;

namespace TVA_Registro_de_Vacunados.Mappers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {

            //PARA EL POST
            CreateMap<CreaVacunaDTO, Vacuna>();
            CreateMap<CreaTrabajadorDTO, Trabajador>();
            //PARA EL PUT
            CreateMap<ActulizaVacunaDTO, Vacuna>();
            CreateMap<ActulizaTrabajadorDTO, Trabajador>();
            //PARA EL GET
            CreateMap<Vacuna, MuestraVacunaDTO>();
            CreateMap<Trabajador, MuestraTrabajadorDTO>();

            //PARA LOS REGISTROS Y LOGINS DE USUARIO
            CreateMap<UsuarioRegistroDTO, Usuario>();
            CreateMap<UsuarioLoginDTO, Usuario>();
            CreateMap<Usuario, UsuarioListDTO>();
        }


    }
}
