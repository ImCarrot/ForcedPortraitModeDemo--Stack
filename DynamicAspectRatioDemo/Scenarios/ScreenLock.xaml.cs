using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DynamicAspectRatioDemo.Scenarios
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScreenLock : Page
    {
        public ScreenLock()
        {
            this.InitializeComponent();
            SizeChanged += ScreenLock_SizeChanged;
        }

        private void ScreenLock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var newHeight = Convert.ToInt16(Math.Round(e.NewSize.Height));

            var newWidth = Convert.ToInt16(Math.Round(e.NewSize.Width));

            //now for it to be in portrait you need it to satisfy, Height = 1.41 times width.
            //So any new size that satisfyies the above eq. would be set, 
            //else it'll take the height and then set the width according to the height.

            decimal division = decimal.Divide(newHeight, newWidth);

            double ratioCheck = 0;

            ratioCheck = Convert.ToDouble(Math.Round(division, 2));


            if (ratioCheck >= 1.41 && ratioCheck <= 1.77)
            {
                return;
            }
            else
            {
                var adjustedWidth = Convert.ToInt16(newHeight / 1.77);

                var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
                view.TryResizeView(new Windows.Foundation.Size { Width = adjustedWidth, Height = newHeight });

            }
        }

        private int FindHCF(int m, int n)
        {
            int temp, reminder;
            if (m < n)
            {
                temp = m;
                m = n;
                n = temp;
            }
            while (true)
            {
                reminder = m % n;
                if (reminder == 0)
                    return n;
                else
                    m = n;
                n = reminder;
            }
        }
    }
}
