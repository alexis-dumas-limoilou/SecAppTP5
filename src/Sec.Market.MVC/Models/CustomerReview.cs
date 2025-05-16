using System.ComponentModel.DataAnnotations;

namespace Sec.Market.MVC.Models
{
    public class CustomerReview
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [Display(Name ="Votre commentaire")]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Votre nom")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Votre email")]
        public string CustomerEmail { get; set; }
    }
}
