using System;
using Xamarin.Forms;


   /* <Grid.Triggers>
    <DataTrigger TargetType="Grid" Binding="{Binding Gender}" Value="F">
    <Setter Property="BackgroundColor" Value="#ffcce6" />
    </DataTrigger>
    <DataTrigger TargetType="Grid" Binding="{Binding Gender}" Value="M">
    <Setter Property="BackgroundColor" Value="#ccebff" />
    </DataTrigger>
    <DataTrigger TargetType="Grid" Binding="{Binding Gender}" Value="A">
    <Setter Property="BackgroundColor" Value="#ccffe6" />
    </DataTrigger>
    </Grid.Triggers> */


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