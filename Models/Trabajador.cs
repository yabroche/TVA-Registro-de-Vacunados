using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TVA_Registro_de_Vacunados.Models
{
    public class Trabajador
    {   [Key]
        public int IdTrabajador { get; set; }
        public string NombreTrabajador { get; set; }
        public string ApellidosTrabajador { get; set; }
        public string EdadTrabajador { get; set; }
        public string CarneITrabajador { get; set; }
        public string DepartamentoTrabajador { get; set; }
       

    }
}
