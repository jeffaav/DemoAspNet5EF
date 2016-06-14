using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class MissingInformation
    {
        public int MissingInformationID { get; set; }
        public int FeatureID { get; set; }
        public int UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual User User { get; set; }
    }
}
