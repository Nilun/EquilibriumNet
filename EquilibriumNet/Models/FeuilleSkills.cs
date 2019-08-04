using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EquilibriumNet.Models
{
    public class FeuilleSkills
    {
        [Key] public int ID { get; set; }
      
        public int OneHand { get; set; }
        public int LOneHand { get; set; }
        public int TwoHand { get; set; }
        public int Throw { get; set; }
        public int Bow { get; set; }
        public int Body { get; set; }
        public int Parry { get; set; }

        public int Elem { get; set; }
        public int Occult { get; set; }
        public int Primordial { get; set; }
        public int Metamagic { get; set; }
        public int Infusion { get; set; }
        public int Resist { get; set; }
        public int MagicIdentif { get; set; }

        public int Stealth { get; set; }
        public int Survival { get; set; }
        public int Perception { get; set; }
        public int Speech { get; set; }
        public int History { get; set; }
        public int Medic { get; set; }
        public int Empath { get; set; }
        public int Athletism { get; set; }
        public int Acrobatics { get; set; }
        public int Craft { get; set; }
        public int Intimidation { get; set; }

        public int Brutality { get => TwoHand + Bow + Primordial + Athletism + Craft + Intimidation; }
        public int Swiftness { get => OneHand + Metamagic + MagicIdentif + Survival + Empath; }
        public int Spirit { get => Elem + Infusion+History+Medic;  }
        public int Malice { get=>LOneHand+Occult+Stealth+Speech;  }
        public int Vitality { get=>Parry+Body+Resist+Acrobatics; }
    }
}