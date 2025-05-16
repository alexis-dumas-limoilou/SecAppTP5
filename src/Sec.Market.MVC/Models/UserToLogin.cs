using System.ComponentModel.DataAnnotations;

namespace Sec.Market.MVC.Models
{
    public class UserToLogin
    {
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

    }
}
