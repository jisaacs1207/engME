using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace engME
{
    public partial class App : Application
    {
        public static ObservableCollection<NameObject> NameList {get; set;} = new ObservableCollection<NameObject>();
        public App()
        {
            InitializeComponent();
            Methods.FillNameDictionary();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
