namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelationType")]
    public partial class RelationType
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
