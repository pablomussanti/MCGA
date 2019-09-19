using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public partial class Cita : EntityBase
    {

        [DisplayName("Id")]
        public override int Id { get; set; }

        [DisplayName("Fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [DisplayName("MedicoId")]
        [Required]
        public int MedicoId { get; set; }

        [DisplayName("PacienteId")]
        [Required]
        public int PacienteId { get; set; }

        [DisplayName("SalaId")]
        [Required]
        public int SalaId { get; set; }

        [DisplayName("TipoServicioId")]
        [Required]
        public int TipoServicioId { get; set; }

        [DisplayName("Estado")]
        [Required]
        public string Estado { get; set; }


    }
}
