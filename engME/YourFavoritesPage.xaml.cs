using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace engME
{
    public partial class YourFavoritesPage : ContentPage
    {
        public static ObservableCollection<NameObject> _names { get; set; }
            = new ObservableCollection<NameObject>(App.NameList);
        public static ObservableCollection<NameObject> _favoritenames { get; set; }
            = new ObservableCollection<NameObject>();
        public YourFavoritesPage()
        {
            populateFavorites();
            InitializeComponent();
            FavoritedNameList.ItemsSource = _favoritenames;
        }

        private async Task FavoritedNameList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var name = e.SelectedItem as NameObject;
            if (name == null) return;
            await Navigation.PushModalAsync(new FullInfoPage(name));
            FavoritedNameList.SelectedItem = null;
        }

        private void FavoriteHeart_OnClicked(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var classId = button.ClassId;
            var favorited = Methods.IsFavorited(classId);

            if (favorited)
            {
                Methods.RemoveNameFromFavorites(classId);
                button.Image = "favorite.png";
                button.Opacity = .3;
                Console.WriteLine("Removed");
            }
            else
            {
                Methods.AddNameToFavorites(classId);
                button.Image = "favoritered.png";
                button.Opacity = 1;
                Console.WriteLine("Added");
            }
        }

        public static void populateFavorites()
        {
            _favoritenames.Clear();
            foreach (var x in _names)
            {
                var name = x.Name;
                foreach (var favoritename in App.FavoriteList)
                {
                    if(name==favoritename) _favoritenames.Add(x);
                }
            }
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FavoritedNameList.ItemsSource = null;
            FavoritedNameList.ItemsSource = _favoritenames;
        }
    }
}