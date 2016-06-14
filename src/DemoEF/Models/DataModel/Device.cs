using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Device
    {
        public int DeviceID { get; set; }
        public int UserID { get; set; }
        public string DeviceType { get; set; }
        public string NotificationToken { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual User User { get; set; }
    }
}
