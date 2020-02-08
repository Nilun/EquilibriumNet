using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Tooltiper
    {
       [Key] public int ID { get; set; }
        public string keyword { get; set; }
        public string tooltiptext { get; set; }

        public string getString ()
        {
            return "<div class='tooltip' style='opacity: 1'>" + keyword +" <span class='tooltiptext'>" + tooltiptext +" </span></div>";
        }

    }
}
