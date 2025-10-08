using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Exceptions;
using DNDApi.Api.v1.Models.Entities.Hero;
using DNDApi.Api.v1.Services;
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
        [Authorize]
        [Route("full_hero/{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);
            HeroEntity hero = await service.GetById(id, userId);

            if (hero == null)
            {
                throw new NotFoundException($"Герой с ID {id} не найден");
            }

            return Ok(new
                {
                    success = true,
                    data = hero
                });
        }
    }
}