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
    public class SkillsController : ControllerBase
    {
        private readonly DataContext _context;

        public SkillsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Skills
        [HttpGet]
        public IEnumerable<Skills> GetSkills()
        {
            return _context.Skills;
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skills = await _context.Skills.FindAsync(id);

            if (skills == null)
            {
                return NotFound();
            }

            return Ok(skills);
        }

        // PUT: api/Skills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkills([FromRoute] int id, [FromBody] Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != skills.ID)
            {
                return BadRequest();
            }
            
            _context.Entry(skills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Skills
        [HttpPost]
        public async Task<IActionResult> PostSkills([FromBody] Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(SkillsExists(skills.Name))
            {
                var entry = _context.Skills.First((a) => a.Name == skills.Name);
                int id = entry.ID;
                    skills.ID = id;
                _context.Entry(entry).State = EntityState.Detached;
                
                return await PutSkills(id, skills);
            }else
            {
                _context.Skills.Add(skills);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSkills", new { id = skills.ID }, skills);
            }          
            
            
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skills = await _context.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();

            return Ok(skills);
        }

        private bool SkillsExists(int id)
        {
            return _context.Skills.Any(e => e.ID == id);
        }
        private bool SkillsExists(string name)
        {
            return _context.Skills.Any(e => e.Name == name);
        }
    }
}