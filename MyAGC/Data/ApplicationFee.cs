namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApplicationFee
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? CitizenID { get; set; }

        public double? Amount { get; set; }

        public int? AcademicCalendarID { get; set; }
    }
}
