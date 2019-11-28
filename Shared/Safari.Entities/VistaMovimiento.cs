using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class VistaMovimiento
    {
        [DisplayName("Fecha de Movimiento")]
        [Required]
        public DateTime FechaMovimiento { get; set; }
        [DisplayName("Monto")]
        [Required]
        public decimal Monto { get; set; }

    }
}
