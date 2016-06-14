using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Application
    {
        public Application()
        {
            Module = new HashSet<Module>();
        }

        public int ApplicationID { get; set; }
        public int ProjectID { get; set; }
        public string ApplicationName { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<Module> Module { get; set; }
        public virtual Project Project { get; set; }
    }
}
