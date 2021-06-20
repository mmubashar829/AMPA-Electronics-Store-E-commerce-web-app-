namespace AMPA_Electronics_Store4.Models
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FAQS")]
    public partial class FAQS
    {
        [Key]
        public int FAQS_ID { get; set; }
        public string FAQS_QUESTION { get; set; }
        public string FAQS_ANSWER { get; set; }
    }
}
