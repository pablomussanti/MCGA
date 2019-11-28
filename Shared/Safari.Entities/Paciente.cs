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

        [DisplayName("Cliente")]
        [Required]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Especie")]
        [Required]
        public int EspecieId { get; set; }

        public Especie Especie { get; set; }

        [DisplayName("Observacion")]
        [Required]
        public string Observacion { get; set; }

    }
}
