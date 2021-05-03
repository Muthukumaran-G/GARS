using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApp.Interface
{
    public interface IToastMessage
    {
        void ShowToast(string message, AlertDuration Alert = AlertDuration.ShortAlert);
    }

    public enum AlertDuration
    {
        LongAlert,
        ShortAlert
    };
}
