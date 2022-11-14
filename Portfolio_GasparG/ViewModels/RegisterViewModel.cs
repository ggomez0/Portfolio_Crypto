using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Portfolio_GasparG.ModelsCoin;
using Portfolio_GasparG.RegistroLogin;
using System.Collections.Generic;

namespace Portfolio_GasparG.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string email;
        public string password;
        public string name;
        public string age;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public string NameTxt
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public string AgeTxt
        {
            get { return this.age; }
            set { SetValue(ref this.age, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }

        }

        private async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error","Debe introducir un correo.","OK");
                return;
            }
            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error","You must enter a password.","Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a name.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.age))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an age.",
                    "Accept");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;


            var user = new UserModel
            {
                EmailField = email,
                PasswordField = password,
                NamesField = name,
                AgeField = age,
                Creation_Date = DateTime.Now,
            };


            List<UserModel> e = App.Database.GetUsersValidate(email, password).Result;

            if (e.Count == 0)
            {
                await App.Database.SaveUserModelAsync(user);
                await Application.Current.MainPage.DisplayAlert("Successfully", "Welcome " + name.ToString() + " to your app", "Ok");

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;

                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else if (e.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error", "Ya existe una cuenta con este correo " + email.ToString(), "Ok");
            }   
        }

        public RegisterViewModel()
        {
            IsEnabledTxt = true;
        }
    }
}
