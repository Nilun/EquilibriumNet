using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquilibriumCore.Data;
using EquilibriumCore.Models;

namespace EquilibriumCore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeuillePersonnagesController : ControllerBase
    {
        private readonly DataContext _context;

        public FeuillePersonnagesController(DataContext context)
        {
            _context = context;
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<FeuillePersonnage>> GetFeuillePersonnage(int id)
        {
            var feuillePersonnage = await _context.Feuilles.FindAsync(id);

            if (feuillePersonnage == null)
            {
                return NotFound();
            }

            return feuillePersonnage;
        }

       
        private bool FeuillePersonnageExists(int id)
        {
            return _context.Feuilles.Any(e => e.ID == id);
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class FeuillePersonnagesJoueurController : ControllerBase
    {
        private readonly DataContext _context;

        public FeuillePersonnagesJoueurController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FeuillePersonnage>>> GetFeuillesPersonnages(string id)
        {
            var feuillePersonnage = await _context.Feuilles.Where(f=>f.Creator == id).ToListAsync();

            if (feuillePersonnage == null)
            {
                return NotFound();
            }

            return feuillePersonnage;
        }
        //public async Task<ActionResult<IEnumerable<FeuillePersonnage>>> GetFeuilles()
        //{
        //    return await _context.Feuilles.ToListAsync();
        //}

        private bool FeuillePersonnageExists(int id)
        {
            return _context.Feuilles.Any(e => e.ID == id);
        }
    }
}
