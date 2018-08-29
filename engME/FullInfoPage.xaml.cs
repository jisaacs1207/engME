using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
