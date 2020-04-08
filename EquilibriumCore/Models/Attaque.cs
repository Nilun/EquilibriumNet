using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Attaque
    {
        [Key] public int ID { get; set; }

        public string name { get; set; }
        public int Portée { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int User { get; set; }
        

    }
}
