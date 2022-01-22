using System.ComponentModel.DataAnnotations;

namespace TVA_Registro_de_Vacunados.Models
{
    public class Vacuna
    {
        [Key]
        public int IdVacuna { get; set; }
        public string NombreVacuna { get; set; }
        public string DosisVacuna { get; set; }
        public string LoteVacuna { get; set; }
        public string FechaVacuna { get; set; }
        
        
    }
}
