﻿using System;
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
        //public bool isNightMode;

        public PreferencesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Application.Current.Properties.TryGetValue("nightMode", out object isNightMode);
            Appearing += (object sender, EventArgs e) =>
            {
                if (Convert.ToBoolean(Application.Current.Properties["nightMode"]) == false)
                {
                    DayNightSwitch.IsToggled = false;
                    //AboutLabel.TextColor = Color.Black;
                    nightSwitchLabel.TextColor = Color.Black;
                    //BackgroundColor = Color.White;
                    Application.Current.MainPage.BackgroundColor = Color.White;
                }
                else
                {
                    DayNightSwitch.IsToggled = true;
                    //AboutLabel.TextColor = Color.White;
                    nightSwitchLabel.TextColor = Color.White;
                    //BackgroundColor = Color.Black;
                    Application.Current.MainPage.BackgroundColor = Color.Black;
                }
            };
        }

        void DayNightSwitch_Toggled(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Application.Current.Properties["nightMode"]) && DayNightSwitch.IsToggled == false)
            {
                //AboutLabel.TextColor = Color.Black;
                nightSwitchLabel.TextColor = Color.Black;
                
                //BackgroundColor = Color.White;
                Application.Current.MainPage.BackgroundColor = Color.White;
                Application.Current.Properties["nightMode"] = false;
            }
            else
            {
                //AboutLabel.TextColor = Color.White;
                nightSwitchLabel.TextColor = Color.White;
                //BackgroundColor = Color.Black;
                Application.Current.MainPage.BackgroundColor = Color.Black;
                Application.Current.Properties["nightMode"] = true;
            }
        }
    }
}