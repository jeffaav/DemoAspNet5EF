using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Avatar
    {
        public Avatar()
        {
            AvatarbyUser = new HashSet<AvatarbyUser>();
        }

        public int AvatarID { get; set; }
        public int AvatarTypeID { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public string UrlAvatar { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<AvatarbyUser> AvatarbyUser { get; set; }
    }
}
