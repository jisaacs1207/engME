using System;
using Xamarin.Forms;

/*
 * <ContentPage.Padding>
        <OnPlatform x:TypeArguments="Thickness"
                    iOS="0,40,0,0" />
    </ContentPage.Padding>*/
namespace engME
{
    public partial class YourNamePage : ContentPage
    {
        public static bool SuggestedSwitchVal { get; set; } = true;
        public static bool PopularSwitchVal { get; set; } = true;
        public static string NameEntryVal { get; set; } = null;
        
        public YourNamePage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            var entry = NameEntry;
            var text = entry.Text;
        }

        private void Popular_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Should I Choose a Popular Name?",
                "In the culture of which these names come from, it is often preferred to have a more popular name.\n\nHaving an unpopular name can be disadvantageous.\n\nThis is the opposite of most Asian cultures!",
                "Thanks!");
        }

        private void Suggested_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("What Are Suggested Names?",
                "Suggested names are simply suggestions for non-natives choosing an English name.\n\nThis is based on a neutral feeling to the name with no negative connotations.\n\nIt also means the name is likely easy to spell and say.",
                "Got it!");
        }

        private void SuggestedSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            if (SuggestedSwitchVal)
            {
                SuggestedSwitchVal = false;
                YourResultsPage.ShowOnlySuggested = false;
            }
            else if (!SuggestedSwitchVal)
            {
                SuggestedSwitchVal = true;
                YourResultsPage.ShowOnlySuggested = true;
            }
        }

        private void PopularSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            if (PopularSwitchVal)
            {
                PopularSwitchVal = false;
                YourResultsPage.ShowOnlyPopular = false;
            }
            else if (!PopularSwitchVal)
            {
                PopularSwitchVal = true;
                YourResultsPage.ShowOnlyPopular = true;
            }
        }

        private void GenderPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker) sender;
            var selected = picker.SelectedItem.ToString();
            switch (selected)
            {
                case "Female":
                    YourResultsPage.ShowFemale = true;
                    YourResultsPage.ShowMale = false;
                    break;
                case "Male":
                    YourResultsPage.ShowFemale = false;
                    YourResultsPage.ShowMale = true;
                    break;
                case "Androgynous":
                    YourResultsPage.ShowFemale = false;
                    YourResultsPage.ShowMale = false;
                    break;
                default:
                    YourResultsPage.ShowFemale = true;
                    YourResultsPage.ShowMale = true;
                    break;
            }
        }

        private void NameEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry) sender;
            NameEntryVal = entry.Text;
        }

        protected override void OnAppearing()
        {
            if (!Methods.IsNullOrWhiteSpace(NameEntryVal))
            {
                NameEntry.Text = NameEntryVal;
            }
        }
    }
}