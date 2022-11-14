using System;
using System.Collections.Generic;
using Portfolio_GasparG.ViewModels.ViewModelsCoin;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Portfolio_GasparG.ViewsCoin
{
    public partial class NewPortfolio 
    {
        PortfolioViewModel viewModel;
        Models.ModelsCoin.Portfolio newPortfolio = new Models.ModelsCoin.Portfolio();
        bool blnAlready_Exists;
        public string Portfolio_Name { get; set; }

        public NewPortfolio(PortfolioViewModel ViewModel)
        {
            viewModel = ViewModel;
            InitializeComponent();
            blnAlready_Exists = false;
        }

        void Ok(object sender, System.EventArgs e)
        {
            Portfolio_Name = PortfolioValue.Text;


            if (!viewModel.Name_Exists(PortfolioValue.Text))
            {
                blnAlready_Exists = false;
                newPortfolio.PortfolioName = PortfolioValue.Text;
                newPortfolio.PortfolioID = viewModel.getNewPortfolio_ID();
                //MessagingCenter.Send(this, "AddItem", newPortfolio);
                viewModel.AddPortfolio(newPortfolio);
                PortfolioValue.Text = "";
                PopupNavigation.Instance.PopAsync(true);
            }
            else
            {
                blnAlready_Exists = true;
                PortfolioValue.Text = "";
                PopupNavigation.Instance.PopAsync(true);              
            }

        }

        void Cancel(object sender, System.EventArgs e)
        {
            blnAlready_Exists = false;
            PopupNavigation.Instance.PopAsync(true);
        }

        public bool Already_Exists()
        {
            return blnAlready_Exists;
        }

    }

}