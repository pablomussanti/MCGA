﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public partial class TipoMovimiento : EntityBase
    {


        [DisplayName("Id")]
        public override int Id { get; set; }


        [DisplayName("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Multiplicador")]
        [Required]
        public int Multiplicador { get; set; }


    }
}
