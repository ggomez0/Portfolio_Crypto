using Portfolio_GasparG.ViewModels.ViewModelsCoin;
using Portfolio_GasparG.ViewsCoin;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Portfolio_GasparG.RegistroLogin.Tabbed
{
    public partial class Portfolio : ContentPage
    {

        PortfolioViewModel viewModel;
        AllPortfolioViewModel viewModel_AllPortfolio;
        NewPortfolio newPortfolio;
        bool blnErrorShown;


        public Portfolio()
        {
            InitializeComponent();


            this.BindingContext = viewModel = new PortfolioViewModel();
            newPortfolio = new NewPortfolio(viewModel);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Portfolios.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void showAddPortfolio(object o, EventArgs e)
        {
            blnErrorShown = false;
            await PopupNavigation.Instance.PushAsync(newPortfolio);
        }

        private async void ShowError()
        {
            if (newPortfolio.Already_Exists() && blnErrorShown == false)
            {
                await PopupNavigation.Instance.PushAsync(new Alertify(newPortfolio.Portfolio_Name + " Already Exist"));
                blnErrorShown = true;

                System.Threading.Thread.Sleep(700);
                await PopupNavigation.Instance.PopAsync(true);
            }
        }

        private async void Delete(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                var imt = (Grid)button.Parent;
                var c1 = (Label)imt.Children[0];
                var name = c1.Text;

                Models.ModelsCoin.Portfolio portfolio = viewModel.GetPortfolio(viewModel.GetPortfolioID(name));

                await viewModel.Delete_PortfolioAsync(portfolio);
                viewModel.ExecuteLoadPortfoliosCommandAsync();

                // MessagingCenter.Send(this, "Delete", portfolio); // need to sort this
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new Alertify("Error - " + ex.ToString()));
                System.Threading.Thread.Sleep(700);
                await PopupNavigation.Instance.PopAsync(true);
            }
        }

        private async void View(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                var imt = (Grid)button.Parent;
                var c1 = (Label)imt.Children[0];
                var name = c1.Text;
                var id = viewModel.GetPortfolioID(name);

                _ = Navigation.PushModalAsync(new Portfolio_Coins(name, id, viewModel));
            }
            catch (Exception ex)
            {
                await PopupNavigation.Instance.PushAsync(new Alertify("Error - " + ex.ToString()));
                System.Threading.Thread.Sleep(700);
                await PopupNavigation.Instance.PopAsync(true);
            }
        }

        private async void showAllPortfolio(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new All_Portfolio_Coins(viewModel_AllPortfolio));
        }
    }
}
