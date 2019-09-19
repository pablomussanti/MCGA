using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public partial class Movimiento : EntityBase
    {
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DisplayName("Fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [DisplayName("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        [DisplayName("TipoMovimientoId")]
        [Required]
        public int TipoMovimientoId { get; set; }

        [DisplayName("Valor")]
        [Required]
        public double Valor { get; set; }


    }
}
