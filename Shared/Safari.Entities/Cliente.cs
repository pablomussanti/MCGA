using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public partial class Cliente : EntityBase
    {

        [DataMember]
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        [Required]
        public string Apellido { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Telefono")]
        [Required]
        public string Telefono { get; set; }

        [DisplayName("Url")]
        public string Url { get; set; }

        [DisplayName("FechaNacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Domicilio")]
        [Required]
        public string Domicilio { get; set; }
    }
}
