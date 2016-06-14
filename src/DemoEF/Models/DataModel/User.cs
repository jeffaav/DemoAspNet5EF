using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class User
    {
        public User()
        {
            AvatarbyUser = new HashSet<AvatarbyUser>();
            Device = new HashSet<Device>();
            Estimation = new HashSet<Estimation>();
            MissingInformation = new HashSet<MissingInformation>();
            ModulebyUser = new HashSet<ModulebyUser>();
            PointHistory = new HashSet<PointHistory>();
            Project = new HashSet<Project>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public int TotalPoints { get; set; }
        public string UrlPhoto { get; set; }
        public int? Genero { get; set; }
        public int AvailablePoints { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<AvatarbyUser> AvatarbyUser { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Estimation> Estimation { get; set; }
        public virtual ICollection<MissingInformation> MissingInformation { get; set; }
        public virtual ICollection<ModulebyUser> ModulebyUser { get; set; }
        public virtual ICollection<PointHistory> PointHistory { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
