namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SMSMessageHeader")]
    public partial class SMSMessageHeader
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SendingDate { get; set; }

        [StringLength(800)]
        public string Message { get; set; }

        public int? CreatedBy { get; set; }

        public int? StatusID { get; set; }
    }
}
