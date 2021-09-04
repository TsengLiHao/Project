namespace Project.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        [StringLength(50)]
        public string Body { get; set; }

        public decimal WeightPerUnit { get; set; }

        public int Discontinued { get; set; }

        [Column(TypeName = "date")]
        public DateTime ManufactureDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }
    }
}
