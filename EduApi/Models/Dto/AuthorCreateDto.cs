using System.ComponentModel.DataAnnotations;

namespace EduApi.Models.Dto
{
    public class AuthorCreateDto
    {
        [Required, StringLength(30, MinimumLength = 1), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; }
        [Required, StringLength(250, MinimumLength = 1), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Description { get; set; }
    }
}