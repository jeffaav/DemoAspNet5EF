using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class AvatarbyUser
    {
        public int AvatarID { get; set; }
        public int UserID { get; set; }
        public int Point { get; set; }
        public bool Selected { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual Avatar Avatar { get; set; }
        public virtual User User { get; set; }
    }
}
