namespace Sec.Market.MVC.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Owner { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }


        public User User { get; set; }  

    }
}
