namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgramEnrolment")]
    public partial class ProgramEnrolment
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int? Duration { get; set; }

        public int? FacultyID { get; set; }

        [StringLength(400)]
        public string ProgramName { get; set; }

        public string Requirements { get; set; }

        public double? Tuition { get; set; }
    }
}
