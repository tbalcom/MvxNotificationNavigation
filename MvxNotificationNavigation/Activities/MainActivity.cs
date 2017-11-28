using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
using MvxNotificationNavigation.Core.ViewModels;

namespace MvxNotificationNavigation.Activities
{
    [Activity]
    [MvxActivityPresentation]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
        }
    }
}
