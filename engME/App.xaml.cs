using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace engME
{
    public partial class App : Application
    {
        public static List<string> FavoriteNames {get; set;} = new List<string>();
        
        public App()
        {
            InitializeComponent();
            Methods.FillNameDictionary();
            var favoritesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favorites.txt");
            if (!File.Exists(favoritesFile))
            {
                Methods.AddNameToFavorites("Placeholder");
                Methods.RemoveNameFromFavorites("Placeholder");
            }
            FavoriteNames = Methods.GetFavorites();
            MainPage = new MainPage();
        }
                
        public static ObservableCollection<NameObject> NameList { get; set; } = new ObservableCollection<NameObject>();

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