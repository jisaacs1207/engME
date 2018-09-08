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
            repopulateNames();
            InitializeComponent();
            foreach (var x in _names) x.ShortMeaning = "\"" + x.ShortMeaning + "\"";
            _names = RemoveFiltered(_names);
            _names = Methods.OrderNames(_names);
            FullNamesList.ItemsSource = _names;
        }

        public static ObservableCollection<NameObject> _names { get; set; }
            = new ObservableCollection<NameObject>();

        public static ObservableCollection<NameObject> _namesMale { get; set; }
            = new ObservableCollection<NameObject>();

        public static ObservableCollection<NameObject> _namesFemale { get; set; }
            = new ObservableCollection<NameObject>();

        public static ObservableCollection<NameObject> _namesNotPopular { get; set; }
            = new ObservableCollection<NameObject>();

        public static ObservableCollection<NameObject> _namesNotSuggested { get; set; }
            = new ObservableCollection<NameObject>();

        public static ObservableCollection<NameObject> _namesConservative { get; set; }
            = new ObservableCollection<NameObject>();

        public static ObservableCollection<NameObject> _namesLiberal { get; set; }
            = new ObservableCollection<NameObject>();

        public static bool ShowMale { get; set; } = true;
        public static bool ShowFemale { get; set; } = true;
        public static bool ShowLiberal { get; set; } = true;
        public static bool ShowConservative { get; set; } = true;
        public static bool ShowOnlyPopular { get; set; } = true;
        public static bool ShowOnlySuggested { get; set; } = true;

        public static bool ShowFilters { get; set; }
        public static string SearchString { get; set; }

        private static object LastFocus { get; set; }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchString = NameSearch.Text;
            repopulateNames();
            if (Methods.IsNullOrWhiteSpace(SearchString))
            {
                _names = Methods.OrderNames(_names);
                _names = RemoveFiltered(_names);
                FullNamesList.ItemsSource = _names;
            }
            else
            {
                foreach (var x in _names.ToList())
                    if (!x.Name.StartsWith(SearchString))
                        _names.Remove(x);

                _names = Methods.OrderNames(_names);
                _names = RemoveFiltered(_names);
                FullNamesList.ItemsSource = _names;
            }
        }

        public static void repopulateNames()
        {
            _names = new ObservableCollection<NameObject>(App.NameList);
            foreach (var x in _names)
            {
                if (!x.Popular) _namesNotPopular.Add(x);
                if (x.Gender == "F") _namesFemale.Add(x);
                if (x.Gender == "M") _namesMale.Add(x);
                if (!x.Suggested) _namesNotSuggested.Add(x);
                if (x.Personality == 0) _namesConservative.Add(x);
                if (x.Personality == 2) _namesLiberal.Add(x);
            }

            _names = Methods.OrderNames(_names);
        }

        private async void FullNamesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var name = e.SelectedItem as NameObject;
            if (name == null) return;
            await Navigation.PushModalAsync(new FullInfoPage(name));
            FullNamesList.SelectedItem = null;
            LastFocus = e.SelectedItem;
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
            if (!Methods.IsNullOrWhiteSpace(YourNamePage.NameEntryVal))
            {
                var transliteration = Methods.Transliterate(YourNamePage.NameEntryVal[0].ToString());
                NameSearch.Text = transliteration;
                YourNamePage.NameEntryVal = null;
            }
            FullNamesList.ItemsSource = null;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(App.NameList);
            Methods.OrderNames(newNames);
            _names = RemoveFiltered(_names);

            ResetButtons();
            if (!Methods.IsNullOrWhiteSpace(SearchString))
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(SearchString))
                        newNames.Remove(x);
            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
            if (LastFocus != null)
            {
                FullNamesList.ScrollTo(LastFocus, ScrollToPosition.Center, true);
                LastFocus = null;
            }

            base.OnAppearing();
        }

        private void ShowMaleButton_OnClicked(object sender, EventArgs e)
        {
            ShowMale = ButtonSwitch(sender, ShowMale);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private void ShowFemaleButton_OnClicked(object sender, EventArgs e)
        {
            ShowFemale = ButtonSwitch(sender, ShowFemale);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private bool ButtonSwitch(object sender, bool buttonType)
        {
            var button = (Button) sender;
            var returnBool = true;

            if (!buttonType)
            {
                button.TextColor = Color.Default;
            }

            else if (buttonType)
            {
                returnBool = false;
                button.TextColor = Color.DarkRed;
            }

            return returnBool;
        }

        private void ResetButtons()
        {
            if (ShowMale) ShowMaleButton.TextColor = Color.Default;
            else ShowMaleButton.TextColor = Color.DarkRed;
            if (ShowFemale) ShowFemaleButton.TextColor = Color.Default;
            else ShowFemaleButton.TextColor = Color.DarkRed;
            if (ShowLiberal) ShowLiberalButton.TextColor = Color.Default;
            else ShowLiberalButton.TextColor = Color.DarkRed;
            if (ShowConservative) ShowConservativeButton.TextColor = Color.Default;
            else ShowConservativeButton.TextColor = Color.DarkRed;
            if (ShowOnlyPopular) ShowPopularButton.TextColor = Color.Default;
            else ShowPopularButton.TextColor = Color.DarkRed;
            if (ShowOnlySuggested) ShowSuggestedButton.TextColor = Color.Default;
            else ShowSuggestedButton.TextColor = Color.DarkRed;
        }

        private void ShowLiberalButton_OnClicked(object sender, EventArgs e)
        {
            ShowLiberal = ButtonSwitch(sender, ShowLiberal);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private void ShowConservativeButton_OnClicked(object sender, EventArgs e)
        {
            ShowConservative = ButtonSwitch(sender, ShowConservative);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private void ShowPopularButton_OnClicked(object sender, EventArgs e)
        {
            ShowOnlyPopular = ButtonSwitch(sender, ShowOnlyPopular);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private void ShowSuggestedButton_OnClicked(object sender, EventArgs e)
        {
            ShowOnlySuggested = ButtonSwitch(sender, ShowOnlySuggested);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private static ObservableCollection<NameObject> RemoveFiltered(IEnumerable<NameObject> toFilter)
        {
            var notAllowed = new List<NameObject>();
            if (!ShowMale) notAllowed.AddRange(_namesMale.ToList());
            if (!ShowFemale) notAllowed.AddRange(_namesFemale.ToList());
            if (!ShowConservative) notAllowed.AddRange(_namesConservative.ToList());
            if (!ShowLiberal) notAllowed.AddRange(_namesLiberal.ToList());
            if (ShowOnlyPopular) notAllowed.AddRange(_namesNotPopular.ToList());
            if (ShowOnlySuggested) notAllowed.AddRange(_namesNotSuggested.ToList());
            var noDupsNotAllowed = new HashSet<NameObject>(notAllowed).ToList();
            var filtered = toFilter.Except(noDupsNotAllowed.ToList());
            var returnedCollection = new ObservableCollection<NameObject>(filtered);
            return returnedCollection;
        }


        private void ShowFiltersButton_OnClicked(object sender, EventArgs e)
        {
            var button = (Button) sender;
            if (ShowFilters)
            {
                ShowFilters = false;
                FiltersGrid.IsVisible = false;
                button.Text = " ↓ Show Filters ↓ ";
            }
            else
            {
                ShowFilters = true;
                FiltersGrid.IsVisible = true;
                button.Text = " ↑ Hide Filters ↑ ";
            }
        }

        private void NameSearch_OnSearchButtonPressed(object sender, EventArgs e)
        {
            NameSearch.Unfocus();
            ;
        }
    }
}