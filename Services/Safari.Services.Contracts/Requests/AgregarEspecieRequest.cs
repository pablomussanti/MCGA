using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Requests
{
    [DataContract]
    public partial class AgregarEspecieRequest
    {
        [DataMember]
        public Especie Especie { get; set; }
    }
}
