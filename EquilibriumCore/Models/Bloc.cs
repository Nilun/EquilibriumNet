using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Bloc
    {
        [Key] public int ID { get; set; }
        public List<int> CompetencesID { get; set; } = new List<int>();
        public string Detail { get; set; }
        public string Tags { get; set; }
        public string Condition { get; set; }

    }
}
