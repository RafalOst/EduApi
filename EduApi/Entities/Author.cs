﻿using System.Collections.Generic;
using System.Linq;

namespace EduApi.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public int Counter { get { return Materials.Count(); } }        
    }
}