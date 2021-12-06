using System.Collections.Generic;

namespace EduApi.Entities
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}