using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace engME
{
    public partial class YourResultsPage : ContentPage
    {
        public YourResultsPage()
        {
            InitializeComponent();
            foreach (var x in _names) x.ShortMeaning = "\"" + x.ShortMeaning + "\"";
            _names = OrderNames(_names);
            DisplayCollection(_names);
            
        }

        private ObservableCollection<NameObject> _names { get; set; }
            = new ObservableCollection<NameObject>(App.NameList);

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var SearchString = NameSearch.Text;
            repopulateNames();
            if (Methods.IsNullOrWhiteSpace(SearchString))
            {
                _names = OrderNames(_names);
                DisplayCollection(_names);
            }
            else
            {
                foreach (var x in _names.ToList())
                    if (!x.Name.StartsWith(SearchString))
                        _names.Remove(x);

                _names = OrderNames(_names);
                DisplayCollection(_names);
            }
        }

        private void repopulateNames()
        {
            _names = new ObservableCollection<NameObject>(App.NameList);
        }

        private static ObservableCollection<NameObject> OrderNames(ObservableCollection<NameObject> collection)
        {
            collection = new ObservableCollection<NameObject>(collection.OrderBy(x => x.Name));
            return collection;
        }

        private void DisplayCollection(ObservableCollection<NameObject> collection)
        {
            FullNamesList.ItemsSource = collection;
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
            Console.WriteLine(favorited.ToString());
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
    }
}