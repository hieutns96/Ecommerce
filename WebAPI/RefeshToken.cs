namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RefeshToken")]
    public partial class RefeshToken
    {
        [StringLength(100)]
        public string Id { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(100)]
        public string ClientId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IssuedUtc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiresUtc { get; set; }

        public string ProtectedTicket { get; set; }
    }
}
