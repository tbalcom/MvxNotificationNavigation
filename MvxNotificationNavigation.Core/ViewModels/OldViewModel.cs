using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Logging;

namespace MvxNotificationNavigation.Core.ViewModels
{
    /// <summary>
    /// Sample ViewModel setup for MvvmCross 4.x navigation.
    /// </summary>
    public class OldViewModel : MvxViewModel
    {
        private readonly IMvxLog _mvxLog;

        public OldViewModel(IMvxLogProvider logProvider)
        {
            _mvxLog = logProvider.GetLogFor<OldViewModel>();
            _mvxLog.Trace("OldViewModel.ctor called");

            CloseCommand = new MvxCommand(OnClose);
        }

        public void Init(int randomNumber, string notificationMessage)
        {
            RandomNumber = randomNumber;
            NotificationMessage = notificationMessage;
            _mvxLog.Trace("OldViewModel.Init called");
        }

        public override void Start()
        {
            base.Start();
            _mvxLog.Trace("OldViewModel.Start called");
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

        public IMvxCommand CloseCommand { get; }

        private void OnClose()
        {
            Close(this);
        }
    }
}
