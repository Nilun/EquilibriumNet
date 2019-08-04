using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity;

namespace EquilibriumNet.Data
{
    public class DataContext:DbContext 
    {
        public DbSet<Models.FeuillePersonnage> Feuilles { get; set; }

        public System.Data.Entity.DbSet<EquilibriumNet.Models.FeuilleSkills> FeuilleSkills { get; set; }
    }
}