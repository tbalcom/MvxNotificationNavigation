using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
using MvxNotificationNavigation.Core.ViewModels;

namespace MvxNotificationNavigation.Activities
{
    [MvxActivityPresentation]
    [Activity]
    public class OldActivity : MvxActivity<OldViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_notification_model);
        }
    }
}
