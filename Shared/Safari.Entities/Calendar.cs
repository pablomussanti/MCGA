using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Calendar
    {
        public int EventID { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public Boolean IsFullDay { get; set; }

    }
}
