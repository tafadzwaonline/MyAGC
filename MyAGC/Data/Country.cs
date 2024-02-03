namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        [StringLength(10)]
        public string CountryCode { get; set; }
    }
}
