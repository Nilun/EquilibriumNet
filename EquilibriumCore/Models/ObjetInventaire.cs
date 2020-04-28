using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public enum TypeObject { Consomable,Arme,Armure,Autre }
    public class ObjetInventaire
    {
        [Key] public int ID { get; set; }
        public int ItemSourceID { get; set; }
        public int CharacterID { get; set; }

        public string Detail { get; set; }
        public bool Equiper { get; set; } = false;

        public TypeObject TypeObjectIn { get; set; }


    }
}
