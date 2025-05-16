using System.ComponentModel.DataAnnotations;

namespace Sec.Market.MVC.Models
{
    public class Product
    {
        [Display(Name="Identifiant")]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Prix")]
        public int Price { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }
        

    }
}
