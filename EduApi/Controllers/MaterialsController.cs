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
using AutoMapper;
using EduApi.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace EduApi.Controllers
{
    /// <summary>
    /// Materials API controller offers GET, POST, PATCH, DELETE request methods
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialRepository _materialsRepository;
        private readonly IMapper _mapper;

        public MaterialsController(IMaterialRepository context, IMapper mapper)
        {
            _materialsRepository = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method returns all materials
        /// </summary>
        /// <returns>Returns list of MaterialsDto's</returns>
        /// <response code="200">Returns dtos for all materials in databse</response>

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetMaterials()
        {
            return Ok(await _materialsRepository.GetAllDto());
        }

        /// <summary>
        /// GET method return material specified by id
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns>Returns specified MaterialDto</returns>
        /// <response code="200">Returns specifed material's dto</response>

        // GET: api/Materials/5
        [HttpGet("{materialId}")]
        public async Task<ActionResult<MaterialDto>> GetMaterial(int materialId)
        {
            return Ok(await _materialsRepository.GetSingleDto(materialId));
        }

        /// <summary>
        /// PATCH method partial update of specifed material
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="patchDoc"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Todo
        ///     [
        ///       {
        ///         "op":"replace",
        ///         "path":"/Title",
        ///         "value": "Everything for dummies"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/Description",
        ///         "value": "Tutorial for dummies"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/Location",
        ///         "value": "Internet"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/AuthorId",
        ///         "value": "1"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/MaterialTypeId",
        ///         "value": "3"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>

        // PATCH: api/Materials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{materialId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PatchMaterial(int materialId, [FromBody] JsonPatchDocument<MateriaUpdatelDto> patchDoc)
        {
            var materialToUpdate = await _materialsRepository.GetObjectById(materialId);

            MateriaUpdatelDto materialToPathDto = _mapper.Map<MateriaUpdatelDto>(materialToUpdate);


            patchDoc.ApplyTo(materialToPathDto, ModelState);
            if (!TryValidateModel(materialToPathDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(materialToPathDto, materialToUpdate);
            await _materialsRepository.Update(materialToUpdate);

            return NoContent();
        }

        /// <summary>
        /// POST method add new Material to database
        /// </summary>
        /// <param name="materialCreatedDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Title": "C# for Dummies",
        ///        "Description": "All you need to know for start",
        ///        "Location": "Nowhere, Kansas-USA.",
        ///        "AuthorId": 1,
        ///        "MaterialTypeId": 3     
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new material</response>

        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostMaterial(MaterialCreateDto materialCreatedDto)
        {
            int newMaterialId = await _materialsRepository.Add(materialCreatedDto);
            return Created($"/materials/{newMaterialId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed material from database
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns>Return 204 NoContent</returns>
        /// <response code="204">Returns no content</response>

        // DELETE: api/Materials/5
        [HttpDelete("{materialId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMaterial(int materialId)
        {
            await _materialsRepository.Delete(materialId);
            return NoContent();
        }
    }
}
