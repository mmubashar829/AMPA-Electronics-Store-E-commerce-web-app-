namespace AMPA_Electronics_Store4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TermCondition")]
    public partial class TermCondition
    {
        [Key]
        public int TQ_ID { get; set; }

        public string TQ_TERM { get; set; }

        public string TQ_CONDITION { get; set; }
    }
}
