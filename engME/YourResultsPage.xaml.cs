using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace engME
{
    public partial class YourResultsPage : ContentPage
    {
        private ObservableCollection<NameObject> _names { get; set; }
            = new ObservableCollection<NameObject>(App.NameList);

        public YourResultsPage()
        {
            InitializeComponent();
            
            foreach (var x in _names)
            {
                x.ShortMeaning = "\"" + x.ShortMeaning + "\"";
            }

            _names=OrderNames(_names);
            DisplayCollection(_names);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var SearchString = NameSearch.Text;
            repopulateNames();
            if (Methods.IsNullOrWhiteSpace(SearchString))
            {
                _names=OrderNames(_names);
                DisplayCollection(_names);
            }
            else
            {
                foreach (var x in _names.ToList())
                {
                    if (!x.Name.StartsWith(SearchString)) _names.Remove(x);
                }
           
                _names=OrderNames(_names);
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
    }
}




