using Android.App;
using Android.OS;
using System.Threading;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.Entidades;
using MimAcher;

namespace Splash_Screen
{
    //Set MainLauncher = true makes this Activity Shown First on Running this Application  
    //Theme property set the Custom Theme for this Activity  
    //No History= true removes the Activity from BackStack when user navigates away from the Activity  
    [Activity(Label = "MimAcher", MainLauncher = true, Theme = "@style/MyTheme.Splash", NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Display Splash Screen for 4 Sec  
            Thread.Sleep(2000);
            //Start Activity1 Activity  
            StartActivity(typeof(MimAcher.MainActivity));
        }

    }
}




