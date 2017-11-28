using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvxNotificationNavigation.Core.Services;
using MvxNotificationNavigation.Services;

namespace MvxNotificationNavigation
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.RegisterType<INotificationService, AndroidNotificationService>();
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
