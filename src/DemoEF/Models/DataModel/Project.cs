using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Project
    {
        public Project()
        {
            Application = new HashSet<Application>();
            DocumentbyProject = new HashSet<DocumentbyProject>();
        }

        public int ProjectID { get; set; }
        public int ClientID { get; set; }
        public int CreatorUserID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAlias { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TotalHours { get; set; }
        public int Status { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<DocumentbyProject> DocumentbyProject { get; set; }
        public virtual Client Client { get; set; }
        public virtual User CreatorUser { get; set; }
    }
}
