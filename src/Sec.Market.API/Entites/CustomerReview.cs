namespace Sec.Market.API.Entites
{
    public class CustomerReview
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Comment { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }
    }
}
