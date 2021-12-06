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
    public class MaterialRepository : IMaterialRepository
    {
        private readonly EduDbContext _context;
        private readonly IMapper _mapper;

        public MaterialRepository(EduDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(MaterialCreateDto objectToCreate)
        {
            var materialModel = _mapper.Map<Material>(objectToCreate);
            await _context.AddAsync(materialModel);
            await _context.SaveChangesAsync();

            return materialModel.Id;
        }

        public async Task Delete(int id)
        {
            var materialToDelete = await _context
                .Materials
                .FirstOrDefaultAsync(i => i.Id == id);

            if (materialToDelete is null)
                throw new NotFoundException("Author not found");

            _context.Materials.Remove(materialToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MaterialDto>> GetAllDto()
        {
            var materials = await _context
                .Materials
                .Include(x => x.Reviews)
                .Include(x => x.Author)
                .Include(x => x.MaterialType)
                .ToListAsync();

            var materialsDto = _mapper.Map<List<MaterialDto>>(materials);

            return materialsDto;
        }

        public async Task<Material> GetObjectById(int id)
        {
            var material = await _context
                .Materials
                .Include(x => x.Reviews)
                .Include(x => x.Author)
                .Include(x => x.MaterialType)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (material is null)
                throw new NotFoundException("Material not found");

            return material;
        }

        public async Task<MaterialDto> GetSingleDto(int id)
        {
            var material = await _context
               .Materials
               .Include(x => x.Reviews)
               .Include(x => x.Author)
               .Include(x => x.MaterialType)
               .FirstOrDefaultAsync(i => i.Id == id);

            if (material is null)
                throw new NotFoundException("Material not found");

            var materialDto = _mapper.Map<MaterialDto>(material);

            return materialDto;
        }

        public async Task Update(Material materialToUpdate)
        {
            if (materialToUpdate is null)
                throw new NotFoundException("Material not found");

            _context.Materials.Update(materialToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
