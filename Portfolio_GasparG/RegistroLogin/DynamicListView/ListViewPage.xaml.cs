using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Portfolio_GasparG.ViewModels;

namespace Portfolio_GasparG.RegistroLogin.DynamicListView
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
            BindingContext = new PersonViewModels();
        }

    }
}
