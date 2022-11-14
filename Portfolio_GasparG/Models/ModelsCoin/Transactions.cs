using System;

namespace Portfolio_GasparG.Models.ModelsCoin
{
    public class Transactions
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal AmountBuy { get; set; }
        public decimal AmountSell { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal PriceBought { get; set; }
        public virtual CoinsHodle CoinsHodle { get; set; }
    }
}
