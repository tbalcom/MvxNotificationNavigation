using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Logging;
using MvxNotificationNavigation.Core.Models;
using MvxNotificationNavigation.Core.Services;

namespace MvxNotificationNavigation.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly INotificationService _notificationService;
        private readonly IMvxLog _mvxLog;

        public MainViewModel(INotificationService notificationService, IMvxLogProvider logProvider)
        {
            _notificationService = notificationService;
            _mvxLog = logProvider.GetLogFor<MainViewModel>();

            OldViewModelCommand = new MvxCommand(NotifyOldViewModel);
            NewViewModelCommand = new MvxCommand(NotifyNewViewModel);
        }

        public IMvxCommand OldViewModelCommand { get; }

        private void NotifyOldViewModel()
        {
            var rng = RandomInt((int)DateTime.UtcNow.Ticks);
            var msg = "Showing old ViewModel.";
            _mvxLog.Trace($"Showing notification to trigger OldViewModel with args \"{msg}\" \"{rng}\"");
            _notificationService.NotifyOldViewModel(new NotificationModel
            {
                Message = msg,
                RandomNumber = rng
            });
        }

        public IMvxCommand NewViewModelCommand { get; }

        private void NotifyNewViewModel()
        {
            var rng = RandomInt((int)DateTime.UtcNow.Ticks);
            var msg = "Showing new ViewModel.";
            _mvxLog.Trace($"Showing notification to trigger NewViewModel with args \"{msg}\" \"{rng}\"");
            _notificationService.NotifyNewViewModel(new NotificationModel
            {
                Message = msg,
                RandomNumber = rng
            });
        }

        private int RandomInt(int seed)
        {
            return new Random(seed).Next(int.MinValue, int.MaxValue);
        }
    }
}
