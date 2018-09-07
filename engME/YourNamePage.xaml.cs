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
        public YourNamePage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            var entry = (Entry) NameEntry;
            var text = entry.Text;
        }
    }
}