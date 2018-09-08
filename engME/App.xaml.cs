using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace engME
{
    public partial class App : Application
    {
        public App()
        {
            Names.FillNameDictionary();
            FavoriteList = Methods.GetFavorites();
            foreach (var x in NameList)
            {
                var name = x.Name;

                foreach (var favoritename in FavoriteList)
                    if (favoritename == name)
                        x.Favorited = true;
            }

            InitializeComponent();

            MainPage = new MainPage();
        }

        public static ObservableCollection<NameObject> NameList { get; set; } = new ObservableCollection<NameObject>();
        public static List<string> FavoriteList { get; set; } = new List<string>();

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}