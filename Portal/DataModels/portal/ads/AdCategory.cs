namespace AtomicArcade.DataModels.Portal.Ads
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("portal.AdCategories")]
    public partial class AdCategory
    {
        public int AdCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SortOrder { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string BannerGraphicFile { get; set; }

        public bool Active { get; set; }
    }
}
