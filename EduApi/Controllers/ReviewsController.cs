using AutoMapper;
using EduApi.Entities;
using EduApi.Models.Dto;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers
{
    /// <summary>
    /// Reviews API controller offers GET, POST, PATCH, DELETE request methods
    /// </summary>
    [Route("api/Materials/{materialId:int}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewRepository context, IMapper mapper)
        {
            _reviewRepository = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method returns all reviews for specifed materials
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns>Returns list of ReviewDto's</returns>
        /// <response code="200">Returns dtos for all reviews for specifed materials</response>

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews([FromRoute] int materialId)
        {
            return Ok(await _reviewRepository.GetAllDto(materialId));
        }

        /// <summary>
        /// GET method return review specified by id  for specifed materials
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="reviewId"></param>
        /// <returns>Returns specified ReviewDto</returns>
        /// <response code="200">Returns specifed review's dto</response>

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReview([FromRoute] int materialId, [FromRoute] int reviewId)
        {
            return Ok(await _reviewRepository.GetSingleDto(materialId, reviewId));
        }

        /// <summary>
        /// PATCH method partial update of specifed review
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="reviewId"></param>
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
        ///         "path":"/Text",
        ///         "value": "superrr"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/Digit",
        ///         //[Range(1, 10)]
        ///         "value": "5"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>

        // PATCH: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{reviewId:int}")]
        public async Task<ActionResult> PatchReview([FromRoute] int materialId, [FromRoute] int reviewId, [FromBody] JsonPatchDocument<ReviewUpdateDto> patchDoc)
        {
            var reviewToUpdate = await _reviewRepository.GetObjectById(materialId, reviewId);

            ReviewUpdateDto reviewToPathDto = _mapper.Map<ReviewUpdateDto>(reviewToUpdate);


            patchDoc.ApplyTo(reviewToPathDto, ModelState);
            if (!TryValidateModel(reviewToPathDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(reviewToPathDto, reviewToUpdate);
            await _reviewRepository.Update(reviewToUpdate);

            return NoContent();
        }

        /// <summary>
        /// POST method add new Review to material in database
        /// </summary>
        /// <param name="reviewCreatedDto"></param>
        /// <param name="materialId"></param>
        /// <returns>Return endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Name": "Ziutek"
        ///        "Text": "Perfect"
        ///        //[Range(1, 10)]
        ///        "Digit": "7" 
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new review</response>

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(ReviewCreateDto reviewCreatedDto, [FromRoute] int materialId)
        {
            int newReviewId = await _reviewRepository.Add(reviewCreatedDto, materialId);
            return Created($"/materials/{materialId}/Review{newReviewId}", null);
        }

        /// <summary>
        /// DELETE method delete review specified by id  for specifed materials
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="reviewId"></param>
        /// <returns>Return 204 NoContent</returns>
        /// <response code="204">Returns no content</response>

        // DELETE: api/Reviews/5
        [HttpDelete("{reviewId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReview([FromRoute] int materialId, [FromRoute] int reviewId)
        {
            await _reviewRepository.Delete(materialId, reviewId);
            return NoContent();
        }
    }
}
