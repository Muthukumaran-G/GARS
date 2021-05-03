using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{

    public class FlyoutMainPageFlyoutMenuItem
    {
        public FlyoutMainPageFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutMainPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}