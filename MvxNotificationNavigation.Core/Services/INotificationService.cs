using MvxNotificationNavigation.Core.Models;

namespace MvxNotificationNavigation.Core.Services
{
    public interface INotificationService
    {
        void NotifyOldViewModel(NotificationModel notification);
        void NotifyNewViewModel(NotificationModel notification);
    }
}
