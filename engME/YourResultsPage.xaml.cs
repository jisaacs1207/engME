using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace engME
{
    public partial class YourResultsPage : ContentPage
    {
        public static ObservableCollection<NameObject> _names { get; set; }
            = new ObservableCollection<NameObject>();
        
        public YourResultsPage()
        {
            repopulateNames();
            InitializeComponent();

            foreach (var x in _names) x.ShortMeaning = "\"" + x.ShortMeaning + "\"";
            _names = Methods.OrderNames(_names);
            FullNamesList.ItemsSource = _names;
        }

        

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchString = NameSearch.Text;
            repopulateNames();
            if (Methods.IsNullOrWhiteSpace(searchString))
            {
                _names = Methods.OrderNames(_names);
                FullNamesList.ItemsSource = _names;
            }
            else
            {
                foreach (var x in _names.ToList())
                    if (!x.Name.StartsWith(searchString))
                        _names.Remove(x);

                _names = Methods.OrderNames(_names);
                FullNamesList.ItemsSource = _names;
            }
        }

        public static void repopulateNames()
        {    

            _names= new ObservableCollection<NameObject>(App.NameList);
    
            _names=Methods.OrderNames(_names);

        }

        private async void FullNamesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var name = e.SelectedItem as NameObject;
            if (name == null) return;
            await Navigation.PushModalAsync(new FullInfoPage(name));
            FullNamesList.SelectedItem = null;
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
            }
            else
            {
                Methods.AddNameToFavorites(classId);
                button.Image = "favoritered.png";
                button.Opacity = 1;
            }
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FullNamesList.ItemsSource = null;
            FullNamesList.ItemsSource = _names;
        }
    }
    
}