using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
   
    public class Component
    {
      [Key]  public int ID { get; set; }

        public string name { get; set; }
        public Element Element { get; set; }
        public Dictionary<Focus,int> Price { get; set; }
        public bool IsForm { get; set; }
        public int Range { get; set; }
        public int Area { get; set; }



    }
}
