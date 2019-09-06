using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class SpellLinkComponent
    {
        [Key] public int ID { get; set; }
        public Spell Spell { get; set; }
       public Component Component { get; set; }
    }
}
