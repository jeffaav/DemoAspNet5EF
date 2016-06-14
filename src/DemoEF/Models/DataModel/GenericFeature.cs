using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class GenericFeature
    {
        public GenericFeature()
        {
            Feature = new HashSet<Feature>();
            GenericFeaturebyRole = new HashSet<GenericFeaturebyRole>();
        }

        public int GenericFeatureID { get; set; }
        public string GenericFeatureName { get; set; }
        public decimal? TotalHours { get; set; }
        public int Count { get; set; }

        public virtual ICollection<Feature> Feature { get; set; }
        public virtual ICollection<GenericFeaturebyRole> GenericFeaturebyRole { get; set; }
    }
}
