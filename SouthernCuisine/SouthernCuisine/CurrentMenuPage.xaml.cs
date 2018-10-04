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
	public partial class CurrentMenuPage : ContentPage
	{
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
                if (CrossConnectivity.Current.IsConnected)
                {
                    setMenus();
                }
                else
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
                if (CrossConnectivity.Current.IsConnected)
                {
                    setMenus();
                }
                else
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
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        setMenus();
                    }
                    else
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
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        setMenus();
                    }
                    else
                    {
                        noConnection();
                    }
                    //BackgroundColor = Color.White;
                }
            };
		}

        public void setMenus()
        {
            WebClient client = new WebClient();
            string fullCafMenu = client.DownloadString("http://www.southern.edu/administration/food/");
            string fullVMMenu = client.DownloadString("http://www.southern.edu/administration/food/deli.html");
            DateTime today = DateTime.Now;
            int hour = today.Hour;
            int minutes = today.Minute;
            string dayToday = today.DayOfWeek.ToString();
            if (dayToday == "Saturday")
            {
                dayToday = "Sabbath";
            }

            string cafMeal = "Breakfast";
            string cafTimes = " 6:30 - 10 a.m.";
            string VMMeal = "Breakfast";
            string VMTimes = " 7:00 a.m. - 9:30 a.m.";

            if (hour < 10)
            {
                cafMeal = "Breakfast";
            }
            else if (hour < 14 || (hour == 14 && minutes < 30))
            {
                cafMeal = "Lunch";
                cafTimes = " 11:30 - 2:30 p.m.";
            }
            else if (hour < 18 || (hour == 18 && minutes < 30))
            {
                cafMeal = "Supper";
                cafTimes = " 5 - 6:30 p.m.";
            }
            else
            {
                dayToday = incrementDay(dayToday);
            }

            if (hour < 9 || (hour == 9 && minutes < 30))
            {
                if (dayToday == "Sunday")
                {
                    VMMeal = "g>Deli";
                }
                else
                {
                    VMMeal = "Breakfast";
                }
            }
            else if (hour < 13 || (hour == 13 && minutes < 30)) 
            {
                VMMeal = "Lunch";
                VMTimes = " 11 a.m. - 1:30 p.m.";
            }
            else if (hour < 19 || (hour == 19 && minutes < 30))
            {
                VMMeal = "Supper";
                VMTimes = " 5 a.m. - 7:30 p.m.";
            }

            //START TestButton Function
            /*if (TestingButton.IsToggled)
            {
                VMMeal = "Lunch";
            }*/
            //END TestButton Function

            int cafDayStartIndex = fullCafMenu.IndexOf("Menu for " + dayToday);
            int cafDayEndIndex = fullCafMenu.IndexOf("</div>", cafDayStartIndex);
            string cafDayMenu = fullCafMenu.Substring(cafDayStartIndex, cafDayEndIndex - cafDayStartIndex);

            int VMDayStartIndex = fullVMMenu.IndexOf("DELI MENU");
            VMDayStartIndex = fullVMMenu.IndexOf(dayToday, VMDayStartIndex);
            int VMDayEndIndex = fullVMMenu.IndexOf("</div>", VMDayStartIndex);
            string VMDayMenu = fullVMMenu.Substring(VMDayStartIndex, VMDayEndIndex - VMDayStartIndex);
            VMDayMenu = VMDayMenu.Replace('\n', ' ');

            string displayCafMenu = "";
            int cafMealStartIndex = 0;
            int cafMealEndIndex = 0;
            string displayVMMenu = "";
            int VMMealStartIndex = 0;
            int VMMealEndIndex = 0;

            if (cafDayMenu.IndexOf(cafMeal) != -1)
            {
                cafMealStartIndex = cafDayMenu.IndexOf(cafMeal);
                cafMealStartIndex = cafDayMenu.IndexOf("m.<", cafMealStartIndex) + 2;
                cafMealStartIndex = findEndOfHTMLTags(cafDayMenu, cafMealStartIndex);
                cafMealEndIndex = cafDayMenu.IndexOf("</p>", cafMealStartIndex);

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

            CurrentCafMealLabel.Text = cafMeal + " at the Cafeteria" + '\n' + cafTimes;
            CurrentCafLabel.Text = displayCafMenu;

            if (dayToday == "Sabbath")
            {
                CurrentVMMealLabel.Text = "Village Market";
                CurrentVMLabel.Text = "No food served here today";
                return;
            }

            if (VMDayMenu.IndexOf(VMMeal) != -1)
            {
                VMMealStartIndex = VMDayMenu.IndexOf(VMMeal);
                if (VMDayMenu.IndexOf("m<", VMMealStartIndex) < 0)
                {
                    if (VMMeal == "g>Deli")
                    {
                        VMMealStartIndex = VMDayMenu.IndexOf("Hot Deck", VMMealStartIndex);
                        VMMeal = "Deli";
                    }
                    else
                    {
                        VMMealStartIndex = VMDayMenu.IndexOf("NO SUPPER", VMMealStartIndex);
                    }
                }
                else
                {
                    VMMealStartIndex = VMDayMenu.IndexOf("m<", VMMealStartIndex) + 1;
                }
                VMMealStartIndex = findEndOfHTMLTags(VMDayMenu, VMMealStartIndex);
                if (VMMeal == "Lunch")
                {
                    VMMealEndIndex = VMDayMenu.IndexOf("SOUP", VMMealStartIndex);
                }
                else
                {
                    VMMealEndIndex = VMDayMenu.IndexOf("</ul>", VMMealStartIndex);
                }

                displayVMMenu = VMDayMenu.Substring(VMMealStartIndex, VMMealEndIndex - VMMealStartIndex) + '\n';

                displayVMMenu = displayVMMenu.Replace("&amp;", "&");
                displayVMMenu = displayVMMenu.Replace("&nbsp;", " ");
                displayVMMenu = displayVMMenu.Replace("<br>", "\n");
                displayVMMenu = displayVMMenu.Replace("</li>", "\n");
                displayVMMenu = Regex.Replace(displayVMMenu, @"[^\S\n]{2,}", "");
                displayVMMenu = Regex.Replace(displayVMMenu, @"<[^<>]*>", "");
                displayVMMenu = Regex.Replace(displayVMMenu, @"\s+\z", "");
            }
            else
            {
                displayVMMenu = "No food served here for this meal today";
            }

            
            CurrentVMMealLabel.Text = VMMeal + " at the Village Market" + '\n' + VMTimes;
            CurrentVMLabel.Text = displayVMMenu;
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
            CurrentCafLabel.Text = "Network connection not detected";
            CurrentCafMealLabel.Text = "Please check your Internet connection";
        }
    }
}