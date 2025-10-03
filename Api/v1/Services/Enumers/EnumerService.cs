using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities.Enumers;
using Microsoft.EntityFrameworkCore; 

namespace DNDApi.Api.v1.Services.Enumers
{
    public class EnumerService
    {
        private readonly EnumersDbContext _context;

        public EnumerService(EnumersDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassEnumerEnity>> GetClassEnumers()
        {
            return await _context.ClassEnumer.ToListAsync();
        }

        public async Task<List<RaceEnumerEnity>> GetRaceEnumers()
        {
            return await _context.RaceEnumer.ToListAsync();
        }
    }
}