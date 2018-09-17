using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

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
            if (dayToday == "Saturday")
            {
                dayToday = "Sabbath";
            }
            int dayStartIndex = fullMenu.IndexOf("Menu for " + dayToday);
            int dayEndIndex = fullMenu.IndexOf("</td>", dayStartIndex);
            string dayMenu = fullMenu.Substring(dayStartIndex, dayEndIndex - dayStartIndex);

            string[] meals = { "Breakfast", /*"Grab n Go",*/ "Lunch", "International Bar", /*"Grab n Go",*/ "Supper" };

            string displayMenu = "";
            int mealStartIndex = 0;
            int mealEndIndex = 0;
            foreach (string meal in meals)
            {
                if (dayMenu.IndexOf(meal) != -1)
                {
                    mealStartIndex = dayMenu.IndexOf(meal);
                    mealStartIndex = dayMenu.IndexOf("m.<", mealStartIndex) + 2;
                    mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                    mealEndIndex = dayMenu.IndexOf("</p>", mealStartIndex);

                    displayMenu += meal + '\n' + dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex) + '\n';
                }
            }

            displayMenu = displayMenu.Replace("&amp;", "&");
            displayMenu = displayMenu.Replace("<br>", ", ");
            displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");

            if (displayMenu != "")
            {
                menuLabel.Text = displayMenu;
            }
            else
            {
                menuLabel.Text = "No food today";
            }
        }

        private void VMMenuButton_Clicked(object sender, EventArgs e)
        {
            Label menuLabel = Content.FindByName<Label>("MenuLabel");
            WebClient client = new WebClient();
            string fullMenu = client.DownloadString("http://www.southern.edu/administration/food/deli.html");
            string dayToday = DateTime.Now.DayOfWeek.ToString();
            if (dayToday == "Saturday")
            {
                dayToday = "Sabbath";
            }
            int dayStartIndex = fullMenu.IndexOf(dayToday);
            int dayEndIndex = fullMenu.IndexOf("</div>", dayStartIndex);
            string dayMenu = fullMenu.Substring(dayStartIndex, dayEndIndex - dayStartIndex);

            string[] meals = { "Breakfast", "Lunch", "Soup", "Supper" };

            string displayMenu = "";
            int mealStartIndex = 0;
            int mealEndIndex = 0;
            foreach (string meal in meals)
            {
                if (dayMenu.IndexOf(meal) != -1)
                {
                    mealStartIndex = dayMenu.IndexOf(meal);
                    mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                    mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                    mealEndIndex = dayMenu.IndexOf("</ul>", mealStartIndex);

                    displayMenu += meal + '\n' + dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex) + '\n';
                }
            }

            displayMenu = displayMenu.Replace('\n', ' ');
            displayMenu = displayMenu.Replace("&amp;", "&");
            displayMenu = displayMenu.Replace("&nbsp;", "");
            displayMenu = displayMenu.Replace("<br>", ", ");
            displayMenu = displayMenu.Replace("                                                ", " ");
            displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");

            if (displayMenu != "")
            {
                menuLabel.Text = displayMenu;
            }
            else
            {
                menuLabel.Text = "No food today";
            }
        }

        public int findEndOfHTMLTags(string menu, int startIndex)
        {
            int index = startIndex;
            while (menu[index] == '<')
            {
                index = menu.IndexOf('>', index) + 1;
            }
            return index;
        }
    }
}