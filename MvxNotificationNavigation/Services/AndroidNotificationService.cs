using System;
using System.Collections.Generic;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Logging;
using MvxNotificationNavigation.Core.Models;
using MvxNotificationNavigation.Core.Services;
using MvxNotificationNavigation.Core.ViewModels;

namespace MvxNotificationNavigation.Services
{
    public class AndroidNotificationService : INotificationService
    {
        private readonly IMvxLog _mvxLog;
        private const string NotificationChannelId = "General";
        private int _requestCode;

        public AndroidNotificationService(IMvxLogProvider mvxLogProvider)
        {
            _mvxLog = mvxLogProvider.GetLogFor<AndroidNotificationService>();

            SetupNotificationChannels(Application.Context);
        }

        private void SetupNotificationChannels(Context context)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O) // Notification Channels are only supported on Android O (26) and later.
            {
                return;
            }
            var channel = new NotificationChannel(NotificationChannelId, "General Notifications", NotificationImportance.Default);
            channel.SetShowBadge(true);
            channel.EnableLights(true);
            channel.EnableVibration(true);
            channel.LockscreenVisibility = NotificationVisibility.Public;
            channel.Description = "Test Notification Channel";

            var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        public void NotifyOldViewModel(NotificationModel model)
        {
            var context = Application.Context;
            var notification = CreateNotification(context, GetIntentForOldViewModel(model));
            ShowNotification(context, notification);
        }

        public void NotifyNewViewModel(NotificationModel model)
        {
            var context = Application.Context;
            var notification = CreateNotification(context, GetIntentForNewViewModel(model));
            ShowNotification(context, notification);
        }

        private PendingIntent GetIntentForOldViewModel(NotificationModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var request = MvxViewModelRequest<OldViewModel>.GetDefaultRequest();
            request.ParameterValues = new Dictionary<string, string>
            {
                { "randomNumber", model.RandomNumber.ToString() },
                { "notificationMessage", model.Message }
            };
            var translator = Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>();
            var intent = translator.GetIntentFor(request);
            return PendingIntent.GetActivity(Application.Context, _requestCode, intent, PendingIntentFlags.UpdateCurrent);
        }

        private PendingIntent GetIntentForNewViewModel(NotificationModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            // @TODO: Fix this. 
            // Android does show the Activity when the notification is clicked, but Prepare(), Initialize() etc. are not called.

            var request = MvxViewModelRequest<NewViewModel>.GetDefaultRequest();
            request.ParameterValues = new Dictionary<string, string>
            {
                { "randomNumber", model.RandomNumber.ToString() },
                { "notificationMessage", model.Message }
            };
            var translator = Mvx.Resolve<IMvxAndroidViewModelRequestTranslator>();
            var intent = translator.GetIntentFor(request);
            return PendingIntent.GetActivity(Application.Context, _requestCode, intent, PendingIntentFlags.UpdateCurrent);
        }

        private Notification CreateNotification(Context context, PendingIntent pendingIntent)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (pendingIntent == null) throw new ArgumentNullException(nameof(pendingIntent));
            var builder = new Notification.Builder(context)
                .SetSmallIcon(Resource.Mipmap.ic_launcher)
                .SetContentIntent(pendingIntent)
                .SetContentTitle("Notification Test")
                .SetContentText("Hello, World!")
                .SetAutoCancel(true);
            return builder.Build();
        }

        private void ShowNotification(Context context, Notification notification)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (notification == null) throw new ArgumentNullException(nameof(notification));

            _requestCode = Interlocked.Increment(ref _requestCode);

            var notificationMgr = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationMgr.Notify(_requestCode, notification);
        }
    }
}
