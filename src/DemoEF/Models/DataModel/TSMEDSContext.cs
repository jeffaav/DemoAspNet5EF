using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoEF.Models.DataModel
{
    public partial class TSMEDSContext : DbContext
    {
        public TSMEDSContext(DbContextOptions<TSMEDSContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.ProjectID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Application_Project");
            });

            modelBuilder.Entity<Avatar>(entity =>
            {
                entity.Property(e => e.AvatarID).ValueGeneratedNever();

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UrlAvatar)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<AvatarbyUser>(entity =>
            {
                entity.HasKey(e => new { e.AvatarID, e.UserID })
                    .HasName("PK_AvatarbyUser");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.Avatar)
                    .WithMany(p => p.AvatarbyUser)
                    .HasForeignKey(d => d.AvatarID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AvatarbyUser_Avatar");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AvatarbyUser)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AvatarbyUser_User");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ClienteCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceType)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.NotificationToken)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Device_User");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DocumentURL)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<DocumentbyFeature>(entity =>
            {
                entity.HasKey(e => new { e.DocumentID, e.FeatureID })
                    .HasName("PK_DocumentbyFeature");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentbyFeature)
                    .HasForeignKey(d => d.DocumentID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DocumentbyFeature_Document");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.DocumentbyFeature)
                    .HasForeignKey(d => d.FeatureID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DocumentbyFeature_Feature");
            });

            modelBuilder.Entity<DocumentbyProject>(entity =>
            {
                entity.HasKey(e => new { e.DocumentID, e.ProjectID })
                    .HasName("PK_DocumentbyProject");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentbyProject)
                    .HasForeignKey(d => d.DocumentID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DocumentbyProject_Document");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.DocumentbyProject)
                    .HasForeignKey(d => d.ProjectID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DocumentbyProject_Project");
            });

            modelBuilder.Entity<Estimation>(entity =>
            {
                entity.Property(e => e.EstimationID).ValueGeneratedNever();

                entity.Property(e => e.EstimationDate).HasColumnType("date");

                entity.Property(e => e.Hours).HasColumnType("decimal");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.EstimationUser)
                    .WithMany(p => p.Estimation)
                    .HasForeignKey(d => d.EstimationUserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Estimation_User");

                entity.HasOne(d => d.FeaturebyRole)
                    .WithMany(p => p.Estimation)
                    .HasForeignKey(d => new { d.RoleID, d.FeatureID })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Estimation_FeaturebyRole");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.Property(e => e.FeatureName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.TotalHours).HasColumnType("decimal");

                entity.HasOne(d => d.GenericFeature)
                    .WithMany(p => p.Feature)
                    .HasForeignKey(d => d.GenericFeatureID)
                    .HasConstraintName("FK_Feature_GenericFeature");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Feature)
                    .HasForeignKey(d => d.ModuleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Feature_Module");
            });

            modelBuilder.Entity<FeaturebyRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleID, e.FeatureID })
                    .HasName("PK_FeaturebyRole");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.FeaturebyRole)
                    .HasForeignKey(d => d.FeatureID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FeaturebyRole_Feature");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.FeaturebyRole)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FeaturebyRole_Role");
            });

            modelBuilder.Entity<GenericFeature>(entity =>
            {
                entity.Property(e => e.Count).HasDefaultValueSql("0");

                entity.Property(e => e.GenericFeatureName).HasColumnType("varchar(100)");

                entity.Property(e => e.TotalHours).HasColumnType("decimal");
            });

            modelBuilder.Entity<GenericFeaturebyRole>(entity =>
            {
                entity.HasKey(e => new { e.GenericFeatureID, e.RoleID })
                    .HasName("PK_GenericFeaturebyRole");

                entity.Property(e => e.Count).HasDefaultValueSql("0");

                entity.Property(e => e.TotalHours).HasColumnType("decimal");

                entity.HasOne(d => d.GenericFeature)
                    .WithMany(p => p.GenericFeaturebyRole)
                    .HasForeignKey(d => d.GenericFeatureID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GenericFeaturebyRole_GenericFeature");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.GenericFeaturebyRole)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_GenericFeaturebyRole_Role");
            });

            modelBuilder.Entity<MissingInformation>(entity =>
            {
                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.MissingInformation)
                    .HasForeignKey(d => d.FeatureID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MissingInformation_Feature");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MissingInformation)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MissingInformation_User");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.ApplicationID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Module_Application");
            });

            modelBuilder.Entity<ModulebyUser>(entity =>
            {
                entity.Property(e => e.ModuleByUserID).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Reservation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModulebyUser)
                    .HasForeignKey(d => d.ModuleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ModulebyUser_Module");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ModulebyUser)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ModulebyUser_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ModulebyUser)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ModulebyUser_User");
            });

            modelBuilder.Entity<PointHistory>(entity =>
            {
                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PointHistory)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PointHistory_User");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.ProjectAlias).HasMaxLength(100);

                entity.Property(e => e.ProjectDescription).IsRequired();

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("1");

                entity.Property(e => e.TotalCost)
                    .HasColumnType("decimal")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.TotalHours)
                    .HasColumnType("decimal")
                    .HasDefaultValueSql("0.0");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ClientID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Project_Client");

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.CreatorUserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Project_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("decimal");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UrlDisabledIcon).HasColumnType("varchar(250)");

                entity.Property(e => e.UrlEnabledIcon).HasColumnType("varchar(250)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName).HasColumnType("varchar(100)");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Password).HasColumnType("varchar(100)");

                entity.Property(e => e.UrlPhoto).HasColumnType("varchar(max)");

                entity.Property(e => e.UserName).HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.RoleID })
                    .HasName("PK_UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.diagram_id)
                    .HasName("PK__sysdiagr__C2B05B613188C8E6");

                entity.HasIndex(e => new { e.principal_id, e.name })
                    .HasName("UK_principal_name")
                    .IsUnique();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("sysname");
            });
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Avatar> Avatar { get; set; }
        public virtual DbSet<AvatarbyUser> AvatarbyUser { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentbyFeature> DocumentbyFeature { get; set; }
        public virtual DbSet<DocumentbyProject> DocumentbyProject { get; set; }
        public virtual DbSet<Estimation> Estimation { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<FeaturebyRole> FeaturebyRole { get; set; }
        public virtual DbSet<GenericFeature> GenericFeature { get; set; }
        public virtual DbSet<GenericFeaturebyRole> GenericFeaturebyRole { get; set; }
        public virtual DbSet<MissingInformation> MissingInformation { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModulebyUser> ModulebyUser { get; set; }
        public virtual DbSet<PointHistory> PointHistory { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}