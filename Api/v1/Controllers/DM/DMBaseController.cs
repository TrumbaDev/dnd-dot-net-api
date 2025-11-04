using DNDApi.Api.v1.Filters;
using DNDApi.Api.v1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers.DM
{
    [ApiController]
    [Authorize]
    [DmAuthorization]
    public abstract class DMBaseController: ControllerBase
    {
        protected int GetCurrentUserId()
        {
            return JwtService.GetUserIdFromPrincipal(User);
        }
    }
}