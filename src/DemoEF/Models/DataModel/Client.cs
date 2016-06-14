using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Client
    {
        public Client()
        {
            Project = new HashSet<Project>();
        }

        public int ClientID { get; set; }
        public string ClienteCode { get; set; }
        public string ClientName { get; set; }

        public virtual ICollection<Project> Project { get; set; }
    }
}
