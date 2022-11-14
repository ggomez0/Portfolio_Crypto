using System;
using System.Threading.Tasks;
using Portfolio_GasparG.ViewModels.ViewModelsCoin;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Portfolio_GasparG.ViewsCoin
{
    public partial class All_Portfolio_Coins : ContentPage
    {
        AllPortfolioViewModel ViewModel;
        int PortfolioID;
        string Portfolio_Name;
        AddCoin addCoin;
        AddTransaction addTransaction;
        Models.ModelsCoin.CoinsHodle CoinHodle;

        public All_Portfolio_Coins(AllPortfolioViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            this.BindingContext = ViewModel = new AllPortfolioViewModel();


          //  PopupNavigation.Instance.Popped += (sender, e) => UpdateView();     // event
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadPortfolio();

            Total.Text = "$" + ViewModel.Total.ToString();
        }


        private async void LoadPortfolio()
        {
            if (ViewModel.AllCoinsHodles.Count == 0)
              await ViewModel.ExecuteLoadPortfoliosCommand();
            ViewModel.ExecuteLoad_ALL_PortfolioCommand();
        }



        //void AddCoin(object sender, EventArgs e)
        //{
        //   _ = PopupNavigation.Instance.PushAsync(addCoin);
        //}







        void MainPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Portfolio_GasparG.RegistroLogin.Tabbed.MainPage());
        }

       

        void Alerts(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Alerts());
        }

        //void Settings(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new Settings());
        //}

        private void UpdateView()
        {
            ViewModel.ExecuteLoad_ALL_PortfolioCommand();
            Total.Text = "$" + ViewModel.Total.ToString();
        }

    }
}
