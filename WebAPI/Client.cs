namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [StringLength(100)]
        public string Id { get; set; }

        [StringLength(100)]
        public string Secret { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool? ApplicationType { get; set; }

        public bool? Active { get; set; }

        public int? RefreshTokenLifeTime { get; set; }

        [StringLength(100)]
        public string AllowedOrigin { get; set; }
    }
}
