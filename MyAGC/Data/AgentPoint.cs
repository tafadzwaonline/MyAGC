namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AgentPoint
    {
        public int ID { get; set; }

        public int? AgentID { get; set; }

        public int? ApplicantID { get; set; }

        public int? Points { get; set; }

        public bool? Status { get; set; }

        [Required]
        [StringLength(100)]
        public string DateAdded { get; set; }

        public int? CollegeID { get; set; }

        public int? ProgramID { get; set; }

        public int? PeriodID { get; set; }
    }
}
