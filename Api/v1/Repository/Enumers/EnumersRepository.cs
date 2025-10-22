using DNDApi.Api.v1.Contracts.Enumers;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities.Enumers;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Repository.Enumers
{
    public class EnumersRepository : IEnumersRepository
    {
        private readonly EnumersDbContext _context;

        public EnumersRepository(EnumersDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassEnumerEnity>> GetClassEnumersAsync()
        {
            return await _context.ClassEnumer.ToListAsync();
        }
        
        public async Task<List<RaceEnumerEnity>> GetRaceEnumersAsync()
        {
            return await _context.RaceEnumer.ToListAsync();
        }
    }
}