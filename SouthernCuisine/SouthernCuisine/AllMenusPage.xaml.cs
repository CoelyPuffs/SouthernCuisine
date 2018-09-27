using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Connectivity;

namespace SouthernCuisine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllMenusPage : ContentPage
    {
        /*public Label breakfastLabel;
        public Label breakfastMenuLabel;
        public Label lunchLabel;
        public Label lunchMenuLabel;
        public Label otherLabel;
        public Label otherMenuLabel;
        public Label supperLabel;
        public Label supperMenuLabel;*/

        bool cafSelected = false;
        bool VMSelected = false;
        bool sunSelected = false;
        bool monSelected = false;
        bool tueSelected = false;
        bool wedSelected = false;
        bool thuSelected = false;
        bool friSelected = false;
        bool satSelected = false;

        bool nightMode = Convert.ToBoolean(Application.Current.Properties["nightMode"]);

        public AllMenusPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            BreakfastLabel = Content.FindByName<Label>("BreakfastLabel");
            BreakfastMenuLabel = Content.FindByName<Label>("BreakfastMenuLabel");
            LunchLabel = Content.FindByName<Label>("LunchLabel");
            LunchMenuLabel = Content.FindByName<Label>("LunchMenuLabel");
            OtherLabel = Content.FindByName<Label>("OtherLabel");
            OtherMenuLabel = Content.FindByName<Label>("OtherMenuLabel");
            SupperLabel = Content.FindByName<Label>("SupperLabel");
            SupperMenuLabel = Content.FindByName<Label>("SupperMenuLabel");

            

            Appearing += (object sender, EventArgs e) =>
            {
                nightMode = Convert.ToBoolean(Application.Current.Properties["nightMode"]);
                if (!nightMode)
                {
                    BreakfastLabel.TextColor = Color.Black;
                    BreakfastMenuLabel.TextColor = Color.Black;
                    LunchLabel.TextColor = Color.Black;
                    LunchMenuLabel.TextColor = Color.Black;
                    OtherLabel.TextColor = Color.Black;
                    OtherMenuLabel.TextColor = Color.Black;
                    SupperLabel.TextColor = Color.Black;
                    SupperMenuLabel.TextColor = Color.Black;
                    Application.Current.MainPage.BackgroundColor = Color.White;
                    CafMenuButton.TextColor = Color.Black;
                    VMMenuButton.TextColor = Color.Black;
                    SundayButton.TextColor = Color.Black;
                    MondayButton.TextColor = Color.Black;
                    TuesdayButton.TextColor = Color.Black;
                    WednesdayButton.TextColor = Color.Black;
                    ThursdayButton.TextColor = Color.Black;
                    FridayButton.TextColor = Color.Black;
                    SaturdayButton.TextColor = Color.Black;
                    //BackgroundColor = Color.White;
                }
                else
                {
                    BreakfastLabel.TextColor = Color.White;
                    BreakfastMenuLabel.TextColor = Color.White;
                    LunchLabel.TextColor = Color.White;
                    LunchMenuLabel.TextColor = Color.White;
                    OtherLabel.TextColor = Color.White;
                    OtherMenuLabel.TextColor = Color.White;
                    SupperLabel.TextColor = Color.White;
                    SupperMenuLabel.TextColor = Color.White;
                    Application.Current.MainPage.BackgroundColor = Color.Black;
                    CafMenuButton.TextColor = Color.White;
                    VMMenuButton.TextColor = Color.White;
                    SundayButton.TextColor = Color.White;
                    MondayButton.TextColor = Color.White;
                    TuesdayButton.TextColor = Color.White;
                    WednesdayButton.TextColor = Color.White;
                    ThursdayButton.TextColor = Color.White;
                    FridayButton.TextColor = Color.White;
                    SaturdayButton.TextColor = Color.White;
                    //BackgroundColor = Color.Black;
                }
            };
        }

        private void CafMenuButton_Clicked(object sender, EventArgs e)
        {
            cafSelected = true;
            VMSelected = false;

            CafMenuButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                VMMenuButton.TextColor = Color.White;
            }
            else
            {
                VMMenuButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (sunSelected)
                {
                    getCafMenu("Sunday");
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
            }
            else
            {
                noConnection();
            }
        }

        private void VMMenuButton_Clicked(object sender, EventArgs e)
        {
            VMSelected = true;
            cafSelected = false;

            VMMenuButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                CafMenuButton.TextColor = Color.White;
            }
            else
            {
                CafMenuButton.TextColor = Color.Black;
            }
            
            if (CrossConnectivity.Current.IsConnected)
            {
                if (sunSelected)
                {
                    getVMMenu("Sunday");
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
            }
            else
            {
                noConnection();
            }
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

            SundayButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                MondayButton.TextColor = Color.White;
                TuesdayButton.TextColor = Color.White;
                WednesdayButton.TextColor = Color.White;
                ThursdayButton.TextColor = Color.White;
                FridayButton.TextColor = Color.White;
                SaturdayButton.TextColor = Color.White;
            }
            else
            {
                MondayButton.TextColor = Color.Black;
                TuesdayButton.TextColor = Color.Black;
                WednesdayButton.TextColor = Color.Black;
                ThursdayButton.TextColor = Color.Black;
                FridayButton.TextColor = Color.Black;
                SaturdayButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (VMSelected)
                {
                    getVMMenu("Sunday");
                }
                else
                {
                    getCafMenu("Sunday");
                }
            }
            else
            {
                noConnection();
            }
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

            MondayButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                SundayButton.TextColor = Color.White;
                TuesdayButton.TextColor = Color.White;
                WednesdayButton.TextColor = Color.White;
                ThursdayButton.TextColor = Color.White;
                FridayButton.TextColor = Color.White;
                SaturdayButton.TextColor = Color.White;
            }
            else
            {
                SundayButton.TextColor = Color.Black;
                TuesdayButton.TextColor = Color.Black;
                WednesdayButton.TextColor = Color.Black;
                ThursdayButton.TextColor = Color.Black;
                FridayButton.TextColor = Color.Black;
                SaturdayButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (VMSelected)
                {
                    getVMMenu("Monday");
                }
                else
                {
                    getCafMenu("Monday");
                }
            }
            else
            {
                noConnection();
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

            TuesdayButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                SundayButton.TextColor = Color.White;
                MondayButton.TextColor = Color.White;
                WednesdayButton.TextColor = Color.White;
                ThursdayButton.TextColor = Color.White;
                FridayButton.TextColor = Color.White;
                SaturdayButton.TextColor = Color.White;
            }
            else
            {
                SundayButton.TextColor = Color.Black;
                MondayButton.TextColor = Color.Black;
                WednesdayButton.TextColor = Color.Black;
                ThursdayButton.TextColor = Color.Black;
                FridayButton.TextColor = Color.Black;
                SaturdayButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (VMSelected)
                {
                    getVMMenu("Tuesday");
                }
                else
                {
                    getCafMenu("Tuesday");
                }
            }
            else
            {
                noConnection();
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

            WednesdayButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                SundayButton.TextColor = Color.White;
                MondayButton.TextColor = Color.White;
                TuesdayButton.TextColor = Color.White;
                ThursdayButton.TextColor = Color.White;
                FridayButton.TextColor = Color.White;
                SaturdayButton.TextColor = Color.White;
            }
            else
            {
                SundayButton.TextColor = Color.Black;
                MondayButton.TextColor = Color.Black;
                TuesdayButton.TextColor = Color.Black;
                ThursdayButton.TextColor = Color.Black;
                FridayButton.TextColor = Color.Black;
                SaturdayButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (VMSelected)
                {
                    getVMMenu("Wednesday");
                }
                else
                {
                    getCafMenu("Wednesday");
                }
            }
            else
            {
                noConnection();
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

            ThursdayButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                SundayButton.TextColor = Color.White;
                MondayButton.TextColor = Color.White;
                TuesdayButton.TextColor = Color.White;
                WednesdayButton.TextColor = Color.White;
                FridayButton.TextColor = Color.White;
                SaturdayButton.TextColor = Color.White;
            }
            else
            {
                SundayButton.TextColor = Color.Black;
                MondayButton.TextColor = Color.Black;
                TuesdayButton.TextColor = Color.Black;
                WednesdayButton.TextColor = Color.Black;
                FridayButton.TextColor = Color.Black;
                SaturdayButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (VMSelected)
                {
                    getVMMenu("Thursday");
                }
                else
                {
                    getCafMenu("Thursday");
                }
            }
            else
            {
                noConnection();
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

            FridayButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                SundayButton.TextColor = Color.White;
                MondayButton.TextColor = Color.White;
                TuesdayButton.TextColor = Color.White;
                WednesdayButton.TextColor = Color.White;
                ThursdayButton.TextColor = Color.White;
                SaturdayButton.TextColor = Color.White;
            }
            else
            {
                SundayButton.TextColor = Color.Black;
                MondayButton.TextColor = Color.Black;
                TuesdayButton.TextColor = Color.Black;
                WednesdayButton.TextColor = Color.Black;
                ThursdayButton.TextColor = Color.Black;
                SaturdayButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (VMSelected)
                {
                    getVMMenu("Friday");
                }
                else
                {
                    getCafMenu("Friday");
                }
            }
            else
            {
                noConnection();
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

            SaturdayButton.TextColor = Color.FromHex("1d9a69");
            if (nightMode)
            {
                SundayButton.TextColor = Color.White;
                MondayButton.TextColor = Color.White;
                TuesdayButton.TextColor = Color.White;
                WednesdayButton.TextColor = Color.White;
                ThursdayButton.TextColor = Color.White;
                FridayButton.TextColor = Color.White;
            }
            else
            {
                SundayButton.TextColor = Color.Black;
                MondayButton.TextColor = Color.Black;
                TuesdayButton.TextColor = Color.Black;
                WednesdayButton.TextColor = Color.Black;
                ThursdayButton.TextColor = Color.Black;
                FridayButton.TextColor = Color.Black;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                if (VMSelected)
                {
                    getVMMenu("Saturday");
                }
                else
                {
                    getCafMenu("Saturday");
                }
            }
            else
            {
                noConnection();
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
                BreakfastLabel.IsVisible = true;
                BreakfastMenuLabel.IsVisible = true;
                BreakfastLabel.Text = "Breakfast at the Cafeteria \n 6:30 - 10 a.m.";
                BreakfastMenuLabel.Text = displayMenu;
            }
            else
            {
                BreakfastLabel.IsVisible = false;
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
                OtherLabel.IsVisible = true;
                OtherMenuLabel.IsVisible = true;
                OtherLabel.Text = "International Bar at the Cafeteria";
                OtherMenuLabel.Text = displayMenu;
            }
            else
            {
                OtherLabel.IsVisible = false;
                OtherMenuLabel.IsVisible = false;
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
            if (BreakfastLabel.IsVisible == false &&
                LunchLabel.IsVisible == false &&
                OtherLabel.IsVisible == false &&
                SupperLabel.IsVisible == false)
            {
                BreakfastLabel.IsVisible = true;
                BreakfastLabel.Text = "No food at the Cafeteria today";
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

            string meal = "Deli";
            string displayMenu = "";
            int mealStartIndex = 0;
            int mealEndIndex = 0;
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("Hot Deck", mealStartIndex) + 8;
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
            else
            {
                meal = "Breakfast";
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>");

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
                BreakfastLabel.IsVisible = true;
                BreakfastMenuLabel.IsVisible = true;
                BreakfastLabel.Text = meal + " at the Village Market \n 7:00 a.m. - 9:30 a.m.";
                BreakfastMenuLabel.Text = displayMenu;
            }
            else
            {
                BreakfastLabel.IsVisible = false;
                BreakfastMenuLabel.IsVisible = false;
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
                LunchLabel.IsVisible = true;
                LunchMenuLabel.IsVisible = true;
                LunchLabel.Text = "Lunch at the Village Market \n 11 a.m. - 1:30 p.m.";
                LunchMenuLabel.Text = displayMenu;
            }
            else
            {
                LunchLabel.IsVisible = false;
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
                OtherLabel.IsVisible = true;
                OtherMenuLabel.IsVisible = true;
                OtherLabel.Text = "Soup at the Village Market";
                OtherMenuLabel.Text = displayMenu;
            }
            else
            {
                OtherLabel.IsVisible = false;
                OtherMenuLabel.IsVisible = false;
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
                SupperLabel.IsVisible = true;
                SupperMenuLabel.IsVisible = true;
                SupperLabel.Text = "Supper at the Village Market \n 5 a.m. - 7:30 p.m.";
                SupperMenuLabel.Text = displayMenu;
            }
            else
            {
                SupperLabel.IsVisible = false;
                SupperMenuLabel.IsVisible = false;
            }
            if (BreakfastLabel.IsVisible == false &&
                LunchLabel.IsVisible == false &&
                OtherLabel.IsVisible == false &&
                SupperLabel.IsVisible == false)
            {
                BreakfastLabel.IsVisible = true;
                BreakfastLabel.Text = "No food at the Village Market today";
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
            BreakfastLabel.Text = "";
            BreakfastMenuLabel.Text = "";
            LunchLabel.Text = "";
            LunchMenuLabel.Text = "";
            OtherLabel.Text = "";
            OtherMenuLabel.Text = "";
            SupperLabel.Text = "";
            SupperMenuLabel.Text = "";
        }

        public void noConnection()
        {
            clearLabels();
            BreakfastLabel.IsVisible = true;
            BreakfastMenuLabel.IsVisible = true;
            BreakfastLabel.Text = "Network connection not detected";
            BreakfastMenuLabel.Text = "Please check your Internet connection";
        }
    }
}