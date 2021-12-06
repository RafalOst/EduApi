using System.ComponentModel.DataAnnotations;

namespace EduApi.Models.Dto
{
    public class AuthorUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}