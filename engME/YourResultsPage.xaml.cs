﻿using System;
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

        private static bool ShowMale { get; set; } = true;
        private static bool ShowFemale { get; set; } = true;
        private static bool ShowLiberal { get; set; } = true;
        private static bool ShowConservative { get; set; } = true;
        private static bool ShowPopular { get; set; } = true;
        private static bool ShowSuggested { get; set; } = true;
        
        public YourResultsPage()
        {
            repopulateNames();
            InitializeComponent();
            foreach (var x in _names) x.ShortMeaning = "\"" + x.ShortMeaning + "\"";
            _names = RemoveFiltered(_names);
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
                _names = RemoveFiltered(_names);
                FullNamesList.ItemsSource = _names;
            }
            else
            {
                foreach (var x in _names.ToList())
                    if (!x.Name.StartsWith(searchString))
                        _names.Remove(x);

                _names = Methods.OrderNames(_names);
                _names = RemoveFiltered(_names);
                FullNamesList.ItemsSource = _names;
            }
        }

        public static void repopulateNames()
        {    
            
            _names= new ObservableCollection<NameObject>(App.NameList);
            foreach (var x in _names)
            {
                if(!x.Popular) _namesNotPopular.Add(x);
                if(x.Gender=="F") _namesFemale.Add(x);
                if(x.Gender=="M") _namesMale.Add(x);
                if(!x.Suggested) _namesNotSuggested.Add(x);
                if(x.Personality ==0) _namesConservative.Add(x);
                if(x.Personality==2) _namesLiberal.Add(x);
            }
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
            
            FullNamesList.ItemsSource = null;
            Methods.OrderNames(_names);
            _names = RemoveFiltered(_names);
            FullNamesList.ItemsSource = _names;
            ResetButtons();
            base.OnAppearing();
        }

        private void ShowMaleButton_OnClicked(object sender, EventArgs e)
        {
            ShowMale = ButtonSwitch(sender, ShowMale);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
            {
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);
            }

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
            {
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);
            }

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
                button.BackgroundColor = Color.FromHex("#e6f2ff");
                button.TextColor = Color.Default;
            }

            else if (buttonType)
            {
                returnBool = false;     
                button.BackgroundColor = Color.Default;
                button.TextColor = Color.Default;
                
            }
            return returnBool;
        }

        private void ResetButtons()
        {
            if (ShowMale)
            {
                ShowMaleButton.BackgroundColor = Color.FromHex("#e6f2ff");
                ShowMaleButton.TextColor = Color.Default;
            }
            if (ShowFemale)
            {
                ShowFemaleButton.BackgroundColor = Color.FromHex("#e6f2ff");
                ShowFemaleButton.TextColor = Color.Default;
            }
            if (ShowLiberal)
            {
                ShowLiberalButton.BackgroundColor = Color.FromHex("#e6f2ff");
                ShowLiberalButton.TextColor = Color.Default;
            }
            if (ShowConservative)
            {
                ShowConservativeButton.BackgroundColor = Color.FromHex("#e6f2ff");
                ShowConservativeButton.TextColor = Color.Default;
            }
            if (ShowPopular)
            {
                ShowPopularButton.BackgroundColor = Color.FromHex("#e6f2ff");
                ShowPopularButton.TextColor = Color.Default;
            }
            if (ShowSuggested)
            {
                ShowSuggestedButton.BackgroundColor = Color.FromHex("#e6f2ff");
                ShowSuggestedButton.TextColor = Color.Default;
            }
        }

        private void ShowLiberalButton_OnClicked(object sender, EventArgs e)
        {
            ShowLiberal = ButtonSwitch(sender, ShowLiberal);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
            {
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);
            }

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
            {
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);
            }

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private void ShowPopularButton_OnClicked(object sender, EventArgs e)
        {
            ShowPopular = ButtonSwitch(sender, ShowPopular);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
            {
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);
            }

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }

        private void ShowSuggestedButton_OnClicked(object sender, EventArgs e)
        {
            ShowSuggested = ButtonSwitch(sender, ShowSuggested);
            var searchString = NameSearch.Text;
            repopulateNames();
            var newNames = new ObservableCollection<NameObject>(_names);
            if (!Methods.IsNullOrWhiteSpace(searchString))
            {
                foreach (var x in newNames.ToList())
                    if (!x.Name.StartsWith(searchString))
                        newNames.Remove(x);
            }

            newNames = new ObservableCollection<NameObject>(RemoveFiltered(newNames));
            newNames = new ObservableCollection<NameObject>(Methods.OrderNames(newNames));
            FullNamesList.ItemsSource = newNames;
        }
        private static ObservableCollection<NameObject> RemoveFiltered(IEnumerable<NameObject> toFilter)
        {
            var notAllowed = new List<NameObject>();
            if(!ShowMale){ notAllowed.AddRange(_namesMale.ToList());}
            if(!ShowFemale) notAllowed.AddRange(_namesFemale.ToList());
            if(!ShowConservative) notAllowed.AddRange(_namesConservative.ToList());
            if(!ShowLiberal) notAllowed.AddRange(_namesLiberal.ToList());
            if(!ShowPopular) notAllowed.AddRange(_namesNotPopular.ToList());
            if(!ShowSuggested) notAllowed.AddRange(_namesNotSuggested.ToList());
            var noDupsNotAllowed = new HashSet<NameObject>(notAllowed).ToList();
            var filtered =  toFilter.Except(noDupsNotAllowed.ToList());
            var returnedCollection = new ObservableCollection<NameObject>(filtered);
            return  returnedCollection;
        }
    }
    
}