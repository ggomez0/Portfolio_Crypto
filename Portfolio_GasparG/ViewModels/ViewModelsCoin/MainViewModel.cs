using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Portfolio_GasparG.ServicesCoin;
using Models.CoinMarketPortfolio;

namespace Portfolio_GasparG.ViewModels.ViewModelsCoin
{
    public class MainViewModel : ViewModelBase
    {

        private static System.Timers.Timer aTimer;
        public string Message { get; set; } = "default";

        bool PriceAccending = false;
        bool RankAccending = false;
        bool NameAccending = false;
        bool twentyFourAccending = false;
        bool sevendayAccending = false;

        public MainViewModel()
        {
            UpdatePrices();

            aTimer = new System.Timers.Timer(120000);  // every 120 seconds 2 min 
            Timer();
        }

        public void UpdatePrices()
        {
            var services = new CoinList();
            CoinmarketCap_Coins = services.GetCoinPrices().Result;
        }

        internal void SortByPrice()
        {
            if (PriceAccending)
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderBy(x => x.price).ToList();
                PriceAccending = false;
            }
            else
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderByDescending(x => x.price).ToList();
                PriceAccending = true;
            }
        }

        internal void SortByRank()
        {
            if (RankAccending)
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderBy(x => x.CoinMcapRank).ToList();
                RankAccending = false;
            }
            else
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderByDescending(x => x.CoinMcapRank).ToList();
                RankAccending = true;
            }
        }

        internal void SortByName()
        {
            if (NameAccending)
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderBy(x => x.name).ToList();
                NameAccending = false;
            }
            else
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderByDescending(x => x.name).ToList();
                NameAccending = true;
            }

        }

        internal void Sort24()
        {
            if (twentyFourAccending)
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderBy(x => x.PercentChange24hr).ToList();
                twentyFourAccending = false;
            }
            else
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderByDescending(x => x.PercentChange24hr).ToList();
                twentyFourAccending = true;
            }
        }

        internal void Sort7day()
        {
            if (sevendayAccending)
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderBy(x => x.PercentChange7day).ToList();
                sevendayAccending = false;
            }
            else
            {
                CoinmarketCap_Coins = coinmarketCap_Coins.OrderByDescending(x => x.PercentChange7day).ToList();
                sevendayAccending = true;
            }

        }

        internal string GetName(int ID)
        {
            string strName = CoinmarketCap_Coins.Where(x => x.CoinMcapRank == ID).SingleOrDefault()?.name;
            return strName;
        }



        private List<Coins> coinmarketCap_Coins;

        public List<Coins> CoinmarketCap_Coins
        {
            get { return coinmarketCap_Coins; }
            set { SetProperty(ref coinmarketCap_Coins, value); }
        }


        private void Timer()
        {
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            UpdatePrices();
        }


    }
}
