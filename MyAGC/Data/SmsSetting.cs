namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmsSetting")]
    public partial class SmsSetting
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(20)]
        public string SenderID { get; set; }

        public int? UserID { get; set; }
    }
}
