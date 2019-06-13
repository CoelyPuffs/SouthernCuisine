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
	public partial class CurrentMenuPage : ContentPage
	{
        List<string> allCafMeals = new List<string>();
        List<string> allVMMeals = new List<string>();

        public CurrentMenuPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
            {
                CurrentCafMealLabel.TextColor = Color.White;
                CurrentCafLabel.TextColor = Color.White;
                CurrentVMMealLabel.TextColor = Color.White;
                CurrentVMLabel.TextColor = Color.White;
                //if (CrossConnectivity.Current.IsConnected)
                try
                {
                    setMenus();
                }
                catch
                {
                    noConnection();
                }
            }
            else
            {
                CurrentCafMealLabel.TextColor = Color.Black;
                CurrentCafLabel.TextColor = Color.Black;
                CurrentVMMealLabel.TextColor = Color.Black;
                CurrentVMLabel.TextColor = Color.Black;
                //if (CrossConnectivity.Current.IsConnected)
                try
                {
                    setMenus();
                }
                catch
                {
                    noConnection();
                }
                //BackgroundColor = Color.White;
            }

            Appearing += delegate
            {
                if (Convert.ToBoolean(Application.Current.Properties["nightMode"]))
                {
                    CurrentCafMealLabel.TextColor = Color.White;
                    CurrentCafLabel.TextColor = Color.White;
                    CurrentVMMealLabel.TextColor = Color.White;
                    CurrentVMLabel.TextColor = Color.White;
                    //if (CrossConnectivity.Current.IsConnected)
                    try
                    {
                        setMenus();
                    }
                    //else
                    catch
                    {
                        noConnection();
                    }
                }
                else
                {
                    CurrentCafMealLabel.TextColor = Color.Black;
                    CurrentCafLabel.TextColor = Color.Black;
                    CurrentVMMealLabel.TextColor = Color.Black;
                    CurrentVMLabel.TextColor = Color.Black;
                    //if (CrossConnectivity.Current.IsConnected)
                    try
                    {
                        setMenus();
                    }
                    //else
                    catch
                    {
                        noConnection();
                    }
                    //BackgroundColor = Color.White;
                }
            };
		}

        public void setMenus()
        {
            // get caf meal and time
            // get vm meal and time
            // get caf menu
            // get vm menu

            WebClient client = new WebClient();
            DateTime today = DateTime.Now;
            int hour = today.Hour;
            int minutes = today.Minute;
            string dayToday = today.DayOfWeek.ToString();


            // For testing purposes
            //hour = 7;
            //dayToday = "Sunday";


            if (dayToday == "Saturday")
            {
                dayToday = "Sabbath";
            }

            string fullCafMenu = client.DownloadString("http://www.southern.edu/administration/food/");
            allCafMeals = new List<string>();
            List<string> currentCafMeal = getCafMeal(fullCafMenu, dayToday, hour, minutes);
            if (currentCafMeal.Count == 0)
            {
                CurrentCafMealLabel.Text = "Cafeteria";
                CurrentCafLabel.Text = "Closed now";
            }
            else
            {
                setCafMenu(fullCafMenu, dayToday, currentCafMeal[0], currentCafMeal[1]);
            }

            string fullVMMenu = client.DownloadString("http://www.southern.edu/administration/food/deli.html");
            allVMMeals = new List<string>();
            List<string> currentVMMeal = getVMMeal(fullVMMenu, dayToday, hour, minutes); //error here
            if (currentVMMeal.Count == 0)
            {
                CurrentVMMealLabel.Text = "Village Market Deli";
                CurrentVMLabel.Text = "Closed now";
            }
            else
            {
                setVMMenu(fullVMMenu, dayToday, currentVMMeal[0], currentVMMeal[1]);
            }
        }

        public List<string> getCafMeal(string fullCafMenu, string dayToday, int hour, int minutes)
        {
            string cafDayToday = dayToday;
            int cafDayStartIndex = fullCafMenu.IndexOf("Menu for " + cafDayToday);
            int cafDayEndIndex = fullCafMenu.IndexOf("</div>", cafDayStartIndex);
            string cafDayMenu = fullCafMenu.Substring(cafDayStartIndex, cafDayEndIndex - cafDayStartIndex);
            cafDayMenu = cafDayMenu.Replace("&nbsp;", " ");

            var cafTimeMatch = Regex.Matches(cafDayMenu, @">\s*[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");

            List<List<string>> mealNamesTimes = new List<List<string>>();

            foreach (Match mealtime in cafTimeMatch)
            {
                List<string> meal = new List<string>();
                string mealName = cafDayMenu.Substring(cafDayMenu.LastIndexOf('>', findBeginOfHTMLTags(cafDayMenu, cafDayMenu.IndexOf(mealtime.ToString().Substring(1)))) + 1, findBeginOfHTMLTags(cafDayMenu, cafDayMenu.IndexOf(mealtime.ToString().Substring(1))) - cafDayMenu.LastIndexOf('>', findBeginOfHTMLTags(cafDayMenu, cafDayMenu.IndexOf(mealtime.ToString().Substring(1)))) - 1);
                allCafMeals.Add(mealName);
                if (mealName != "Grab n Go" && mealName != "International Bar" && mealName != "Deli at the Village Market" && mealName != "KR's" && mealName != "Served at KR's ")
                {
                    meal = new List<string>{ mealName, mealtime.ToString().Substring(1)};
                }
                if (meal.Count > 0)
                {
                    mealNamesTimes.Add(meal);
                }
            }

            int mealTime = 0;
            if (mealNamesTimes.Count > 0)
            {
                while (mealTime < mealNamesTimes.Count && isGreaterThanEndTime(mealNamesTimes[mealTime][1], hour, minutes))
                {
                    mealTime++;
                }
            }

            // End of the day (or no food that day)
            if (mealTime == mealNamesTimes.Count)
            {
                return new List<string>();
            }

            // Edge cases: Sabbath Supper
            //              Carry over a day
            //              Note: not actually done

            return mealNamesTimes[mealTime];
        }

        public List<string> getVMMeal(string fullVMMenu, string dayToday, int hour, int minutes)
        {
            int VMDayStartIndex = fullVMMenu.IndexOf("DELI MENU");
            VMDayStartIndex = fullVMMenu.IndexOf(dayToday, VMDayStartIndex);
            int VMDayEndIndex = fullVMMenu.IndexOf("</div>", VMDayStartIndex);
            string VMDayMenu = fullVMMenu.Substring(VMDayStartIndex, VMDayEndIndex - VMDayStartIndex);
            VMDayMenu = VMDayMenu.Replace('\n', ' ');
            VMDayMenu = VMDayMenu.Replace("&nbsp;", " ");

            var VMTimeMatch = Regex.Matches(VMDayMenu, @"\s[123456789][1230:apm\s\.]*-\s*[123456789][1230:]*\s*(am|pm|a\.m\.|p\.m\.|a\.m|p\.m)");

            List<List<string>> mealNamesTimes = new List<List<string>>();

            foreach (Match mealtime in VMTimeMatch)
            {
                List<string> meal = new List<string>();
                int beginTimeIndex = VMDayMenu.IndexOf(mealtime.ToString());
                string mealName = VMDayMenu.Substring(VMDayMenu.LastIndexOf('>', beginTimeIndex) + 1, beginTimeIndex - (VMDayMenu.LastIndexOf('>', beginTimeIndex) + 1));
                allVMMeals.Add(mealName);
                if (mealName != "Salad Bar Served" && mealName != "Salad Bar" && mealName != "Salad Bar ")
                {
                    meal = new List<string> { mealName, mealtime.ToString().Substring(1) };
                }
                if (meal.Count > 0)
                {
                    mealNamesTimes.Add(meal);
                }
            }

            int mealTime = 0;
            if (mealNamesTimes.Count > 0)
            {
                while (mealTime < mealNamesTimes.Count && isGreaterThanEndTime(mealNamesTimes[mealTime][1], hour, minutes))
                {
                    mealTime++;
                }
            }

            // End of the day (or no food that day)
            if (mealTime == mealNamesTimes.Count)
            {
                return new List<string>();
            }

            // Edge cases: Sabbath Supper
            //              Carry over a day
            //              Carry over into Sabbath
            //              Note: not actually done

            return mealNamesTimes[mealTime];
        }

        public void setCafMenu(string fullCafMenu, string dayToday, string cafMeal, string cafTimes)
        {
            int cafDayStartIndex = fullCafMenu.IndexOf("Menu for " + dayToday);
            int cafDayEndIndex = fullCafMenu.IndexOf("</div>", cafDayStartIndex);
            string cafDayMenu = fullCafMenu.Substring(cafDayStartIndex, cafDayEndIndex - cafDayStartIndex);
            cafDayMenu = cafDayMenu.Replace("&nbsp;", " ");

            string displayCafMenu = "";
            int cafMealStartIndex = 0;
            int cafMealEndIndex = 0;

            if (cafDayMenu.IndexOf(cafMeal) != -1)
            {
                cafMealStartIndex = cafDayMenu.IndexOf(cafMeal);

                if (cafDayMenu.Substring(cafMealStartIndex + 10, 14) == "Served at KR's")
                {
                    cafMealStartIndex += 10;
                    cafMealEndIndex = cafDayMenu.IndexOf("</strong>", cafMealStartIndex);
                    cafMealEndIndex = findEndOfHTMLTags(cafDayMenu, cafMealEndIndex);
                }
                else if (cafDayMenu.Substring(cafMealStartIndex, 27) == "Supper served in KR's Place")
                {
                    cafMealEndIndex = cafDayMenu.IndexOf("</strong>", cafMealStartIndex);
                    cafMealEndIndex = findEndOfHTMLTags(cafDayMenu, cafMealEndIndex);
                }
                else
                {
                    cafMealStartIndex = cafDayMenu.IndexOf("<", cafMealStartIndex);
                    cafMealStartIndex = findEndOfHTMLTags(cafDayMenu, cafMealStartIndex);
                    cafMealStartIndex = cafDayMenu.IndexOf("<", cafMealStartIndex);
                    cafMealStartIndex = findEndOfHTMLTags(cafDayMenu, cafMealStartIndex);
                    cafMealEndIndex = cafDayMenu.Length - 1;
                    if (cafDayMenu.IndexOf("<strong>", cafMealStartIndex) != -1)
                    {
                        cafMealEndIndex = cafDayMenu.IndexOf("<strong>", cafMealStartIndex);
                    }
                    if (allCafMeals.IndexOf(cafMeal) < allCafMeals.Count - 1)
                    {
                        int nextMealIndex = cafDayMenu.IndexOf(allCafMeals[allCafMeals.IndexOf(cafMeal) + 1], cafMealStartIndex);
                        if (nextMealIndex < cafMealEndIndex)
                        {
                            cafMealEndIndex = nextMealIndex;
                        }
                    }
                }

                displayCafMenu = cafDayMenu.Substring(cafMealStartIndex, cafMealEndIndex - cafMealStartIndex) + '\n';

                displayCafMenu = displayCafMenu.Replace("&amp;", "&");
                displayCafMenu = displayCafMenu.Replace("<br>", "\n");
                displayCafMenu = Regex.Replace(displayCafMenu, "<[^<>]*>", "");
                displayCafMenu = Regex.Replace(displayCafMenu, @"\s+\z", "");
            }
            else
            {
                displayCafMenu = "No food served here for this meal today";
            }
            string cafLabelText = cafMeal + " at the Cafeteria";
            if (cafMeal == "Supper served in KR's Place")
            {
                cafLabelText = "Supper";
            }
            if (cafTimes != "" && displayCafMenu != "No food served here for this meal today")
            {
                cafLabelText += '\n' + cafTimes;
            }
            CurrentCafMealLabel.Text = cafLabelText;
            CurrentCafLabel.Text = displayCafMenu;
        }

        public void setVMMenu(string fullVMMenu, string dayToday, string VMMeal, string VMTimes)
        {
            int VMDayStartIndex = fullVMMenu.IndexOf("DELI MENU");
            VMDayStartIndex = fullVMMenu.IndexOf(dayToday, VMDayStartIndex);
            int VMDayEndIndex = fullVMMenu.IndexOf("</div>", VMDayStartIndex);
            string VMDayMenu = fullVMMenu.Substring(VMDayStartIndex, VMDayEndIndex - VMDayStartIndex);
            VMDayMenu = VMDayMenu.Replace('\n', ' ');
            VMDayMenu = VMDayMenu.Replace("&nbsp;", " ");

            string displayVMMenu = "";
            int VMMealStartIndex = 0;
            int VMMealEndIndex = 0;

            if (dayToday == "Sabbath")
            {
                CurrentVMMealLabel.Text = "Village Market Deli";
                CurrentVMLabel.Text = "Closed for Sabbath";
                return;
            }

            if (VMDayMenu.IndexOf(VMMeal) != -1)
            {
                VMMealStartIndex = VMDayMenu.IndexOf(VMMeal);
                int[] indexArray = new int[4];
                indexArray[0] = VMDayMenu.IndexOf("m<", VMMealStartIndex); // no space
                indexArray[1] = VMDayMenu.IndexOf("m <", VMMealStartIndex); // space
                indexArray[2] = VMDayMenu.IndexOf("m.<", VMMealStartIndex); // dot
                indexArray[3] = VMDayMenu.IndexOf("m. <", VMMealStartIndex); // dot and space
                int newIndex = -1;
                for (int i = 0; i < 4; i++)
                {
                    if ((newIndex < 0 && indexArray[i] > 0) || (newIndex > 0 && indexArray[i] < newIndex && indexArray[i] > 0))
                    {
                        newIndex = indexArray[i];
                    }
                }
                VMMealStartIndex = newIndex;
                VMMealStartIndex = VMDayMenu.IndexOf("<", VMMealStartIndex);

                if (VMMeal == "g>Deli")
                {
                    VMMealStartIndex = VMDayMenu.IndexOf("Hot Deck", VMMealStartIndex) + 8;
                    VMMeal = "Deli";
                }
                VMMealStartIndex = findEndOfHTMLTags(VMDayMenu, VMMealStartIndex);
                VMMealEndIndex = VMDayMenu.Length - 1;
                //VMMealEndIndex = VMDayMenu.IndexOf("</ul>", VMMealStartIndex);
                if (allVMMeals.IndexOf(VMMeal) < allVMMeals.Count - 1)
                {
                    int nextMealIndex = VMDayMenu.IndexOf(allVMMeals[allVMMeals.IndexOf(VMMeal) + 1], VMMealStartIndex);
                    if (nextMealIndex < VMMealEndIndex)
                    {
                        VMMealEndIndex = nextMealIndex;
                    }
                }
                if (VMDayMenu.IndexOf("</p>", VMMealStartIndex) > 0)
                {
                    VMMealEndIndex = VMDayMenu.IndexOf("</p>", VMMealStartIndex);
                }

                /*if (VMMealEndIndex == -1)
                {
                    VMMealEndIndex = VMDayMenu.Length - 1;
                    List<string> mealList = new List<string> { "Breakfast", "Brunch", "Salad Bar", "Supper" };
                    foreach (string mealName in mealList)
                    {
                        int mealIndex = VMDayMenu.IndexOf(mealName, VMMealStartIndex);
                        if (mealIndex != -1 && mealIndex < VMMealEndIndex && mealName != VMMeal)
                        {
                            VMMealEndIndex = mealIndex;
                        }
                    }
                }*/

                displayVMMenu = VMDayMenu.Substring(VMMealStartIndex, VMMealEndIndex - VMMealStartIndex) + '\n';

                displayVMMenu = displayVMMenu.Replace("&amp;", "&");
                displayVMMenu = displayVMMenu.Replace("&nbsp;", " ");
                displayVMMenu = displayVMMenu.Replace("<br>", "\n");
                displayVMMenu = displayVMMenu.Replace("</li>", "\n");
                displayVMMenu = Regex.Replace(displayVMMenu, @"[^\S\n]{2,}", "");
                displayVMMenu = Regex.Replace(displayVMMenu, @"\n{2,}", "\n");
                displayVMMenu = Regex.Replace(displayVMMenu, @"<[^<>]*>", "");
                displayVMMenu = Regex.Replace(displayVMMenu, @"\s+\z", "");
            }
            else
            {
                displayVMMenu = "No food served here for this meal today";
            }

            string VMLabelText = VMMeal + " at the Village Market Deli";
            if (VMTimes != "" && displayVMMenu != "No food served here for this meal today")
            {
                VMLabelText += '\n' + VMTimes;
            }
            if (VMMeal == "Supper" && VMDayMenu.IndexOf("NO SUPPER") > 0)
            {
                displayVMMenu = "NO SUPPER";
            }
            CurrentVMMealLabel.Text = VMLabelText;
            CurrentVMLabel.Text = displayVMMenu;
        }

        public bool isGreaterThanEndTime(string timeRange, int hour, int minutes)
        {
            int endHour = 24;
            int endMinute = 0;
            int timeIndex = timeRange.IndexOf('-');
            if (timeRange.IndexOf(':', timeIndex) > timeIndex)
            {
                timeIndex++;
                while (timeRange[timeIndex] == ' ')
                {
                    timeIndex++;
                }
                endHour = Convert.ToInt32(timeRange.Substring(timeIndex, timeRange.IndexOf(':', timeIndex) - timeIndex));
                timeIndex = timeRange.IndexOf(':', timeIndex) + 1;
                endMinute = Convert.ToInt32(timeRange.Substring(timeIndex, 2));
                timeIndex += 2;
                while (timeRange[timeIndex] == ' ')
                {
                    timeIndex++;
                }
                if (timeRange.Substring(timeIndex) == "pm" || timeRange.Substring(timeIndex) == "p.m." || timeRange.Substring(timeIndex) == "p.m") 
                {
                    endHour += 12;
                }
                else if (endHour == 12)
                {
                    endHour = 0;
                }
            }
            else
            {
                timeIndex++;
                while (timeRange[timeIndex] == ' ')
                {
                    timeIndex++;
                }
                endHour = Convert.ToInt32(timeRange.Substring(timeIndex, 2));
                timeIndex += 2;
                while (timeRange[timeIndex] == ' ')
                {
                    timeIndex++;
                }
                if (timeRange.Substring(timeIndex) == "pm" || timeRange.Substring(timeIndex) == "p.m." || timeRange.Substring(timeIndex) == "p.m")
                {
                    endHour += 12;
                }
                else if (endHour == 12)
                {
                    endHour = 0;
                }
            }
            return (hour > endHour || (hour == endHour && minutes > endMinute));
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

        public int findBeginOfHTMLTags(string menu, int startIndex)
        {
            int index = startIndex;
            while (menu[index - 1] == '>')
            {
                index = menu.LastIndexOf('<', index - 1);
            }
            return index;
        }

        public string incrementDay(string dayToday)
        {
            switch (dayToday)
            {
                case "Sunday":
                    return "Monday";
                case "Monday":
                    return "Tuesday";
                case "Tuesday":
                    return "Wednesday";
                case "Wednesday":
                    return "Thursday";
                case "Thursday":
                    return "Friday";
                case "Friday":
                    return "Sabbath";
                case "Sabbath":
                    return "Sunday";
                default:
                    return "StarveDay";
            }
        }

        public void clearLabels()
        {
            CurrentCafLabel.Text = "";
            CurrentCafMealLabel.Text = "";
            CurrentVMLabel.Text = "";
            CurrentVMMealLabel.Text = "";
        }

        public void noConnection()
        {
            clearLabels();
            CurrentCafLabel.Text = "Error";
            CurrentCafMealLabel.Text = "Please check your Internet connection";
        }
    }
}