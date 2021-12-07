using System.ComponentModel.DataAnnotations;

namespace EduApi.Entities
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Text { get; set; }

        [Required]
        [Range(1, 10)]
        public int Digit { get; set; }


        public Material Material { get; set; }
        public int MaterialId { get; set; }
    }
}