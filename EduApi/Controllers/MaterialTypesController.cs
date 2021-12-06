using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduApi.Data;
using EduApi.Entities;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;

namespace EduApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypesController : ControllerBase
    {
        private readonly IMaterialTypeRepository _context;

        public MaterialTypesController(IMaterialTypeRepository context)
        {
            _context = context;
        }

        // GET: api/MaterialTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialType>>> GetMaterialTypes()
        {
            return NoContent();
        }

        // GET: api/MaterialTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialType>> GetMaterialType(int id)
        {
            return NoContent();
        }

        // PUT: api/MaterialTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialType(int id, MaterialType materialType)
        {
            return NoContent();
        }

        // POST: api/MaterialTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaterialType>> PostMaterialType(MaterialType materialType)
        {
            return NoContent();
        }

        // DELETE: api/MaterialTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialType(int id)
        {
            return NoContent();
        }
    }
}
