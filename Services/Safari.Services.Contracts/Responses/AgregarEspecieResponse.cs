﻿using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Responses
{
    [DataContract]
    public partial class AgregarEspecieResponse
    {
        [DataMember]
        public Especie Result { get; set; }
    }
}
