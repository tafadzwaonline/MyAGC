namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BroadcastEmailList")]
    public partial class BroadcastEmailList
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateSent { get; set; }

        [StringLength(400)]
        public string EmailAddress { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(200)]
        public string Target { get; set; }

        public int? StatusID { get; set; }

        public string Message { get; set; }

        [StringLength(100)]
        public string SenderEmail { get; set; }
    }
}
