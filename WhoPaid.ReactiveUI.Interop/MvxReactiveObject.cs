using System;
using ReactiveUI;

namespace WhoPaid.ReactiveUI.Interop
{
    public class MvxReactiveObject : ReactiveObject
    {
        public bool IsSuppressed { get; private set; }

        public IDisposable SuppressChangeNotificationsInterop()
        {
            IsSuppressed = true;

            var suppressor = SuppressChangeNotifications();

            return new DisposableAction(() =>
            {
                IsSuppressed = false;
                suppressor.Dispose();
            });
        }
    }
}