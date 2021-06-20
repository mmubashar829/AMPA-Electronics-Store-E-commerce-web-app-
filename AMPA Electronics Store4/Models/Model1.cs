namespace AMPA_Electronics_Store4.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FAQS> FAQSs { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<TermCondition> TermConditions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CATEGORY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Feedbacks)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CUSTOMER_FID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CUSTOMER_FID);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.FEEDBACK_DETAIL)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.FEEDBACK_EMAIL)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.FEEDBACK_CONTACT)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.PURCHASE_PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.ORDER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.PRODUCT_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
