using System;
using Xamarin.Forms;

namespace engME
{
    public partial class FullInfoPage : ContentPage
    {
        public FullInfoPage(NameObject name)
        {
            InitializeComponent();
            BindingContext = name;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }


        private void Favorite_OnClicked(object sender, EventArgs e)
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
    }
}