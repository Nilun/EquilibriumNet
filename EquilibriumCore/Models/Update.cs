using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Update
    {
        [Key] public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Sortie { get; set; }
        [NotMapped] public List<Modification> modifications  { get; set; }
        public Update()
        {
            modifications = new List<Modification>();
        }
    }
}
