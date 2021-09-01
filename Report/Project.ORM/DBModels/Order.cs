namespace Project.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int UnitPrice { get; set; }

        public int Payment { get; set; }

        public Guid MemberID { get; set; }

        public int OrderedQuantity { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ChangedDate { get; set; }
    }
}
