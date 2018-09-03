using System;
using Xamarin.Forms;

namespace engME
{
    public partial class YourPersonalityPage : ContentPage
    {
        public static int PersonalityType { get; set; } = 3;
        
        public YourPersonalityPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            if (PersonalityType == 1)
            {
                YourResultsPage.ShowConservative = true;
                YourResultsPage.ShowLiberal = false;
            }

            if (PersonalityType == 2)
            {
                YourResultsPage.ShowConservative = false;
                YourResultsPage.ShowLiberal = true;
            }
        }


        private void SliderOne_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private static void UpdateSlider(Slider sender)
        {
            var slider = sender;
            if (slider.Value > 1)
            {
                slider.ThumbColor=Color.MediumPurple;
                
            }
            else if (slider.Value < -1)
            {
                slider.ThumbColor = Color.DodgerBlue;
            }
            else
            {
                slider.ThumbColor = Color.Default;
            }

            double transparency = slider.Value/10;
            if (transparency < 0) transparency = transparency * -1;
            if (transparency < .3) transparency = .3;
            slider.Opacity = transparency;
        }

        private void SliderTwo_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderThree_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderFour_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderFive_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderSix_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderSeven_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderEight_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderNine_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }

        private void SliderTen_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateSlider((Slider)sender);
            var totalDouble=new double();
            UpdateSlider((Slider)sender);
            totalDouble = SliderOne.Value+SliderTwo.Value+SliderThree.Value+SliderFour.Value
                          +SliderFive.Value+SliderSix.Value + SliderSeven.Value
                          +SliderEight.Value+SliderNine.Value+SliderTen.Value;
            if (totalDouble > 0) 
                PersonalityType = 2;
            else 
                PersonalityType = 1;
        }
    }
}