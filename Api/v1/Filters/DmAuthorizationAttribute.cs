using DNDApi.Api.v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace DNDApi.Api.v1.Filters
{
    public class DmAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                bool isDm = JwtService.GetUserIsDmFromPrincipal(context.HttpContext.User);

                if (!isDm)
                {
                    context.Result = new ObjectResult(new { message = "Только DM имеет доступ к этому ресурсу" })
                    {
                        StatusCode = 403
                    };
                }
            }
            catch (SecurityTokenException ex)
            {
                context.Result = new BadRequestObjectResult(new { message = ex.Message });
            }
        }
    }
}