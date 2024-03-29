namespace Project.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        public int StockID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int CurrentQuantity { get; set; }

        public int OrderedQuantity { get; set; }

        public int ProductStatus { get; set; }

        public DateTime ChangedDate { get; set; }

        public int? ExpirationQuantity { get; set; }
    }
}
