using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Entities.Patron_Auditor;

namespace Safari.Entities
{
    public partial class Cita : Auditor 
    {


        [DisplayName("Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Fecha { get; set; }

        [DisplayName("Medico")]
        [Required]
        public int MedicoId { get; set; }

        public Medico Medico { get; set; }

        [DisplayName("Paciente")]
        [Required]
        public int PacienteId { get; set; }

        public Paciente Paciente { get; set; }

        [DisplayName("Sala")]
        [Required]
        public int SalaId { get; set; }

        public Sala Sala { get; set; }

        [DisplayName("Tipo del Servicio")]
        [Required]
        public int TipoServicioId { get; set; }

        public TipoServicio TipoServicio { get; set; }

        [DisplayName("Estado")]
        [Required]
        public string Estado { get; set; }


    }
}
