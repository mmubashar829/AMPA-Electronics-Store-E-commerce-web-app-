namespace AMPA_Electronics_Store4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int ADMIN_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_USERNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_CONTACT { get; set; }

        [Required]
        public string ADMIN_ADDRESS { get; set; }
    }
}
