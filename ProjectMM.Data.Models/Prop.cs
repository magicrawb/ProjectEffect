using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMM.Data.Models
{
    public class Prop
    {
        [Key]
        public int PropId { get; set; }
        public string PropName { get; set; }
    }
}
