using System.ComponentModel.DataAnnotations;

namespace EduApi.Models.Dto
{
    public class ReviewCreateDto
    {
        [Required, StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required, StringLength(250, MinimumLength = 1)]
        public string Text { get; set; }

        [Required]
        [Range(1, 10)]
        public int Digit { get; set; }

        [Required]
        public int MaterialId { get; set; }
    }
}