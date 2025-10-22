using DNDApi.Api.v1.Contracts.Enumers;
using DNDApi.Api.v1.Models.Entities.Enumers;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnumersController : ControllerBase
    {
        private readonly IEnumersRepository _repository;

        public EnumersController(IEnumersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("class")]
        public async Task<IActionResult> GetClassEnumers()
        {
            List<ClassEnumerEnity> classEnumers = await _repository.GetClassEnumersAsync();
            return Ok(new
            {
                classEnumers
            });
        }

        [HttpGet]
        [Route("race")]
        public async Task<IActionResult> GetRaceEnumers()
        {
            List<RaceEnumerEnity> raceEnumers = await _repository.GetRaceEnumersAsync();
            return Ok(new
            {
                raceEnumers
            });
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllEnumers()
        {
            List<ClassEnumerEnity> classEnumers = await _repository.GetClassEnumersAsync();
            List<RaceEnumerEnity> raceEnumers = await _repository.GetRaceEnumersAsync();

            return Ok(new
            {
                classEnumers,
                raceEnumers
            });
        }
    }
}