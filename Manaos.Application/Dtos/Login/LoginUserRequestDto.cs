using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Login
{
    public class LoginUserRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
