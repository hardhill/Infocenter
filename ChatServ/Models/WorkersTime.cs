using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServ.Models
{
    public class WorkersTime
    {
        public string Winlogin { get; set; }
        public string Fa { get; set; }
        public string Im { get; set; }
        public string Ot { get; set; }
        public DateTime WorkBegin { get; set; }
        public DateTime? WorkEnd { get; set; }
    }
}
