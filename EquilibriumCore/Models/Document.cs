using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Document
    {
        [Key] public int ID { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public string type { get; set; }

    }
}
