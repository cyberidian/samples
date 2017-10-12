namespace AtomicArcade.DataModels.LookupModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lookups.FeatureCycles")]
    public partial class FeatureCycle
    {
        public int FeatureCycleId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
