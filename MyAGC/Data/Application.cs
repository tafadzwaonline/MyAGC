namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Application
    {
        public int ID { get; set; }

        public int? ApplicantID { get; set; }

        public int? CollegeID { get; set; }

        public int? ProgramID { get; set; }

        public int? PeriodID { get; set; }

        public int? ApplicationStatusID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApplicationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApprovedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RejectedDate { get; set; }

        [StringLength(200)]
        public string RejectedReason { get; set; }

        public int? AgentID { get; set; }
    }
}
