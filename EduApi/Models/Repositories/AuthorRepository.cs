using AutoMapper;
using EduApi.Data;
using EduApi.Entities;
using EduApi.Exceptions;
using EduApi.Models.Dto;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Models.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly EduDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(EduDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(AuthorCreateDto objectToCreate)
        {
            var authorModel = _mapper.Map<Author>(objectToCreate);
            await _context.AddAsync(authorModel);
            await _context.SaveChangesAsync();

            return authorModel.Id;
        }

        public async Task Delete(int id)
        {
            var authorToDelete = await _context
                .Authors
                .FirstOrDefaultAsync(i => i.Id == id);

            if (authorToDelete is null)
                throw new NotFoundException("Author not found");

            _context.Authors.Remove(authorToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllDto()
        {
            var authors = await _context
                .Authors
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialType)
                .ToListAsync();

            var authorsDto = _mapper.Map<List<AuthorDto>>(authors);

            return authorsDto;
        }

        public async Task<Author> GetObjectById(int id)
        {
            var author = await _context
              .Authors
              .Include(_x => _x.Materials)
              .FirstOrDefaultAsync(i => i.Id == id);

            if (author is null)
                throw new NotFoundException("Author not found");

            return author;
        }

        public async Task<AuthorDto> GetSingleDto(int id)
        {
            var author = await _context
             .Authors
             .Include(i => i.Materials)
             .FirstOrDefaultAsync(i => i.Id == id);

            if (author is null)
                throw new NotFoundException("Author not found");

            var authorDto = _mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task Update(Author authorToUpdate)
        {
            if (authorToUpdate is null)
                throw new NotFoundException("Author not found");

            _context.Authors.Update(authorToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
