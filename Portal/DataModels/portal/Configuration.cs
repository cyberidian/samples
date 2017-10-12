namespace AtomicArcade.DataModels.Portal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("portal.Configuration")]
    public partial class Configuration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConfigId { get; set; }

        public int AdCycle { get; set; }

        public int FeatureCycle { get; set; }

        public bool ShowTechNotes { get; set; }

        public bool RequireLogin { get; set; }
    }
}
