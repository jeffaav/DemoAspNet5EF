using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class ModulebyUser
    {
        public int ModuleByUserID { get; set; }
        public int UserID { get; set; }
        public int ModuleID { get; set; }
        public int RoleID { get; set; }
        public DateTime Reservation { get; set; }
        public int Status { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual Module Module { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
