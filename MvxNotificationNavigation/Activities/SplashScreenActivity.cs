using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace MvxNotificationNavigation.Activities
{
    [Activity(MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.activity_splash)
        {
        }
    }
}
