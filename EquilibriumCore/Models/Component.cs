using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
   
    public class Component
    {
      [Key]  public int ID { get; set; }

        public string name { get; set; }
        public Element Element { get; set; }
        public string PriceString { get ; set ; }
        public bool IsForm { get; set; }
        public int Range { get; set; }
        public int Area { get; set; }

        public string text { get; set; }

       
        public string valuesString { get ; set  ; }

        
         public string upgradesString { get ; set ; }

        

        [NotMapped] public string GlobalDescription { get => getFusedString(); }
        
   

        public string getFusedString()
        {
            string res = "";

           res = String.Format(text, valuesString.Split(";"));

            return res;
        }
    }
}
