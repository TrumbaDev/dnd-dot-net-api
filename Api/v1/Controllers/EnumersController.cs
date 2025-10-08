using DNDApi.Api.v1.Models.Entities.Enumers;
using DNDApi.Api.v1.Services.Enumers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnumersController : ControllerBase
    {
        private readonly EnumerService _service;

        public EnumersController(EnumerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("class")]
        public async Task<IActionResult> GetClassEnumers()
        {
            try
            {
                List<ClassEnumerEnity> classEnumers = await _service.GetClassEnumers();
                return Ok(new
                {
                    success = true,
                    data = classEnumers
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error durring authentication",
                    error = ex.Message,
                    details = ex.InnerException?.Message
                });
            }
        }

        [HttpGet]
        [Route("race")]
        public async Task<IActionResult> GetRaceEnumers()
        {
            List<RaceEnumerEnity> raceEnumers = await _service.GetRaceEnumers();
            return Ok(new
            {
                success = true,
                data = raceEnumers
            });
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllEnumers()
        {
            List<ClassEnumerEnity> classEnumers = await _service.GetClassEnumers();
            List<RaceEnumerEnity> raceEnumers = await _service.GetRaceEnumers();

            return Ok(new
            {
                classEnumers,
                raceEnumers
            });
        }
    }
}