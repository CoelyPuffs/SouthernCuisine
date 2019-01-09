using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using Plugin.Connectivity;

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

        string venueSelected = "Cafeteria";
        string daySelected = DateTime.Now.DayOfWeek.ToString();

        public AllMenusPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                getCafMenu(daySelected);
            }
            //else
            catch
            {
                noConnection();
            }
                

            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
            {
                BreakfastLabel.TextColor = Color.White;
                BreakfastMenuLabel.TextColor = Color.White;
                LunchLabel.TextColor = Color.White;
                LunchMenuLabel.TextColor = Color.White;
                OtherLabel.TextColor = Color.White;
                OtherMenuLabel.TextColor = Color.White;
                SupperLabel.TextColor = Color.White;
                SupperMenuLabel.TextColor = Color.White;
                CafMenuButton.TextColor = Color.White;
                VMMenuButton.TextColor = Color.White;
                SundayButton.TextColor = Color.White;
                MondayButton.TextColor = Color.White;
                TuesdayButton.TextColor = Color.White;
                WednesdayButton.TextColor = Color.White;
                ThursdayButton.TextColor = Color.White;
                FridayButton.TextColor = Color.White;
                SaturdayButton.TextColor = Color.White;
            }
            else
            {
                BreakfastLabel.TextColor = Color.Black;
                BreakfastMenuLabel.TextColor = Color.Black;
                LunchLabel.TextColor = Color.Black;
                LunchMenuLabel.TextColor = Color.Black;
                OtherLabel.TextColor = Color.Black;
                OtherMenuLabel.TextColor = Color.Black;
                SupperLabel.TextColor = Color.Black;
                SupperMenuLabel.TextColor = Color.Black;
                CafMenuButton.TextColor = Color.Black;
                VMMenuButton.TextColor = Color.Black;
                SundayButton.TextColor = Color.Black;
                MondayButton.TextColor = Color.Black;
                TuesdayButton.TextColor = Color.Black;
                WednesdayButton.TextColor = Color.Black;
                ThursdayButton.TextColor = Color.Black;
                FridayButton.TextColor = Color.Black;
                SaturdayButton.TextColor = Color.Black;

            }

            resetSelectionColor();

            Appearing += delegate
            {
                if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
                {
                    BreakfastLabel.TextColor = Color.White;
                    BreakfastMenuLabel.TextColor = Color.White;
                    LunchLabel.TextColor = Color.White;
                    LunchMenuLabel.TextColor = Color.White;
                    OtherLabel.TextColor = Color.White;
                    OtherMenuLabel.TextColor = Color.White;
                    SupperLabel.TextColor = Color.White;
                    SupperMenuLabel.TextColor = Color.White;
                    CafMenuButton.TextColor = Color.White;
                    VMMenuButton.TextColor = Color.White;
                    SundayButton.TextColor = Color.White;
                    MondayButton.TextColor = Color.White;
                    TuesdayButton.TextColor = Color.White;
                    WednesdayButton.TextColor = Color.White;
                    ThursdayButton.TextColor = Color.White;
                    FridayButton.TextColor = Color.White;
                    SaturdayButton.TextColor = Color.White;
                }
                else
                {
                    BreakfastLabel.TextColor = Color.Black;
                    BreakfastMenuLabel.TextColor = Color.Black;
                    LunchLabel.TextColor = Color.Black;
                    LunchMenuLabel.TextColor = Color.Black;
                    OtherLabel.TextColor = Color.Black;
                    OtherMenuLabel.TextColor = Color.Black;
                    SupperLabel.TextColor = Color.Black;
                    SupperMenuLabel.TextColor = Color.Black;
                    CafMenuButton.TextColor = Color.Black;
                    VMMenuButton.TextColor = Color.Black;
                    SundayButton.TextColor = Color.Black;
                    MondayButton.TextColor = Color.Black;
                    TuesdayButton.TextColor = Color.Black;
                    WednesdayButton.TextColor = Color.Black;
                    ThursdayButton.TextColor = Color.Black;
                    FridayButton.TextColor = Color.Black;
                    SaturdayButton.TextColor = Color.Black;
                }
                resetSelectionColor();
            };
        }

        private void CafMenuButton_Clicked(object sender, EventArgs e)
        {
            venueSelected = "Cafeteria";

            CafMenuButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
            {
                VMMenuButton.TextColor = Color.White;
            }
            else
            {
                VMMenuButton.TextColor = Color.Black;
            }

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                getCafMenu(daySelected);
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void VMMenuButton_Clicked(object sender, EventArgs e)
        {
            venueSelected = "Village Market";

            VMMenuButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
            {
                CafMenuButton.TextColor = Color.White;
            }
            else
            {
                CafMenuButton.TextColor = Color.Black;
            }
            
            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                getVMMenu(daySelected);
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void SundayButton_Clicked(object sender, EventArgs e)
        {
            daySelected = "Sunday";

            SundayButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
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

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                if (venueSelected == "Village Market")
                {
                    getVMMenu("Sunday");
                }
                else
                {
                    getCafMenu("Sunday");
                }
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void MondayButton_Clicked(object sender, EventArgs e)
        {
            daySelected = "Monday";

            MondayButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
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

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                if (venueSelected == "Village Market")
                {
                    getVMMenu("Monday");
                }
                else
                {
                    getCafMenu("Monday");
                }
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void TuesdayButton_Clicked(object sender, EventArgs e)
        {
            daySelected = "Tuesday";

            TuesdayButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
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

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                if (venueSelected == "Village Market")
                {
                    getVMMenu("Tuesday");
                }
                else
                {
                    getCafMenu("Tuesday");
                }
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void WednesdayButton_Clicked(object sender, EventArgs e)
        {
            daySelected = "Wednesday";

            WednesdayButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
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

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                if (venueSelected == "Village Market")
                {
                    getVMMenu("Wednesday");
                }
                else
                {
                    getCafMenu("Wednesday");
                }
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void ThursdayButton_Clicked(object sender, EventArgs e)
        {
            daySelected = "Thursday";

            ThursdayButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
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

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                if (venueSelected == "Village Market")
                {
                    getVMMenu("Thursday");
                }
                else
                {
                    getCafMenu("Thursday");
                }
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void FridayButton_Clicked(object sender, EventArgs e)
        {
            daySelected = "Friday";

            FridayButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
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

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                if (venueSelected == "Village Market")
                {
                    getVMMenu("Friday");
                }
                else
                {
                    getCafMenu("Friday");
                }
            }
            //else
            catch
            {
                noConnection();
            }
        }

        private void SaturdayButton_Clicked(object sender, EventArgs e)
        {
            daySelected = "Saturday";

            SaturdayButton.TextColor = Color.FromHex("1d9a69");
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
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

            //if (CrossConnectivity.Current.IsConnected)
            try
            {
                if (venueSelected == "Village Market")
                {
                    getVMMenu("Saturday");
                }
                else
                {
                    getCafMenu("Saturday");
                }
            }
            //else
            catch
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
            dayMenu = dayMenu.Replace("&nbsp;", " ");

            clearLabels();

            //string[] meals = { "Breakfast", /*"Grab n Go",*/ "Lunch", "International Bar", /*"Grab n Go",*/ "Supper" };

            string meal = "Breakfast";
            string displayMenu = "";
            int mealStartIndex = 0;
            int mealEndIndex = 0;
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                mealStartIndex = dayMenu.IndexOf("<", mealStartIndex);
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealStartIndex = dayMenu.IndexOf("<", mealStartIndex);
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
                string breakfastTime = "";
                var test = dayMenu.Substring(dayMenu.IndexOf(meal));
                var cafBreakfastTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (cafBreakfastTimeMatch.Success)
                {
                    breakfastTime = dayMenu.Substring(dayMenu.IndexOf(meal) + cafBreakfastTimeMatch.Index, cafBreakfastTimeMatch.Length);
                }
                string breakfastLabelText = "Breakfast at the Cafeteria";
                if (breakfastTime != "")
                {
                    breakfastLabelText += '\n' + breakfastTime;
                }
                BreakfastLabel.Text = breakfastLabelText;
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
                mealStartIndex = dayMenu.IndexOf("<", mealStartIndex);
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealStartIndex = dayMenu.IndexOf("<", mealStartIndex);
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
                string lunchTime = "";
                var cafLunchTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (cafLunchTimeMatch.Success)
                {
                    lunchTime = dayMenu.Substring(dayMenu.IndexOf(meal) + cafLunchTimeMatch.Index, cafLunchTimeMatch.Length);
                }
                string lunchLabelText = "Lunch at the Cafeteria";
                if (lunchTime != "")
                {
                    lunchLabelText += '\n' + lunchTime;
                }
                LunchLabel.Text = lunchLabelText;
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
                string otherTime = "";
                var cafOtherTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (cafOtherTimeMatch.Success)
                {
                    otherTime = dayMenu.Substring(dayMenu.IndexOf(meal) + cafOtherTimeMatch.Index, cafOtherTimeMatch.Length);
                }
                string otherLabelText = "International Bar at the Cafeteria";
                if (otherTime != "")
                {
                    otherLabelText += '\n' + otherTime;
                }
                OtherLabel.Text = otherLabelText;
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
                if (dayMenu.Substring(mealStartIndex + 10, 14) == "Served at KR's")
                {
                    mealStartIndex += 10;
                    mealEndIndex = dayMenu.IndexOf("</strong>", mealStartIndex);
                    mealEndIndex = findEndOfHTMLTags(dayMenu, mealEndIndex);
                }
                else
                {
                    mealStartIndex = dayMenu.IndexOf("<", mealStartIndex);
                    mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                    mealStartIndex = dayMenu.IndexOf("<", mealStartIndex);
                    mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                    mealEndIndex = dayMenu.IndexOf("</p>", mealStartIndex);
                }

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
                string supperTime = "";
                var cafSupperTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (cafSupperTimeMatch.Success)
                {
                    supperTime = dayMenu.Substring(dayMenu.IndexOf(meal) + cafSupperTimeMatch.Index, cafSupperTimeMatch.Length);
                }
                string supperLabelText = "Supper at the Cafeteria";
                if (supperTime != "")
                {
                    supperLabelText += '\n' + supperTime;
                }
                SupperLabel.Text = supperLabelText;
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
                clearLabels();
                BreakfastLabel.IsVisible = true;
                BreakfastMenuLabel.IsVisible = true;
                BreakfastLabel.Text = "Closed for Sabbath";
                return;
            }
            int dayStartIndex = fullMenu.IndexOf("DELI MENU");
            dayStartIndex = fullMenu.IndexOf(dayToday, dayStartIndex);
            int dayEndIndex = fullMenu.IndexOf("</div>", dayStartIndex);
            string dayMenu = fullMenu.Substring(dayStartIndex, dayEndIndex - dayStartIndex);
            dayMenu = dayMenu.Replace('\n', ' ');
            dayMenu = dayMenu.Replace("&nbsp;", " ");

            clearLabels();

            //string[] meals = { "Breakfast", "Lunch", "Soup", "Supper" };

            string meal = "g>Deli";
            string displayMenu = "";
            int mealStartIndex = 0;
            int mealEndIndex = 0;
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal);
                meal = "Deli";
                mealStartIndex = dayMenu.IndexOf("Hot Deck", mealStartIndex) + 8;
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"\n{2,}", "\n");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            else
            {
                meal = "Breakfast";
                mealStartIndex = dayMenu.IndexOf(meal);
                int noSpaceIndex = dayMenu.IndexOf("m<", mealStartIndex);
                int spaceIndex = dayMenu.IndexOf("m <", mealStartIndex);
                if (noSpaceIndex > 0)
                {
                    if (spaceIndex > 0)
                    {
                        mealStartIndex = Math.Min(dayMenu.IndexOf("m<", mealStartIndex) + 1, dayMenu.IndexOf("m <", mealStartIndex) + 2);
                    }
                    else
                    {
                        mealStartIndex = mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                    }
                }
                else
                {
                    mealStartIndex = dayMenu.IndexOf("m <", mealStartIndex) + 2;
                }
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>");

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"\n{2,}", "\n");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                BreakfastLabel.IsVisible = true;
                BreakfastMenuLabel.IsVisible = true;
                string breakfastTime = "";
                var test = dayMenu.Substring(dayMenu.IndexOf(meal));
                var VMBreakfastTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (VMBreakfastTimeMatch.Success)
                {
                    breakfastTime = dayMenu.Substring(dayMenu.IndexOf(meal) + VMBreakfastTimeMatch.Index, VMBreakfastTimeMatch.Length);
                }
                string breakfastLabelText = "Breakfast at the Village Market Deli";
                if (breakfastTime != "")
                {
                    breakfastLabelText += '\n' + breakfastTime;
                }
                BreakfastLabel.Text = breakfastLabelText;
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
                int noSpaceIndex = dayMenu.IndexOf("m<", mealStartIndex);
                int spaceIndex = dayMenu.IndexOf("m <", mealStartIndex);
                if (noSpaceIndex > 0)
                {
                    if (spaceIndex > 0)
                    {
                        mealStartIndex = Math.Min(dayMenu.IndexOf("m<", mealStartIndex) + 1, dayMenu.IndexOf("m <", mealStartIndex) + 2);
                    }
                    else
                    {
                        mealStartIndex = mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                    }
                }
                else
                {
                    mealStartIndex = dayMenu.IndexOf("m <", mealStartIndex) + 2;
                }
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"\n{2,}", "\n");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                LunchLabel.IsVisible = true;
                LunchMenuLabel.IsVisible = true;
                string lunchTime = "";
                var VMLunchTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (VMLunchTimeMatch.Success)
                {
                    lunchTime = dayMenu.Substring(dayMenu.IndexOf(meal) + VMLunchTimeMatch.Index, VMLunchTimeMatch.Length);
                }
                string lunchLabelText = "Lunch at the Village Market Deli";
                if (lunchTime != "")
                {
                    lunchLabelText += '\n' + lunchTime;
                }
                LunchLabel.Text = lunchLabelText;
                LunchMenuLabel.Text = displayMenu;
            }
            else
            {
                LunchLabel.IsVisible = false;
                LunchMenuLabel.IsVisible = false;
            }

            meal = "Salad Bar";
            displayMenu = "";
            if (dayMenu.IndexOf(meal) != -1)
            {
                mealStartIndex = dayMenu.IndexOf(meal) + 9;

                OtherLabel.IsVisible = true;
                string otherTime = "";
                var VMOtherTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (VMOtherTimeMatch.Success)
                {
                    otherTime = dayMenu.Substring(dayMenu.IndexOf(meal) + VMOtherTimeMatch.Index, VMOtherTimeMatch.Length);
                }
                string otherLabelText = "Salad Bar at the Village Market";
                if (otherTime != "")
                {
                    otherLabelText += '\n' + otherTime;
                }
                OtherLabel.Text = otherLabelText;
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
                if (dayMenu.IndexOf("m<", mealStartIndex) < 0 && dayMenu.IndexOf("m <", mealStartIndex) < 0)
                {
                    mealStartIndex = dayMenu.IndexOf("NO SUPPER", mealStartIndex);
                }
                else
                {
                    int noSpaceIndex = dayMenu.IndexOf("m<", mealStartIndex);
                    int spaceIndex = dayMenu.IndexOf("m <", mealStartIndex);
                    if (noSpaceIndex > 0)
                    {
                        if (spaceIndex > 0)
                        {
                            mealStartIndex = Math.Min(dayMenu.IndexOf("m<", mealStartIndex) + 1, dayMenu.IndexOf("m <", mealStartIndex) + 2);
                        }
                        else
                        {
                            mealStartIndex = mealStartIndex = dayMenu.IndexOf("m<", mealStartIndex) + 1;
                        }
                    }
                    else
                    {
                        mealStartIndex = dayMenu.IndexOf("m <", mealStartIndex) + 2;
                    }
                }
                mealStartIndex = findEndOfHTMLTags(dayMenu, mealStartIndex);
                mealEndIndex = dayMenu.IndexOf("</ul>", mealStartIndex);

                displayMenu = dayMenu.Substring(mealStartIndex, mealEndIndex - mealStartIndex);
                displayMenu = displayMenu.Replace("&amp;", "&");
                displayMenu = displayMenu.Replace("&nbsp;", " ");
                displayMenu = displayMenu.Replace("<br>", "\n");
                displayMenu = displayMenu.Replace("</li>", "\n");
                displayMenu = Regex.Replace(displayMenu, @"[^\S\n]{2,}", "");
                displayMenu = Regex.Replace(displayMenu, @"\n{2,}", "\n");
                displayMenu = Regex.Replace(displayMenu, @"<[^<>]*>", "");
                displayMenu = Regex.Replace(displayMenu, @"\s+\z", "");
            }
            if (displayMenu != "")
            {
                SupperLabel.IsVisible = true;
                SupperMenuLabel.IsVisible = true;
                string supperTime = "";
                var VMSupperTimeMatch = Regex.Match(dayMenu.Substring(dayMenu.IndexOf(meal)), @"[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");
                if (VMSupperTimeMatch.Success)
                {
                    supperTime = dayMenu.Substring(dayMenu.IndexOf(meal) + VMSupperTimeMatch.Index, VMSupperTimeMatch.Length);
                }
                string supperLabelText = "Supper at the Village Market Deli";
                if (supperTime != "")
                {
                    supperLabelText += '\n' + supperTime;
                }
                SupperLabel.Text = supperLabelText;
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
                BreakfastLabel.Text = "Closed now";
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
            BreakfastLabel.Text = "Error";
            BreakfastMenuLabel.Text = "Please check your Internet connection";
        }

        public void resetSelectionColor()
        {
            switch (venueSelected)
            {
                case "Cafeteria":
                    CafMenuButton.TextColor = Color.FromHex("1d9a69");
                    break;
                case "Village Market":
                    VMMenuButton.TextColor = Color.FromHex("1d9a69");
                    break;
            }
            switch (daySelected)
            {
                case "Sunday":
                    SundayButton.TextColor = Color.FromHex("1d9a69");
                    break;
                case "Monday":
                    MondayButton.TextColor = Color.FromHex("1d9a69");
                    break;
                case "Tuesday":
                    TuesdayButton.TextColor = Color.FromHex("1d9a69");
                    break;
                case "Wednesday":
                    WednesdayButton.TextColor = Color.FromHex("1d9a69");
                    break;
                case "Thursday":
                    ThursdayButton.TextColor = Color.FromHex("1d9a69");
                    break;
                case "Friday":
                    FridayButton.TextColor = Color.FromHex("1d9a69");
                    break;
                case "Saturday":
                    SaturdayButton.TextColor = Color.FromHex("1d9a69");
                    break;
            }
        }
    }
}