using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class PointHistory
    {
        public int PointHistoryID { get; set; }
        public int UserID { get; set; }
        public int FeautureID { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Quantity { get; set; }

        public virtual User User { get; set; }
    }
}
