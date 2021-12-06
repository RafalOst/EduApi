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
using EduApi.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace EduApi.Controllers
{
    /// <summary>
    /// Author API controller offers GET, POST, PATCH, DELETE request methods
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository context, IMapper mapper)
        {
            _authorRepository = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method returns all authors
        /// </summary>
        /// <returns>Returns list of AutorsDto's</returns>
        /// <response code="200">Returns dtos for all autors in databse</response>

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            return Ok(await _authorRepository.GetAllDto());
        }

        /// <summary>
        /// GET method return autor specified by id
        /// </summary>
        /// <param name="autorId"></param>
        /// <returns>Returns specified AutorDto</returns>
        /// <response code="200">Returns specifed autors's dto</response>

        // GET: api/Author/5
        [HttpGet("{autorId}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int autorId)
        {
            return Ok(await _authorRepository.GetSingleDto(autorId));
        }

        /// <summary>
        /// PATCH method partial update of specifed author
        /// </summary>
        /// <param name="authorId"></param>
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
        ///         "value": "Franek"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/Description",
        ///         "value": "Fast"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>

        // PATCH: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{authorId:int}")]
        public async Task<ActionResult> UpdateAuthor(int authorId,[FromBody] JsonPatchDocument<AuthorUpdateDto> patchDoc)
        {

            var authorToUpdate = await _authorRepository.GetObjectById(authorId);

            AuthorUpdateDto authorToPathDto = _mapper.Map<AuthorUpdateDto>(authorToUpdate);


            patchDoc.ApplyTo(authorToPathDto, ModelState);
            if (!TryValidateModel(authorToPathDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(authorToPathDto, authorToUpdate);
            await _authorRepository.Update(authorToUpdate);

            return NoContent();
        }

        /// <summary>
        /// POST method add new Author to database
        /// </summary>
        /// <param name="authorCreatedDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Name": "Bob"
        ///        "Description": "Hamster"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new author</response>

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostAuthor(AuthorCreateDto authorCreatedDto)
        {
            int newAuthorId = await _authorRepository.Add(authorCreatedDto);
            return Created($"/author/{newAuthorId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed author from database
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Return 204 NoContent</returns>
        /// <response code="204">Returns no content</response>

        // DELETE: api/Author/5
        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int authorId)
        {
            await _authorRepository.Delete(authorId);
            return NoContent();
        }
    }
}
