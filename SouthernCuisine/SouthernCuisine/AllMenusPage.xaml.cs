﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SouthernCuisine
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllMenusPage : ContentPage
	{
		public AllMenusPage ()
		{
			InitializeComponent ();
		}

        private void CafMenuButton_Clicked(object sender, EventArgs e)
        {
            Label menuLabel = Content.FindByName<Label>("MenuLabel");
            WebClient client = new WebClient();
            string fullMenu = client.DownloadString("http://www.southern.edu/administration/food/");
            string dayToday = DateTime.Now.DayOfWeek.ToString();
            int dayStartIndex = fullMenu.IndexOf("Menu for " + dayToday);
            int dayEndIndex = fullMenu.IndexOf("</td>", dayStartIndex);
            string dayMenu = fullMenu.Substring(dayStartIndex, dayEndIndex);

            string[] meals = { "Breakfast", "Grab n Go", "Lunch", "International Bar", "Grab n Go", "Supper" };

            string displayMenu = "";
            int mealStartIndex = 0;
            foreach (string meal in meals)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m.<") + 2;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                displayMenu += mealMenu(dayMenu, mealStartIndex) + '\n';
            }

            displayMenu = displayMenu.Replace("&amp;", "&");
            displayMenu = displayMenu.Replace("<br>", ", ");

            menuLabel.Text = displayMenu;
        }

        private void VMMenuButton_Clicked(object sender, EventArgs e)
        {

        }

        public string mealMenu(string fullMenu, int startIndex)
        {

            return "";
        }

        public int findEndOfHTMLTags(string menu, int startIndex)
        {
            int index = startIndex;
            while (menu[index] == '<')
            {
                index = menu.IndexOf('>', startIndex) + 1;
            }
            return index;
        }
    }
}