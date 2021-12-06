using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EduApi.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}
