using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Modification
    {
        [Key] public int ID { get; set; }
        public string Categorie { get; set; }
        public string SousCategorie { get; set; }
        public string TexteOld { get; set; }
        public string TexteNew { get; set; }
        public int? IDUpdate { get; set; }
      
        
    }
}
