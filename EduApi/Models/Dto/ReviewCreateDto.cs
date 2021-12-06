using System.ComponentModel.DataAnnotations;

namespace EduApi.Models.Dto
{
    public class ReviewCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [Range(1, 10)]
        public int Digit { get; set; }

        [Required]
        public int MaterialId { get; set; }
    }
}