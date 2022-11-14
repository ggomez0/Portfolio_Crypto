using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Portfolio_GasparG.ViewModels.ViewModelsCoin;

namespace Portfolio_GasparG.ViewsCoin
{
    public partial class Alertify 
    {
        public string Message { get; set; }
        public Alertify(string strMessage)
        {
            InitializeComponent();
            Message = strMessage;
            asdf.Text = Message;
        }
    }
}