using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduApi.Entities
{
    public class Material
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime PublishDate { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public MaterialType MaterialType { get; set; }
        public int MaterialTypeId { get; set; }
    }
}