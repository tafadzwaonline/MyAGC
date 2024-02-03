using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyAGC.Data
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AcademicCalendar> AcademicCalendars { get; set; }
        public virtual DbSet<AcademicHistory> AcademicHistories { get; set; }
        public virtual DbSet<AgentPoint> AgentPoints { get; set; }
        public virtual DbSet<ApplicationFee> ApplicationFees { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationStatu> ApplicationStatus { get; set; }
        public virtual DbSet<CertificateFileUpload> CertificateFileUploads { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DisabilityType> DisabilityTypes { get; set; }
        public virtual DbSet<EmailSetting> EmailSettings { get; set; }
        public virtual DbSet<ExaminationBody> ExaminationBodies { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<IntakeType> IntakeTypes { get; set; }
        public virtual DbSet<MaritalStatu> MaritalStatus { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<MyCollege> MyColleges { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProgramEnrolment> ProgramEnrolments { get; set; }
        public virtual DbSet<ProgramType> ProgramTypes { get; set; }
        public virtual DbSet<ProofOfPaymentUpload> ProofOfPaymentUploads { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RelationType> RelationTypes { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SchoolLevel> SchoolLevels { get; set; }
        public virtual DbSet<SmsSetting> SmsSettings { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<UniversityType> UniversityTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<BroadcastEmailList> BroadcastEmailLists { get; set; }
        public virtual DbSet<BroadcastListContact> BroadcastListContacts { get; set; }
        public virtual DbSet<BroadcastMessagesList> BroadcastMessagesLists { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<IdentityDocumentType> IdentityDocumentTypes { get; set; }
        public virtual DbSet<SMSMessageHeader> SMSMessageHeaders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentPoint>()
                .Property(e => e.DateAdded)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationStatu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Certificate>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Citizen>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryCode)
                .IsFixedLength();

            modelBuilder.Entity<DisabilityType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSetting>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSetting>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<EmailSetting>()
                .Property(e => e.Host)
                .IsUnicode(false);

            modelBuilder.Entity<ExaminationBody>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Faculty>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<IntakeType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Month>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProgramType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Religion>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolLevel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SmsSetting>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SmsSetting>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<SmsSetting>()
                .Property(e => e.SenderID)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UniversityType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Year>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.DocumentName)
                .IsUnicode(false);

            modelBuilder.Entity<IdentityDocumentType>()
                .Property(e => e.IdentityDocument)
                .IsUnicode(false);
        }
    }
}
