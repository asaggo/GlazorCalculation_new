using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalculationJessieJi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const double MAX_WIDTH = 5.0;
        const double MIN_WIDTH = 0.5;
        const double MAX_HEIGHT = 3.0;
        const double MIN_HEIGHT = 0.75;

        private bool isWidthValid = false;
        private bool isHeightValid = false;

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            this.txtQuantity.Text = e.NewValue.ToString();
        }

        private void Click_ClickMe(object sender, RoutedEventArgs e)
        {
            //after validation
            //if true 
            if(isWidthValid && isHeightValid)
            {
                double w = Convert.ToDouble(txtbWidth.Text);
                double h = Convert.ToDouble(txtbHeight.Text);

                lblWidth.Text = txtbWidth.Text;
                lblHeight.Text = txtbHeight.Text;
                lblTintColor.Text = cbboxTintColor.SelectedValue.ToString();
                lblQuantity.Text = txtQuantity.Text;
                lblLengFrame.Text = (2 * (w + h) * 3.25).ToString();
                lblAreaGlass.Text = (2 * w * h).ToString();
                lblOrderDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            }
        }

        private void Width_Changed(object sender, KeyRoutedEventArgs e)
        {
            //this doesn't get the input correctly

        }

        ObservableCollection<string> color = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
            color.Add("Black");
            color.Add("Brown");
            color.Add("Blue");
        }

        private void Width_Changed(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(txtbWidth.Text, out double w))
            {
                if (w >= MIN_WIDTH && w <= MAX_WIDTH)
                {
                    isWidthValid = true;
                    return;
                }
            }
            isWidthValid = false;
        }

        private void Height_Changed(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(txtbHeight.Text, out double w))
            {
                if (w >= MIN_HEIGHT && w <= MAX_HEIGHT)
                {
                    isHeightValid = true;
                    return;
                }
            }
            isHeightValid = false;
        }

    }
}
