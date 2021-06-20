namespace AMPA_Electronics_Store4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int FEEDBACK_ID { get; set; }

        public string FEEDBACK_ADDRESS { get; set; }

        public int? CUSTOMER_FID { get; set; }

        [StringLength(50)]
        public string FEEDBACK_RATE { get; set; }

        [StringLength(50)]
        public string FEEDBACK_NAME { get; set; }

        public string FEEDBACK_DETAIL { get; set; }

        [StringLength(50)]
        public string FEEDBACK_EMAIL { get; set; }

        [StringLength(50)]
        public string FEEDBACK_CONTACT { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
