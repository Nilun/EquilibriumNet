using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;



namespace EquilibriumCore.Models
{
    public class Spell 
    {
        [Key]public int ID { get; set; }
        public Element Element { get; set; }
        public int IDForm { get; set; }
        public string listID { get; set; }
        [NotMapped] public List<Component> components { get; }
        public Spell()
        {
            
        }
    }
}