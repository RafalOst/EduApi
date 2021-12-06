using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduApi.Data;
using EduApi.Entities;

namespace EduApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypesController : ControllerBase
    {
        private readonly EduDbContext _context;

        public MaterialTypesController(EduDbContext context)
        {
            _context = context;
        }

        // GET: api/MaterialTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialType>>> GetMaterialTypes()
        {
            return await _context.MaterialTypes.ToListAsync();
        }

        // GET: api/MaterialTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialType>> GetMaterialType(int id)
        {
            var materialType = await _context.MaterialTypes.FindAsync(id);

            if (materialType == null)
            {
                return NotFound();
            }

            return materialType;
        }

        // PUT: api/MaterialTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialType(int id, MaterialType materialType)
        {
            if (id != materialType.Id)
            {
                return BadRequest();
            }

            _context.Entry(materialType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialTypeExists(id))
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

        // POST: api/MaterialTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaterialType>> PostMaterialType(MaterialType materialType)
        {
            _context.MaterialTypes.Add(materialType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialType", new { id = materialType.Id }, materialType);
        }

        // DELETE: api/MaterialTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialType(int id)
        {
            var materialType = await _context.MaterialTypes.FindAsync(id);
            if (materialType == null)
            {
                return NotFound();
            }

            _context.MaterialTypes.Remove(materialType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialTypeExists(int id)
        {
            return _context.MaterialTypes.Any(e => e.Id == id);
        }
    }
}
