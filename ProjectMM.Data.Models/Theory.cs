using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMM.Data.Models
{
    public class Theory
    {
        [Key]
        public int TheoryId { get; set; }
        public string TheoryName { get; set; }
        public string TheoryDescription { get; set; }
    }
}
