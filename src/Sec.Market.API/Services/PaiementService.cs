using Sec.Market.API.Entites;
using Sec.Market.API.Interfaces;
using Stripe.Checkout;

namespace Sec.Market.API.Services
{
    public class PaiementService : IPaiementService
    {

        
        public bool Pay(Card card)
        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    Price = "{{PRICE_ID}}",
                    Quantity = 1,
                  },
                },
                Mode = "payment",
               
            };
            var service = new SessionService();
            
            //Session session = service.Create(options);

            return true;
        }
    }
}
