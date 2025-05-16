using Sec.Market.API.Entites;

namespace Sec.Market.API.Interfaces
{
    public interface IPaiementService
    {
        public bool Pay(Card card);
    }
}
