using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.DTO.HeroDTO;
using DNDApi.Api.v1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _service;


        public HeroController(IHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("full-hero/{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);

            return Ok(new
            {
                hero = _service.GetById(id, userId)
            });
        }

        [HttpGet]
        [Authorize]
        [Route("full-heroes")]
        public async Task<IActionResult> GetHeroes()
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);
            
            return Ok(new
            {
                heroes = await _service.GetHeroesAsync(userId)
            });
        }
    }
}