namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IdentityDocumentType
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string IdentityDocument { get; set; }
    }
}
