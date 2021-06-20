namespace AMPA_Electronics_Store4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [Key]
        public int COMPANY_ID { get; set; }

        [StringLength(50)]
        public string COMPANY_NAME { get; set; }

        [StringLength(50)]
        public string COMPANY_EMAIL { get; set; }

        [StringLength(50)]
        public string COMPANY_CONTACT { get; set; }

        [StringLength(200)]
        public string COMPANY_ADDRESS { get; set; }

        [StringLength(200)]
        public string COMPANY_LOGO { get; set; }
        [NotMapped]
        public HttpPostedFileBase COMP_LOGO { get; set; }

        public string COMPANY_MENIFESTO { get; set; }
    }
}
