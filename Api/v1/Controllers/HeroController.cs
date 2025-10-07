using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Models.Entities.Hero;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService service;


        public HeroController(IHeroService service)
        {
            this.service = service;
        }

        [HttpGet]
        // [Authorize]
        [Route("hero/{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            try
            {
                HeroEntity hero = await service.GetById(id);
                return Ok(new
                {
                    success = true,
                    data = hero
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
    }
}