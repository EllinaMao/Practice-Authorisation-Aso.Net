using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public record PersonViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public Role Role{ get; set; } = new Role(RoleType.User.ToString());

    }
}
