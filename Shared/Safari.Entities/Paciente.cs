using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public partial class Paciente : EntityBase
    {

        [DisplayName("Id")]
        public override int Id { get; set; }

        [DisplayName("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        [DisplayName("FechaNacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("EspecieId")]
        [Required]
        public int EspecieId { get; set; }

        [DisplayName("Observacion")]
        [Required]
        public string Observacion { get; set; }

    }
}
