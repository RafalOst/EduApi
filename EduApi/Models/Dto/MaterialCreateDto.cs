using System;

namespace EduApi.Models.Dto
{
    public class MaterialCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }
        public int MaterialTypeId { get; set; }
    }
}