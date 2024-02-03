namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcademicHistory")]
    public partial class AcademicHistory
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(200)]
        public string SchoolName { get; set; }

        public int? SchoolLevel { get; set; }

        [Required]
        [StringLength(10)]
        public string StartDateMonth { get; set; }

        [StringLength(10)]
        public string StartDateYear { get; set; }

        [Required]
        [StringLength(10)]
        public string EndDateMonth { get; set; }

        [StringLength(10)]
        public string EndDateYear { get; set; }

        public int? SubjectsPassedNo { get; set; }

        public int? ExaminationBody { get; set; }

        public string Activities { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}
