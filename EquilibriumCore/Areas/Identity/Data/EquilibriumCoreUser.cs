using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EquilibriumCore.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the EquilibriumCoreUser class
    public class EquilibriumCoreUser : IdentityUser
    {
        public EquilibriumCoreUser()
        {

        }
        public EquilibriumCoreUser(string userName):base(userName)
        {

        }
    }
}
