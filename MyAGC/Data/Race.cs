namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Race
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
