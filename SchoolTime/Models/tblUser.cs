namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        [Key]
        [StringLength(36)]
        public string UserID { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string relateID { get; set; }

        [StringLength(50)]
        public string relateTable { get; set; }

        public string Remark { get; set; }
    }
}
