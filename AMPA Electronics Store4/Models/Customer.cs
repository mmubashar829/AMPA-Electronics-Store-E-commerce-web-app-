namespace AMPA_Electronics_Store4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public int CUSTOMER_ID { get; set; }

        [StringLength(50)]
        public string CUSTOMER_NAME { get; set; }

        [StringLength(50)]
        public string CUSTOMER_EMAIL { get; set; }

        [StringLength(50)]
        public string CUSTOMER_ADDRESS { get; set; }

        [StringLength(50)]
        public string CUSTOMER_CONTACT { get; set; }

        [StringLength(50)]
        public string CUSTOMER_PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
