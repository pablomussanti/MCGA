using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public partial class Precio : EntityBase
    {

        [DisplayName("Id")]
        public override int Id { get; set; }

        [DisplayName("TipoServicioId")]
        [Required]
        public int TipoServicioId { get; set; }

        [DisplayName("FechaDesde")]
        [Required]
        public DateTime FechaDesde { get; set; }

        [DisplayName("FechaHasta")]
        [Required]
        public DateTime FechaHasta { get; set; }

        [DisplayName("Valor")]
        [Required]
        public decimal Valor { get; set; }

    }
}
