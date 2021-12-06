using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduApi.Entities
{
    public class MaterialType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Definition { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}