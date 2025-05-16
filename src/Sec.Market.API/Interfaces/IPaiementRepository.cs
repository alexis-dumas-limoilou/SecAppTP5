using Sec.Market.API.Entites;

namespace Sec.Market.API.Interfaces
{
    public interface IPaiementRepository
    {
        public Task InsertCard(Card card);

        public Task<Card?> GetCardByNumberAndUser(string cardNumber, string userId);
    }
}
