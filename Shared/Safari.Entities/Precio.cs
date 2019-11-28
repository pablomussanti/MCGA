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

        [DisplayName("Tipo de Servicio")]
        [Required]
        public int TipoServicioId { get; set; }

        public TipoServicio TipoServicio { get; set; }

        [DisplayName("Fecha Desde")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime FechaDesde { get; set; }

        [DisplayName("Fecha Hasta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime FechaHasta { get; set; }

        [DisplayName("Valor")]
        [Required]
        public decimal Valor { get; set; }

    }
}
