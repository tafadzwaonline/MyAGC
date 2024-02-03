namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailSetting")]
    public partial class EmailSetting
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Host { get; set; }

        public int? Port { get; set; }

        public int? UserID { get; set; }
    }
}
