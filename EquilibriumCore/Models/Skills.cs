using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Skills
    {
        [Key] public int ID { get; set; }
        public string superCat { get; set; }
        public string cat { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public int levelMax { get; set; }
        public string Tags { get; set; }
    
        public Skills()
        {
            this.superCat = "";
            this.cat = "";
            Name = "";
            Effect = "";
            this.levelMax = 0;
            Tags = "";
        }
        public Skills(string superCat, string cat, string name, string effect, int levelMax)
        {
            this.superCat = superCat;
            this.cat = cat;
            Name = name;
            Effect = effect;
            this.levelMax = levelMax;
            Tags = "";
        }
    }
}
