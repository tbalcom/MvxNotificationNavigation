using MvvmCross.Platform.IoC;

namespace MvxNotificationNavigation.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterNavigationServiceAppStart<ViewModels.MainViewModel>();
        }
    }
}
