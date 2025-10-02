using System.ComponentModel.DataAnnotations;

namespace DNDApi.Api.v1.DTO.AuthDTO
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}