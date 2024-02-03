namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcademicCalendar")]
    public partial class AcademicCalendar
    {
        public int ID { get; set; }

        public int UserID { get; set; }

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

        public DateTime? DateAdded { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApplicationDeadline { get; set; }

        public int? IntakeTypeID { get; set; }

        public bool? Active { get; set; }
    }
}
