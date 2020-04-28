using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Armors
    {
        [Key] public int ID { get; set; }
        public string Name { get; set; }
        public int ArmorPhysical { get; set; } = 0;
        public int ArmorMagical { get; set; } = 0;
        public string Special { get; set; } 
                
    }
}
