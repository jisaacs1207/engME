using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace engME
{
    public partial class YourFullNamesListPage : ContentPage
    {
        private ObservableCollection<NameObject> _names { get; set; } = App.NameList;

        public YourFullNamesListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            foreach (var x in _names)
            {
                x.ShortMeaning = "\"" + x.ShortMeaning + "\"";
            }

            _names = new ObservableCollection<NameObject>(_names.OrderBy(x => x.Name));
            FullNamesList.ItemsSource = _names;
        }
    }
}




