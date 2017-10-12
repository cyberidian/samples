namespace AtomicArcade.DataModels.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("content.Categories")]
    public partial class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? SortOrder { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(100)]
        public string BannerGraphicFile { get; set; }
    }
}
