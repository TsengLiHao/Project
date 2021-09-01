namespace Project.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminInfo")]
    public partial class AdminInfo
    {
        [Key]
        public Guid AdminID { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminAccount { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPWD { get; set; }

        public int UserLevel { get; set; }
    }
}
