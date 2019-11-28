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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Fecha { get; set; }

        [DisplayName("Cliente")]
        [Required]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [DisplayName("Tipo de Movimiento")]
        [Required]
        public int TipoMovimientoId { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }

        [DisplayName("Valor")]
        [Required]
        public decimal Valor { get; set; }


    }
}
