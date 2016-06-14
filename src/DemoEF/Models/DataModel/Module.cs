using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Module
    {
        public Module()
        {
            Feature = new HashSet<Feature>();
            ModulebyUser = new HashSet<ModulebyUser>();
        }

        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public int ApplicationID { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<Feature> Feature { get; set; }
        public virtual ICollection<ModulebyUser> ModulebyUser { get; set; }
        public virtual Application Application { get; set; }
    }
}
