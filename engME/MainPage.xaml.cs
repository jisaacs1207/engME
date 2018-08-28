using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Xamarin.Forms;

namespace engME
{
    public partial class MainPage : TabbedPage
    {
        
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
