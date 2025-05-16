namespace Sec.Market.API.Entites
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public string ShippingAdress { get; set; }
        public User User { get; set; }

        public Product Product { get; set; }
    }
}
