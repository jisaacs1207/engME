using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace engME
{
    public static class Methods
    {
        public static bool IsNullOrWhiteSpace(string value)
        {
            return value == null || value.All(char.IsWhiteSpace);
        }

        public static void AddNameToFavorites(string name)
        {
            var favoritesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favorites.txt");
            App.FavoriteList.Add(name);
            var json = JsonConvert.SerializeObject(App.FavoriteList);
            File.WriteAllText(favoritesFile, json);
            foreach(var n in App.NameList)
            {
                if(name==n.Name) n.Favorited = true;
            }
            YourFavoritesPage.populateFavorites();
            YourResultsPage.repopulateNames();
        }
        
        public static void RemoveNameFromFavorites(string name)
        {
            var favoritesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favorites.txt");
            App.FavoriteList.Remove(name);
            var json = JsonConvert.SerializeObject(App.FavoriteList);
            File.WriteAllText(favoritesFile, json);
            foreach (var x in App.NameList)
            {
                if (name == x.Name) x.Favorited = false;
            }
            YourFavoritesPage.populateFavorites();
            YourResultsPage.repopulateNames();
        }

        public static List<string> GetFavorites()
        {
            var favoritesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favorites.txt");
            var json = File.ReadAllText(favoritesFile);
            var names = JsonConvert.DeserializeObject<List<string>>(json);
            return names;
        }

        public static bool IsFavorited(string name)
        {
            
            var favorited = false;
            foreach (var x in App.FavoriteList)
            {
                if (x == name) favorited = true;
            }
            return favorited;
        }
        
        public static ObservableCollection<NameObject> OrderNames(ObservableCollection<NameObject> collection)
        {
            collection = new ObservableCollection<NameObject>(collection.OrderBy(x => x.Name));
            return collection;
        }
        
    }
}