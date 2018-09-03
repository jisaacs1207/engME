using Xamarin.Forms;

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