using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Role
    {
        public Role()
        {
            FeaturebyRole = new HashSet<FeaturebyRole>();
            GenericFeaturebyRole = new HashSet<GenericFeaturebyRole>();
            ModulebyUser = new HashSet<ModulebyUser>();
            UserRole = new HashSet<UserRole>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public decimal? Cost { get; set; }
        public string UrlEnabledIcon { get; set; }
        public string UrlDisabledIcon { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<FeaturebyRole> FeaturebyRole { get; set; }
        public virtual ICollection<GenericFeaturebyRole> GenericFeaturebyRole { get; set; }
        public virtual ICollection<ModulebyUser> ModulebyUser { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
