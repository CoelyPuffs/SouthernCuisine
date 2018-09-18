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
        public Label breakfastLabel;
        public Label breakfastMenuLabel;
        public Label lunchLabel;
        public Label lunchMenuLabel;
        public Label otherLabel;
        public Label otherMenuLabel;
        public Label supperLabel;
        public Label supperMenuLabel;

        public AllMenusPage()
        {
            InitializeComponent();
            breakfastLabel = Content.FindByName<Label>("BreakfastLabel");
            breakfastMenuLabel = Content.FindByName<Label>("BreakfastMenuLabel");
            lunchLabel = Content.FindByName<Label>("LunchLabel");
            lunchMenuLabel = Content.FindByName<Label>("LunchMenuLabel");
            otherLabel = Content.FindByName<Label>("OtherLabel");
            otherMenuLabel = Content.FindByName<Label>("OtherMenuLabel");
            supperLabel = Content.FindByName<Label>("SupperLabel");
            supperMenuLabel = Content.FindByName<Label>("SupperMenuLabel");
        }

        private void CafMenuButton_Clicked(object sender, EventArgs e)
        {
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

            clearLabels();

            //string[] meals = { "Breakfast", /*"Grab n Go",*/ "Lunch", "International Bar", /*"Grab n Go",*/ "Supper" };

            string meal = "Breakfast";
            string displayMenu = "";
            int mealStartIndex = 0;
            int mealEndIndex = 0;
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m.<", mealStartIndex) + 2;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</p>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);

                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                breakfastLabel.Text = "Breakfast at the Cafeteria \n 6:30 - 10 a.m.";
                breakfastMenuLabel.Text = displayMenu;
            }

            meal = "Lunch";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m.<", mealStartIndex) + 2;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</p>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);

                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                LunchLabel.Text = "Lunch at the Cafeteria \n 11:30 - 2:30 p.m.";
                LunchMenuLabel.Text = displayMenu;
            }

            meal = "International Bar";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m.<", mealStartIndex) + 2;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</p>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);

                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                OtherLabel.Text = "International Bar at the Cafeteria";
                OtherMenuLabel.Text = displayMenu;
            }

            meal = "Supper";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m.<", mealStartIndex) + 2;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</p>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);

                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                SupperLabel.Text = "Supper at the Cafeteria \n 5 - 6:30 p.m.";
                SupperMenuLabel.Text = displayMenu;
            }
        }

        private void VMMenuButton_Clicked(object sender, EventArgs e)
        {
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
            dayMenu = dayMenu.Replace('\n', ' ');

            clearLabels();

            //string[] meals = { "Breakfast", "Lunch", "Soup", "Supper" };

            string meal = "Breakfast";
            string displayMenu = "";
            int mealStartIndex = 0;
            int mealEndIndex = 0;
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", "");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                breakfastLabel.Text = "Breakfast at the Village Market \n 7:00 a.m. - 9:30 a.m.";
                breakfastMenuLabel.Text = displayMenu;
            }

            meal = "Lunch";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("SOUP", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", "");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                lunchLabel.Text = "Lunch at the Village Market \n 11 a.m. - 1:30 p.m.";
                lunchMenuLabel.Text = displayMenu;
            }

            meal = "SOUP";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal) + 4;
                //mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</li>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", "");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                otherLabel.Text = "Soup at the Village Market";
                otherMenuLabel.Text = displayMenu;
            }

            meal = "Supper";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", "");
                displayMenu = displayMenu.Replace("<br>", ", ");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
            }
            if (displayMenu != "")
            {
                supperLabel.Text = "Supper at the Village Market \n 5 a.m. - 7:30 p.m.";
                supperMenuLabel.Text = displayMenu;
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

        public void clearLabels()
        {
            breakfastLabel.Text = "";
            breakfastMenuLabel.Text = "";
            lunchLabel.Text = "";
            lunchMenuLabel.Text = "";
            otherLabel.Text = "";
            otherMenuLabel.Text = "";
            supperLabel.Text = "";
            supperMenuLabel.Text = "";
        }
    }
}