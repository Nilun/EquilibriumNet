using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
   public enum Quality { Bad, Normal, Good }
    public class EquipementPosseder
    {
        [Key] public int ID { get; set; }
      public  Equipement BaseEquipement { get; set; }
        public FeuillePersonnage Personnage { get; set; }
       public Quality quality{ get; set; }
    public string info { get; set; }
    }
}
