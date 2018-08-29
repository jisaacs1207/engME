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
            NavigationPage.SetHasNavigationBar(this, false);
            foreach (var x in _names)
            {
                x.ShortMeaning = "\"" + x.ShortMeaning + "\"";
            }

            OrderNames(_names);
            DisplayCollection(_names);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var SearchString = NameSearch.Text;
            repopulateNames();
            if (Methods.IsNullOrWhiteSpace(SearchString))
            {
                OrderNames(_names);
                DisplayCollection(_names);
            }
            else
            {
                foreach (var x in _names.ToList())
                {
                    if (!x.Name.StartsWith(SearchString)) _names.Remove(x);
                }
           
                OrderNames(_names);
                DisplayCollection(_names);
            }
        }

        private void repopulateNames()
        {
            _names = new ObservableCollection<NameObject>(App.NameList);
        }

        private static void OrderNames(ObservableCollection<NameObject> collection)
        {
            collection = new ObservableCollection<NameObject>(collection.OrderBy(x => x.Name));
        }

        private void DisplayCollection(ObservableCollection<NameObject> collection)
        {
            FullNamesList.ItemsSource = collection;
        }
    }
}




