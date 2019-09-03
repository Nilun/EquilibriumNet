using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Partie
    {
        [Key] public int ID { get; set; }
        public string Name { get; set; }
        public string MJ { get; set; }
        public string Joueurs { get; set; }

    }
}
