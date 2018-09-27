using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace SouthernCuisine
{
	public partial class MainPage : Xamarin.Forms.TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
            //On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            //this.OnPropertyChanged("nightMode");
        }
	}
}
