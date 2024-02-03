namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MyCollege
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int CollegeID { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}
