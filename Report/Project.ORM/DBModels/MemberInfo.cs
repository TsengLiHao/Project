namespace Project.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberInfo")]
    public partial class MemberInfo
    {
        [Key]
        public int UserID { get; set; }

        public Guid MemberID { get; set; }

        [Required]
        [StringLength(50)]
        public string MemberName { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string PWD { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string MobilePhone { get; set; }

        [Required]
        [StringLength(50)]
        public string Adress { get; set; }

        public int UserLevel { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
