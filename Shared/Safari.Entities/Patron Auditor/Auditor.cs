using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities.Patron_Auditor
{
    public class Auditor : EntityBase
    {
        [DisplayName("Id")]
        public override int Id { get; set; }

        [DisplayName("CreatedBy")]
        [Required]
        public string CreatedBy { get; set; }


        [DisplayName("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; }


        [DisplayName("ChangedBy")]
        [Required]
        public string ChangedBy { get; set; }


        [DisplayName("ChangedDate")]
        [Required]
        public DateTime ChangedDate { get; set; }


        [DisplayName("DeleteBy")]
        [Required]
        public string DeleteBy { get; set; }

        [DisplayName("DeletedDate")]
        [Required]
        public DateTime DeletedDate { get; set; }

        [DisplayName("Deleted")]
        [Required]
        public Boolean Deleted { get; set; }


    }
}
