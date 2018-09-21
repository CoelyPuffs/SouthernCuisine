using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SouthernCuisine
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreferencesPage : ContentPage
	{
        public bool isNightMode;

		public PreferencesPage ()
		{
			InitializeComponent ();
            Application.Current.Properties.TryGetValue("nightMode", out object isNightMode);
        }

        void DayNightSwitch_Toggled (object sender, EventArgs e)
        {
            if (isNightMode)
            {
                testLabel.TextColor = Color.Black;
                //BackgroundColor = Color.White;
                Application.Current.MainPage.BackgroundColor = Color.White;
            }
            else
            {
                testLabel.TextColor = Color.White;
                //BackgroundColor = Color.Black;
                Application.Current.MainPage.BackgroundColor = Color.Black;
            }
            Application.Current.Properties["nightMode"] = !isNightMode;
            isNightMode = !isNightMode;
        }
	}
}