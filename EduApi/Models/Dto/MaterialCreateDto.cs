using System.ComponentModel.DataAnnotations;

namespace EduApi.Models.Dto
{
    public class MaterialCreateDto
    {
        [Required, StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }
        [Required, StringLength(250, MinimumLength = 1)]
        public string Description { get; set; }
        [Required, StringLength(250, MinimumLength = 1)]
        public string Location { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int MaterialTypeId { get; set; }
    }
}