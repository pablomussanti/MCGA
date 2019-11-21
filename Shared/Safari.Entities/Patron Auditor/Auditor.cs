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
        public int CreatedBy { get; set; }


        [DisplayName("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; }


        [DisplayName("ChangedBy")]
        [Required]
        public int ChangedBy { get; set; }


        [DisplayName("ChangedDate")]
        [Required]
        public DateTime ChangedDate { get; set; }


        [DisplayName("DeleteBy")]
        [Required]
        public int DeleteBy { get; set; }

        [DisplayName("DeletedDate")]
        [Required]
        public DateTime DeletedDate { get; set; }

        [DisplayName("Deleted")]
        [Required]
        public Boolean Deleted { get; set; }


    }
}
