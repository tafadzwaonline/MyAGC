namespace MyAGC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CertificateFileUpload
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? UserID { get; set; }

        public int? CertificateID { get; set; }
    }
}
