namespace AtomicArcade.DataModels.Portal.Ads
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("portal.Ads")]
    public partial class Ad
    {
        public int AdId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Priority { get; set; }

        [Required]
        [StringLength(100)]
        public string Link { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ExpirationDate { get; set; }

        public int ClientId { get; set; }

        public int AdCategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string BannerGraphicFile { get; set; }

        public bool Active { get; set; }
    }
}
