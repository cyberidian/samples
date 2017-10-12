namespace AtomicArcade.DataModels.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("content.Games")]
    public partial class Game
    {
        public int GameId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Link { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [StringLength(50)]
        public string Graphic400x200 { get; set; }

        [Required]
        [StringLength(50)]
        public string Graphic200x100 { get; set; }

        [StringLength(50)]
        public string Graphic100x100 { get; set; }

        [Column(TypeName = "text")]
        public string TechNotes { get; set; }

        [StringLength(50)]
        public string Developer { get; set; }

        public bool? Featured { get; set; }

        public int? Priority { get; set; }

        public bool Active { get; set; }
    }
}
