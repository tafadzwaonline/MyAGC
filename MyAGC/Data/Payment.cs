namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        public int ID { get; set; }

        public int? ApplicantID { get; set; }

        public int? ProgramID { get; set; }

        public int? PeriodID { get; set; }

        public int? CollegeID { get; set; }

        [StringLength(100)]
        public string UserEmail { get; set; }

        public double? Amount { get; set; }

        [StringLength(400)]
        public string Platform { get; set; }

        [StringLength(20)]
        public string Currency { get; set; }

        [StringLength(400)]
        public string PollUrl { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }

        public int? ReferenceNumber { get; set; }
    }
}
