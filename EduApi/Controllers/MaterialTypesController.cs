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

namespace EduApi.Controllers
{
    /// <summary>
    /// Author API controller offers GET, POST, PATCH, DELETE request methods
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypesController : ControllerBase
    {
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly IMapper _mapper;

        public MaterialTypesController(IMaterialTypeRepository context, IMapper mapper)
        {
            _materialTypeRepository = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method returns all material types
        /// </summary>
        /// <returns>Returns list of MaterialTypeDto's</returns>
        /// <response code="200">Returns dtos for all material type in databse</response>

        // GET: api/MaterialTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialTypeDto>>> GetMaterialTypes()
        {
            return Ok(await _materialTypeRepository.GetAllDto());
        }

        /// <summary>
        /// GET method return material type specified by id
        /// </summary>
        /// <param name="materialTypeId"></param>
        /// <returns>Returns specified MaterialTypeDto</returns>
        /// <response code="200">Returns specifed materials type's dto</response>

        // GET: api/MaterialTypes/5
        [HttpGet("{materialTypeId}")]
        public async Task<ActionResult<MaterialTypeDto>> GetMaterialType(int materialTypeId)
        {
            return Ok(await _materialTypeRepository.GetSingleDto(materialTypeId));
        }

        /// <summary>
        /// PATCH method partial update of specifed material type
        /// </summary>
        /// <param name="materialTypeId"></param>
        /// <param name="patchDoc"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Todo
        ///     [
        ///       {
        ///         "op":"replace",
        ///         "path":"/Name",
        ///         "value": "Book"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/Definition",
        ///         "value": "A book is a book, of course"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>

        // PATCH: api/MaterialTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{materialTypeId:int}")]
        public async Task<ActionResult> UpdateMaterialType(int materialTypeId, [FromBody] JsonPatchDocument<MaterialTypeUpdateDto> patchDoc)
        {
            var materialTypeToUpdate = await _materialTypeRepository.GetObjectById(materialTypeId);

            MaterialTypeUpdateDto materialTypeToPathDto = _mapper.Map<MaterialTypeUpdateDto>(materialTypeToUpdate);


            patchDoc.ApplyTo(materialTypeToPathDto, ModelState);
            if (!TryValidateModel(materialTypeToPathDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(materialTypeToPathDto, materialTypeToUpdate);
            await _materialTypeRepository.Update(materialTypeToUpdate);

            return NoContent();
        }

        /// <summary>
        /// POST method add new Material Type to database
        /// </summary>
        /// <param name="materialTypeCreatedDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Name": "Book",
        ///        "Definition": "A book is a book, of course"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new material type</response>

        // POST: api/MaterialTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostMaterialType(MaterialTypeCreateDto materialTypeCreatedDto)
        {
            int newMaterialTypeId = await _materialTypeRepository.Add(materialTypeCreatedDto);
            return Created($"/MaterialType/{newMaterialTypeId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed material type from database
        /// </summary>
        /// <param name="materialTypeId"></param>
        /// <returns>Return 204 NoContent</returns>
        /// <response code="204">Returns no content</response>

        // DELETE: api/MaterialTypes/5
        [HttpDelete("{materialTypeId}")]
        public async Task<IActionResult> DeleteMaterialType([FromRoute] int materialTypeId)
        {
            await _materialTypeRepository.Delete(materialTypeId);
            return NoContent();
        }
    }
}
