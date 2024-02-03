namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BroadcastListContact
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BroadcastListID { get; set; }

        public int? UserID { get; set; }

        [StringLength(500)]
        public string EmailAddress { get; set; }

        [StringLength(500)]
        public string MobileNo { get; set; }

        public int? StatusID { get; set; }
    }
}
