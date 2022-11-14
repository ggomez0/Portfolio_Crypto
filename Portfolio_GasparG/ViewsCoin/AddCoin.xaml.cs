using System;
using Portfolio_GasparG.ViewModels.ViewModelsCoin;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Portfolio_GasparG.ViewsCoin
{
    public partial class AddCoin
     { 
        PortfolioViewModel PortfolioViewModel;
        MainViewModel coins;
        String SelectedCoin_name;
        Models.ModelsCoin.Portfolio Portfolio;
        Models.ModelsCoin.CoinsHodle CoinHodle;

        Models.ModelsCoin.CoinsHodle newCoin = new Models.ModelsCoin.CoinsHodle();
        bool blnAlready_Exists;

        public AddCoin(PortfolioViewModel ViewModel, int portfolioID)
        {
            InitializeComponent();

            coins = new MainViewModel();
            this.BindingContext = coins;
            PortfolioViewModel = ViewModel;
            Portfolio = PortfolioViewModel.GetPortfolio(portfolioID);          // gets the portfolio

        }


        void Cancel(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }

        void Ok(object sender, System.EventArgs e)
        {


            try
            {

                //PortfolioViewModel
       

               if (!PortfolioViewModel.Coin_Exists_In_Portfolio(Portfolio, SelectedCoin_name))                  // Check if coin exist in Portfolio
               {
                    Console.WriteLine(SelectedCoin_name);

                    CoinHodle = new Models.ModelsCoin.CoinsHodle();

                    CoinHodle.Id = PortfolioViewModel.getNewCoinHodle_ID();
                    CoinHodle.Name = SelectedCoin_name;
                    CoinHodle.Portfolio = Portfolio;
                    PortfolioViewModel.AddCoinHodleToPortfolio(CoinHodle, Portfolio);


               }
               else
               {
                    // notification saying coin already exists
                    PortfolioViewModel.ShowError(SelectedCoin_name + " Already Exist");
               }

  

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
      
            PopupNavigation.Instance.PopAsync(true);
        }




        private void Coin_Selected(object sender, ItemTappedEventArgs e)
        {

            try
            {
                var myItem = e.Item;
                foreach (var item in coins.CoinmarketCap_Coins)
                {
                    if (myItem == item)
                    {
                        SelectedCoin_name = item.name;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
              
        }


    }
}
