using EduApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduApi.Data
{
    public class EduSeeder
    {
        private readonly EduDbContext _context;
        public EduSeeder(EduDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Authors.Any())
                {
                    _context.Authors.AddRange(GetAuthors());
                    _context.SaveChanges();
                }
                if (!_context.MaterialTypes.Any())
                {
                    _context.MaterialTypes.AddRange(GetMaterialTypes());
                    _context.SaveChanges();
                }
                if (!_context.Materials.Any())
                {
                    _context.Materials.AddRange(GetMaterials());
                    _context.SaveChanges();
                }
                if (!_context.Reviews.Any())
                {
                    _context.Reviews.AddRange(GetReviews());
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Review> GetReviews()
        {
            List<Review> reviews = new()
            {
                new Review()
                {
                    Id = 1,
                    Name = "Bot",
                    Text = "Super",
                    Digit = 10,

                    MaterialId = 1
                }
            };
            return reviews;
        }

        private IEnumerable<Material> GetMaterials()
        {
            List<Material> materials = new() 
            { 
                new Material()
                {
                    Id = 1,
                    Title = "Intro to WebAPI - One of the most powerful project types in C#",
                    Description = "Author description: In this video, I will give you the overview of what WebAPI is, how to set it up, how to connect to it for testing, and then some tips and tricks as well before I show you how to deploy it.",
                    Location = "https://www.youtube.com/watch?v=vN9NRqv7xmY&t=528s",
                    PublishDate = DateTime.Now,

                    AuthorId = 1,
                    MaterialTypeId = 1
                }        
            };
            return materials;
        }

        private IEnumerable<MaterialType> GetMaterialTypes()
        {
            List<MaterialType> materialTypes = new()
            {
                new MaterialType()
                {
                    Id = 1,
                    Name = "Video Tutorial",
                    Definition = "Video tutorial is a video material that focuses mostly on guiding step-by-step in dedicated topic"
                },
                  new MaterialType()
                {
                    Id = 2,
                    Name = "Podcast Tutorial",
                    Definition = "Podcast Tutorial is a podcast material that focuses mostly on guiding step-by-step in dedicated topic"
                },
                new MaterialType()
                {
                    Id = 3,
                    Name = "Book",
                    Definition = "A book is a book, of course"
                },
                new MaterialType()
                {
                    Id = 4,
                    Name = "Educational portal",
                    Definition = "The Educational portal is a place where various types of courses are available"
                },

            };
            return materialTypes;
        }

        private IEnumerable<Author> GetAuthors()
        {
            List<Author> authors = new()
            {
                new Author()
                {
                    Id = 1,
                    Name = "Rafal",
                    Description = "Human"                    
                },

                new Author()
                {
                    Id = 2,
                    Name = "Shark",
                    Description = "Fish"
                }
            };
            return authors;
        }
    }
}
