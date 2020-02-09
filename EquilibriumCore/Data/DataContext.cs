using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

using Microsoft.EntityFrameworkCore;
using EquilibriumCore.Models;

namespace EquilibriumCore.Data
{
    public class DataContext:DbContext 
    {
        public DbSet<Models.FeuillePersonnage> Feuilles { get; set; }
        public DataContext (DbContextOptions<DataContext> val):base(val)
        {
            
        }
        public DbSet<EquilibriumCore.Models.Rules> Rules { get; set; }
        public DbSet<EquilibriumCore.Models.Component> Component { get; set; }
        public DbSet<EquilibriumCore.Models.Partie> Partie { get; set; }
        public DbSet<EquilibriumCore.Models.Spell> Spell { get; set; }
        public DbSet<EquilibriumCore.Models.SpellLinkComponent> SpellLinkComponent { get; set; }
        public DbSet<EquilibriumCore.Models.Tooltiper> Tooltiper { get; set; }
        public DbSet<EquilibriumCore.Models.Skills> Skills { get; set; }
        public DbSet<EquilibriumCore.Models.Document> Documents { get; set; }
        public DbSet<EquilibriumCore.Models.Update> Update { get; set; }
        public DbSet<EquilibriumCore.Models.Modification> Modification { get; set; }
        public DbSet<EquilibriumCore.Models.Equipement> Equipement { get; set; }

    }
}