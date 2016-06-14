using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class DocumentbyFeature
    {
        public int DocumentID { get; set; }
        public int FeatureID { get; set; }

        public virtual Document Document { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
