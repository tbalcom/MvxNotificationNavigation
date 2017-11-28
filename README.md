# MvxNotificationNavigation

Demonstrates how the MvvmCross 5 `IMvxNavigationService` doesn't seem to account for a scenario where you need to navigate to a `MvxViewModel` from an Android notification via `PendingIntent`.

## Explanation

Sometimes there is a need to show an Android notification to the user that brings up an activity when clicked. MvvmCross versions before 5.0 was able to handle this scenario properly while MvvmCross 5.5 doesn't currently seem to handle this, or the way to do it has changed significantly.

## Instructions

This program presents an activity with two buttons:
- Show Notification for OldViewModel
- Show Notification for NewViewModel

Each button triggers a notification with `SetContentIntent` set so an activity is opened after the notification is clicked. 

1. Click the "Show Notification for OldViewModel" button to trigger the Android notification.
2. Click the Android notification. `OldActivity` will be displayed.
3. Notice how the `RandomNumber` and `Message` passed in to the `INotificationService` are both properly displayed on the screen. You will also see `MvxLog` messages indicating the old navigation methods `Start`, `Init` are called.
4. Click the "Close" button to close `OldActivity`.
5. Click the "Show Notification for NewViewModel" button to trigger the Android notification.
6. Click the Android notification. `NewActivity` will be displayed.
7. Notice how the `RandomNumber` is 0 and the `Message` is `null` (default values). You will also not see `MvxLog` messages indicating the new navigation method `Prepare` is called. `Initialize` is called as expected.
