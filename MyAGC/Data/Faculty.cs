namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faculty")]
    public partial class Faculty
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
