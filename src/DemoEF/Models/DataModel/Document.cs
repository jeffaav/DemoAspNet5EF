using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Document
    {
        public Document()
        {
            DocumentbyFeature = new HashSet<DocumentbyFeature>();
            DocumentbyProject = new HashSet<DocumentbyProject>();
        }

        public int DocumentID { get; set; }
        public string Extension { get; set; }
        public string DocumentName { get; set; }
        public string DocumentURL { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public int DocumentType { get; set; }

        public virtual ICollection<DocumentbyFeature> DocumentbyFeature { get; set; }
        public virtual ICollection<DocumentbyProject> DocumentbyProject { get; set; }
    }
}
