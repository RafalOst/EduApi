using System.Collections.Generic;

namespace EduApi.Models.Dto
{
    public class MaterialDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string PublishDate { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }

        public string Author { get; set; }
        public string MaterialType { get; set; }
    }
}