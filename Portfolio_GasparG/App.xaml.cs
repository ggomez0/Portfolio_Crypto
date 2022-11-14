using Portfolio_GasparG.Database;
using Portfolio_GasparG.ViewsCoin;
using Portfolio_GasparG.ServicesCoin;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Portfolio_GasparG.Models.ModelsCoin;

namespace Portfolio_GasparG
{
    public partial class App : Application
    {
        public static Repo Repository;
        //public static Repo_CoinsHodle CoinsHodle_Repository;
        public static CryptoRepository cryptoRepitory;

        #region Database
        static DatabaseQuerys database;

        public static DatabaseQuerys Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseQuerys(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBAPP.db"));
                }
                return database;
            }
        }
        #endregion
        public App()
        {
            InitializeComponent();
            //var Dc = new DataContext(dbPath);
            //cryptoRepitory = new CryptoRepository(Dc);
            MainPage = new NavigationPage(new Portfolio_GasparG.RegistroLogin.Tabbed.ContainerTabbedPage());
            NavigationPage.SetHasNavigationBar(this, false);
        }

       protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
