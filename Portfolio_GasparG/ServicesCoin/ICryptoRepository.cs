using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio_GasparG.Models.ModelsCoin;

namespace Portfolio_GasparG.ServicesCoin
{
    public interface ICryptoRepository
        {
            Task<bool> AddPortfolioAsync(Portfolio item);
            Task<bool> UpdatePortfolioAsync(Portfolio item);
            Task<bool> DeletePortfolioAsync(int id);
            Task<Portfolio> GetPortfolioAsync(string id);
            Task<IEnumerable<Portfolio>> GetPortfoliosAsync(bool forceRefresh = false);

            Task<bool> AddCoinsHodleAsync(CoinsHodle item);
            Task<bool> UpdateCoinsHodleAsync(CoinsHodle item);
            Task<bool> DeleteCoinsHodleAsync(int id);
            Task<CoinsHodle> GetCoinsHodleAsync(string id);
            Task<IEnumerable<CoinsHodle>> GetCoinsHodlesAsync(bool forceRefresh = false);

            Task<bool> AddTransactionAsync(Transactions transactions);
            Task<IEnumerable<Transactions>> GetTransactionsAsync(bool forceRefresh = false);

    }

}
