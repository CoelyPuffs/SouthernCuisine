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

        bool cafSelected = false;
        bool VMSelected = false;
        bool sunSelected = false;
        bool monSelected = false;
        bool tueSelected = false;
        bool wedSelected = false;
        bool thuSelected = false;
        bool friSelected = false;
        bool satSelected = false;

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

            Appearing += (object sender, EventArgs e) =>
            {
                if (Convert.ToBoolean(Application.Current.Properties["nightMode"]) == false)
                {
                    breakfastLabel.TextColor = Color.Black;
                    breakfastMenuLabel.TextColor = Color.Black;
                    lunchLabel.TextColor = Color.Black;
                    lunchMenuLabel.TextColor = Color.Black;
                    otherLabel.TextColor = Color.Black;
                    otherMenuLabel.TextColor = Color.Black;
                    supperLabel.TextColor = Color.Black;
                    supperMenuLabel.TextColor = Color.Black;
                    Application.Current.MainPage.BackgroundColor = Color.White;
                    //BackgroundColor = Color.White;
                }
                else
                {
                    breakfastLabel.TextColor = Color.White;
                    breakfastMenuLabel.TextColor = Color.White;
                    lunchLabel.TextColor = Color.White;
                    lunchMenuLabel.TextColor = Color.White;
                    otherLabel.TextColor = Color.White;
                    otherMenuLabel.TextColor = Color.White;
                    supperLabel.TextColor = Color.White;
                    supperMenuLabel.TextColor = Color.White;
                    Application.Current.MainPage.BackgroundColor = Color.Black;
                    //BackgroundColor = Color.Black;
                }
            };
        }

        private void CafMenuButton_Clicked(object sender, EventArgs e)
        {
            cafSelected = true;
            VMSelected = false;
            if (sunSelected)
            {
                //getCafMenu("Sunday");
            }
            else if (monSelected)
            {
                getCafMenu("Monday");
            }
            else if (tueSelected)
            {
                getCafMenu("Tuesday");
            }
            else if (wedSelected)
            {
                getCafMenu("Wednesday");
            }
            else if (thuSelected)
            {
                getCafMenu("Thursday");
            }
            else if (friSelected)
            {
                getCafMenu("Friday");
            }
            else if (satSelected)
            {
                getCafMenu("Saturday");
            }
            else
            {
                string dayToday = DateTime.Now.DayOfWeek.ToString();
                getCafMenu(dayToday);
            }
            CafMenuButton.BackgroundColor = Color.LightBlue;
            VMMenuButton.BackgroundColor = Color.LightGray;
        }

        private void VMMenuButton_Clicked(object sender, EventArgs e)
        {
            VMSelected = true;
            cafSelected = false;
            if (sunSelected)
            {
                //getVMMenu("Sunday");
            }
            else if (monSelected)
            {
                getVMMenu("Monday");
            }
            else if (tueSelected)
            {
                getVMMenu("Tuesday");
            }
            else if (wedSelected)
            {
                getVMMenu("Wednesday");
            }
            else if (thuSelected)
            {
                getVMMenu("Thursday");
            }
            else if (friSelected)
            {
                getVMMenu("Friday");
            }
            else if (satSelected)
            {
                getVMMenu("Saturday");
            }
            else
            {
                string dayToday = DateTime.Now.DayOfWeek.ToString();
                getVMMenu(dayToday);
            }
            VMMenuButton.BackgroundColor = Color.LightBlue;
            CafMenuButton.BackgroundColor = Color.LightGray;
        }

        private void SundayButton_Clicked(object sender, EventArgs e)
        {
            sunSelected = true;
            monSelected = false;
            tueSelected = false;
            wedSelected = false;
            thuSelected = false;
            friSelected = false;
            satSelected = false;

            SundayButton.BackgroundColor = Color.LightBlue;
            MondayButton.BackgroundColor = Color.LightGray;
            TuesdayButton.BackgroundColor = Color.LightGray;
            WednesdayButton.BackgroundColor = Color.LightGray;
            ThursdayButton.BackgroundColor = Color.LightGray;
            FridayButton.BackgroundColor = Color.LightGray;
            SaturdayButton.BackgroundColor = Color.LightGray;

            /*if (VMSelected)
            {
                getVMMenu("Sunday");
            }
            else
            {
                getCafMenu("Sunday");
            }*/
        }

        private void MondayButton_Clicked(object sender, EventArgs e)
        {
            sunSelected = false;
            monSelected = true;
            tueSelected = false;
            wedSelected = false;
            thuSelected = false;
            friSelected = false;
            satSelected = false;

            SundayButton.BackgroundColor = Color.LightGray;
            MondayButton.BackgroundColor = Color.LightBlue;
            TuesdayButton.BackgroundColor = Color.LightGray;
            WednesdayButton.BackgroundColor = Color.LightGray;
            ThursdayButton.BackgroundColor = Color.LightGray;
            FridayButton.BackgroundColor = Color.LightGray;
            SaturdayButton.BackgroundColor = Color.LightGray;

            if (VMSelected)
            {
                getVMMenu("Monday");
            }
            else
            {
                getCafMenu("Monday");
            }
        }

        private void TuesdayButton_Clicked(object sender, EventArgs e)
        {
            sunSelected = false;
            monSelected = false;
            tueSelected = true;
            wedSelected = false;
            thuSelected = false;
            friSelected = false;
            satSelected = false;

            SundayButton.BackgroundColor = Color.LightGray;
            MondayButton.BackgroundColor = Color.LightGray;
            TuesdayButton.BackgroundColor = Color.LightBlue;
            WednesdayButton.BackgroundColor = Color.LightGray;
            ThursdayButton.BackgroundColor = Color.LightGray;
            FridayButton.BackgroundColor = Color.LightGray;
            SaturdayButton.BackgroundColor = Color.LightGray;

            if (VMSelected)
            {
                getVMMenu("Tuesday");
            }
            else
            {
                getCafMenu("Tuesday");
            }
        }

        private void WednesdayButton_Clicked(object sender, EventArgs e)
        {
            sunSelected = false;
            monSelected = false;
            tueSelected = false;
            wedSelected = true;
            thuSelected = false;
            friSelected = false;
            satSelected = false;

            SundayButton.BackgroundColor = Color.LightGray;
            MondayButton.BackgroundColor = Color.LightGray;
            TuesdayButton.BackgroundColor = Color.LightGray;
            WednesdayButton.BackgroundColor = Color.LightBlue;
            ThursdayButton.BackgroundColor = Color.LightGray;
            FridayButton.BackgroundColor = Color.LightGray;
            SaturdayButton.BackgroundColor = Color.LightGray;

            if (VMSelected)
            {
                getVMMenu("Wednesday");
            }
            else
            {
                getCafMenu("Wednesday");
            }
        }

        private void ThursdayButton_Clicked(object sender, EventArgs e)
        {
            sunSelected = false;
            monSelected = false;
            tueSelected = false;
            wedSelected = false;
            thuSelected = true;
            friSelected = false;
            satSelected = false;

            SundayButton.BackgroundColor = Color.LightGray;
            MondayButton.BackgroundColor = Color.LightGray;
            TuesdayButton.BackgroundColor = Color.LightGray;
            WednesdayButton.BackgroundColor = Color.LightGray;
            ThursdayButton.BackgroundColor = Color.LightBlue;
            FridayButton.BackgroundColor = Color.LightGray;
            SaturdayButton.BackgroundColor = Color.LightGray;

            if (VMSelected)
            {
                getVMMenu("Thursday");
            }
            else
            {
                getCafMenu("Thursday");
            }
        }

        private void FridayButton_Clicked(object sender, EventArgs e)
        {
            sunSelected = false;
            monSelected = false;
            tueSelected = false;
            wedSelected = false;
            thuSelected = false;
            friSelected = true;
            satSelected = false;

            SundayButton.BackgroundColor = Color.LightGray;
            MondayButton.BackgroundColor = Color.LightGray;
            TuesdayButton.BackgroundColor = Color.LightGray;
            WednesdayButton.BackgroundColor = Color.LightGray;
            ThursdayButton.BackgroundColor = Color.LightGray;
            FridayButton.BackgroundColor = Color.LightBlue;
            SaturdayButton.BackgroundColor = Color.LightGray;

            if (VMSelected)
            {
                getVMMenu("Friday");
            }
            else
            {
                getCafMenu("Friday");
            }
        }

        private void SaturdayButton_Clicked(object sender, EventArgs e)
        {
            sunSelected = false;
            monSelected = false;
            tueSelected = false;
            wedSelected = false;
            thuSelected = false;
            friSelected = false;
            satSelected = true;

            SundayButton.BackgroundColor = Color.LightGray;
            MondayButton.BackgroundColor = Color.LightGray;
            TuesdayButton.BackgroundColor = Color.LightGray;
            WednesdayButton.BackgroundColor = Color.LightGray;
            ThursdayButton.BackgroundColor = Color.LightGray;
            FridayButton.BackgroundColor = Color.LightGray;
            SaturdayButton.BackgroundColor = Color.LightBlue;

            if (VMSelected)
            {
                getVMMenu("Saturday");
            }
            else
            {
                getCafMenu("Saturday");
            }
        }

        private void getCafMenu(string dayToday)
        { 
            WebClient client = new WebClient();
            string fullMenu = client.DownloadString("http://www.southern.edu/administration/food/");
            //string dayToday = DateTime.Now.DayOfWeek.ToString();
            if (dayToday == "Saturday")
            {
                dayToday = "Sabbath";
            }
            int dayStartIndex = fullMenu.IndexOf("Menu for " + dayToday);
            int dayEndIndex = fullMenu.IndexOf("</div>", dayStartIndex);
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
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                breakfastLabel.IsVisible = true;
                breakfastMenuLabel.IsVisible = true;
                breakfastLabel.Text = "Breakfast at the Cafeteria \n 6:30 - 10 a.m.";
                breakfastMenuLabel.Text = displayMenu;
            }
            else
            {
                breakfastLabel.IsVisible = false;
                BreakfastMenuLabel.IsVisible = false;
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
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                LunchLabel.IsVisible = true;
                LunchMenuLabel.IsVisible = true;
                LunchLabel.Text = "Lunch at the Cafeteria \n 11:30 - 2:30 p.m.";
                LunchMenuLabel.Text = displayMenu;
            }
            else
            {
                LunchLabel.IsVisible = false;
                LunchMenuLabel.IsVisible = false;
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
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                otherLabel.IsVisible = true;
                otherMenuLabel.IsVisible = true;
                OtherLabel.Text = "International Bar at the Cafeteria";
                OtherMenuLabel.Text = displayMenu;
            }
            else
            {
                otherLabel.IsVisible = false;
                otherMenuLabel.IsVisible = false;
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
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = Regex.Replace(displayMenu, "<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                SupperLabel.IsVisible = true;
                SupperMenuLabel.IsVisible = true;
                SupperLabel.Text = "Supper at the Cafeteria \n 5 - 6:30 p.m.";
                SupperMenuLabel.Text = displayMenu;
            }
            else
            {
                SupperLabel.IsVisible = false;
                SupperMenuLabel.IsVisible = false;
            }
        }

        private void getVMMenu(string dayToday)
        {
            WebClient client = new WebClient();
            string fullMenu = client.DownloadString("http://www.southern.edu/administration/food/deli.html");
            //string dayToday = DateTime.Now.DayOfWeek.ToString();
            if (dayToday == "Saturday")
            {
                dayToday = "Sabbath";
            }
            int dayStartIndex = fullMenu.IndexOf("DELI MENU");
            dayStartIndex = fullMenu.IndexOf(dayToday, dayStartIndex);
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
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                breakfastLabel.IsVisible = true;
                breakfastMenuLabel.IsVisible = true;
                breakfastLabel.Text = "Breakfast at the Village Market \n 7:00 a.m. - 9:30 a.m.";
                breakfastMenuLabel.Text = displayMenu;
            }
            else
            {
                breakfastLabel.IsVisible = false;
                breakfastMenuLabel.IsVisible = false;
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
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                lunchLabel.IsVisible = true;
                LunchMenuLabel.IsVisible = true;
                lunchLabel.Text = "Lunch at the Village Market \n 11 a.m. - 1:30 p.m.";
                lunchMenuLabel.Text = displayMenu;
            }
            else
            {
                lunchLabel.IsVisible = false;
                LunchMenuLabel.IsVisible = false;
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
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                otherLabel.IsVisible = true;
                otherMenuLabel.IsVisible = true;
                otherLabel.Text = "Soup at the Village Market";
                otherMenuLabel.Text = displayMenu;
            }
            else
            {
                otherLabel.IsVisible = false;
                otherMenuLabel.IsVisible = false;
            }

            meal = "Supper";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                if (dayMenu.IndexOf("m<", mealStartIndex) < 0)
                {
                    mealStartIndex = dayMenu.IndexOf("NO SUPPER", mealStartIndex);
                }
                else
                {
                    mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                }
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                supperLabel.IsVisible = true;
                SupperMenuLabel.IsVisible = true;
                supperLabel.Text = "Supper at the Village Market \n 5 a.m. - 7:30 p.m.";
                supperMenuLabel.Text = displayMenu;
            }
            else
            {
                supperLabel.IsVisible = false;
                SupperMenuLabel.IsVisible = false;
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