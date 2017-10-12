namespace AtomicArcade.DataModels.Portal.Ads
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("portal.AdClients")]
    public partial class AdClient
    {
        public int AdClientId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Organization { get; set; }

        public bool? Active { get; set; }
    }
}
