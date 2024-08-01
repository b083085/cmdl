using System;

namespace CMDL.Core
{
    internal static class EventRaiser
    {
        public static void Raise(this EventHandler handler, object sender)
        {
            handler?.Invoke(sender, EventArgs.Empty);
        }
    }
}
