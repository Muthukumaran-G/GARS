using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms.Maps;

namespace GarageApp.Controls
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }

    public class CustomPin : Pin
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
