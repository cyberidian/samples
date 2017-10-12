namespace AtomicArcade.DataModels.LookupModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lookups.AdCycles")]
    public partial class AdCycle
    {
        public int AdCycleId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
