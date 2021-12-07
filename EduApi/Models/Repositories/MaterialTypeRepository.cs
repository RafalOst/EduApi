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
    public class MaterialTypeRepository : IMaterialTypeRepository
    {
        private readonly EduDbContext _context;
        private readonly IMapper _mapper;

        public MaterialTypeRepository(EduDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(MaterialTypeCreateDto objectToCreate)
        {
            var materialTypeModel = _mapper.Map<MaterialType>(objectToCreate);
            await _context.AddAsync(materialTypeModel);
            await _context.SaveChangesAsync();

            return materialTypeModel.Id;
        }

        public async Task Delete(int id)
        {
            var materialTypeToDelete = await _context
               .MaterialTypes
               .FirstOrDefaultAsync(i => i.Id == id);

            if (materialTypeToDelete is null)
                throw new NotFoundException("Material Type not found");

            _context.MaterialTypes.Remove(materialTypeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MaterialTypeDto>> GetAllDto()
        {
            var materialType = await _context
               .MaterialTypes
               .ToListAsync();

            var materialsTypeDto = _mapper.Map<List<MaterialTypeDto>>(materialType);

            return materialsTypeDto;
        }

        public async Task<MaterialType> GetObjectById(int id)
        {
            var materialType = await _context
              .MaterialTypes
              .Include(_x => _x.Materials)
              .FirstOrDefaultAsync(i => i.Id == id);

            if (materialType is null)
                throw new NotFoundException("Material Type not found");

            return materialType;
        }

        public async Task<MaterialTypeDto> GetSingleDto(int id)
        {
            var materialType = await _context
             .MaterialTypes
             .Include(_x => _x.Materials)
                .ThenInclude(x => x.Author)
             .Include(_x => _x.Materials)
                .ThenInclude(x => x.Reviews)
             .FirstOrDefaultAsync(i => i.Id == id);

            if (materialType is null)
                throw new NotFoundException("Material Type not found");

            var materialTypeDto = _mapper.Map<MaterialTypeDto>(materialType);

            return materialTypeDto;
        }

        public async Task Update(MaterialType materialTypeToUpdate)
        {
            if (materialTypeToUpdate is null)
                throw new NotFoundException("Material Type not found");

            _context.MaterialTypes.Update(materialTypeToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
