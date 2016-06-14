using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class UserRole
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
