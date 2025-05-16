namespace Sec.Market.MVC.Models
{
    public class OrderData
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string ShippingAdress { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardSecurityCode { get; set; }
        public string CardOwner { get; set; }
        public string CardType { get; set; }

        public Product Product;
      
    }
}
