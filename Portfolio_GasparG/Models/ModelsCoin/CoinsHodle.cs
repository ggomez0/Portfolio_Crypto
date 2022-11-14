using System;
using System.Collections.Generic;

namespace Portfolio_GasparG.Models.ModelsCoin
{
    public class CoinsHodle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public Portfolio Portfolio { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
