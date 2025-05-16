using Sec.Market.API.Interfaces;
using Sec.Market.API.Entites;
using Sec.Market.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Sec.Market.API.Repository
{
    public class PaiementRepository : IPaiementRepository
    {
        private readonly MarketContext _context;
        public PaiementRepository(MarketContext context)
        {
            _context = context;
        }

       

        public async Task InsertCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public Task<Card?> GetCardByNumberAndUser(string cardNumber, string userId)
        {
            return _context.Cards.FromSqlRaw("SELECT * FROM Cards WHERE Number = '" + cardNumber + "' AND UserId = '" + userId + "'")
               .SingleOrDefaultAsync();
        }
    }
   
}
