using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Logging;
using MvxNotificationNavigation.Core.Models;

namespace MvxNotificationNavigation.Core.ViewModels
{
    /// <summary>
    /// Sample ViewModel setup for MvvmCross 5.x navigation.
    /// </summary>
    public class NewViewModel : MvxViewModel<NotificationModel>
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly IMvxLog _mvxLog;

        public NewViewModel(IMvxNavigationService mvxNavigationService, IMvxLogProvider logProvider)
        {
            _mvxNavigationService = mvxNavigationService;
            _mvxLog = logProvider.GetLogFor<NewViewModel>();
            _mvxLog.Trace("NewViewModel.ctor called");

            CloseCommand = new MvxAsyncCommand(OnCloseAsync);
        }

        public override void Prepare(NotificationModel parameter)
        {
            RandomNumber = parameter.RandomNumber;
            NotificationMessage = parameter.Message;
            _mvxLog.Trace("NewViewModel.Prepare called");
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            _mvxLog.Trace("NewViewModel.Initialize called");
        }

        private int _randomNumber;
        public int RandomNumber
        {
            get => _randomNumber;
            set => SetProperty(ref _randomNumber, value);
        }

        private string _notificationMessage;
        public string NotificationMessage
        {
            get => _notificationMessage;
            set => SetProperty(ref _notificationMessage, value);
        }

        public IMvxAsyncCommand CloseCommand { get; }

        private Task OnCloseAsync()
        {
            return _mvxNavigationService.Close(this);
        }
    }
}
