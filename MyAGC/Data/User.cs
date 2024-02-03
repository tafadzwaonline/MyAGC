namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        public int RoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Mobile { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(5000)]
        public string Password { get; set; }

        public bool? Active { get; set; }

        public DateTime? DateAdded { get; set; }

        public byte[] Image { get; set; }

        public int? VerificationCode { get; set; }

        public int? GenderID { get; set; }

        public int? CountryID { get; set; }

        public int? RaceID { get; set; }

        public int? ReligionID { get; set; }

        public int? TitleID { get; set; }

        public int? DisabilityID { get; set; }

        [StringLength(100)]
        public string NextKinMobile { get; set; }

        [StringLength(200)]
        public string NextKinFullName { get; set; }

        [StringLength(200)]
        public string NextKinAddress { get; set; }

        public int? NextKinRelationID { get; set; }

        public int? IdentityDocumentTypeID { get; set; }

        [StringLength(200)]
        public string IdentityNumber { get; set; }

        public int? UniversityType { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(400)]
        public string MissionStatement { get; set; }

        [StringLength(100)]
        public string WebSiteUrl { get; set; }

        [StringLength(100)]
        public string Facebooklink { get; set; }

        [StringLength(100)]
        public string TwitterLink { get; set; }

        public int? AgentID { get; set; }
    }
}
