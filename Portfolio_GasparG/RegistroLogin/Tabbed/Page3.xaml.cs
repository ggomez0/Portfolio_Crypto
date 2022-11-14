using Portfolio_GasparG.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Portfolio_GasparG.RegistroLogin.Tabbed
{
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
