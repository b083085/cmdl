using System;
using System.ComponentModel;

namespace CMDLWpf
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        #region Inotifypropertychanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
