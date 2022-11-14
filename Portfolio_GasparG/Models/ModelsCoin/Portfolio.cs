using System;
using System.Collections.Generic;

namespace Portfolio_GasparG.Models.ModelsCoin
{
    public class Portfolio
    {
        public int PortfolioID { get; set; }
        public string PortfolioName { get; set; }
        public virtual ICollection<CoinsHodle> coinsHodle { get; set; }
    }
}
