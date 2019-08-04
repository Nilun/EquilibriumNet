﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquilibriumCore.Models
{
    public class Rules
    {
        [Key] public int ID {get;set;}
       public string Category { get; set; }
        public bool IsTitle { get; set; }
        public string Text { get; set; }
    }
}
