using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public enum Type { TwoHand , OneHand , ShortHand , Wizard , All}
    public enum SecondType {Sword,Axe,Mace, Dagger, Throwing, Bow, Other }
    public class Weapon
    {
       [Key] public int ID { get; set; }
        public String Name { get; set; }

        public Type TypeWeapon { get; set; }
        public SecondType SecondTypeWeapon { get;set;}

        public int NumberOfDice { get; set; }
        public int ValueMax { get; set; }

        public int Bonus { get; set; }
        public string Special { get; set; }
        public string Description { get; set; }
      

    }
}
