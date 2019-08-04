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
    }
}