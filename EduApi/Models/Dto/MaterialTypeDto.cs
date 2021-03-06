using System.Collections.Generic;

namespace EduApi.Models.Dto
{
    public class MaterialTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public IEnumerable<MaterialDto> Materials { get; set; }
    }
}