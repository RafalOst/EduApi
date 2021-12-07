using System.ComponentModel.DataAnnotations;

namespace EduApi.Models.Dto
{
    public class MaterialTypeCreateDto
    {
        [Required, StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required, StringLength(250, MinimumLength = 1)]
        public string Definition { get; set; }
    }
}