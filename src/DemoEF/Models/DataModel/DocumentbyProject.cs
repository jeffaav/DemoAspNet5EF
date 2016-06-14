using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class DocumentbyProject
    {
        public int DocumentID { get; set; }
        public int ProjectID { get; set; }

        public virtual Document Document { get; set; }
        public virtual Project Project { get; set; }
    }
}
