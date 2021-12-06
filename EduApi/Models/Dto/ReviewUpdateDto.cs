using System.ComponentModel.DataAnnotations;

namespace EduApi.Models.Dto
{
    public class ReviewUpdateDto
    {
        public string Name { get; set; }
        public string Text { get; set; }

        [Range(1, 10)]
        public int Digit { get; set; }

    }
}