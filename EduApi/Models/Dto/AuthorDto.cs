using System.Collections.Generic;

namespace EduApi.Models.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<MaterialDto> Materials { get; set; }
        public int PublishedMaterials { get; set; }
    }
}