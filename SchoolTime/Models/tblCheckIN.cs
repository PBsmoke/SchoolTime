namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCheckIN")]
    public partial class tblCheckIN
    {
        [Key]
        [StringLength(36)]
        public string CheckInID { get; set; }

        [Required]
        [StringLength(36)]
        public string CourseHDID { get; set; }

        [StringLength(36)]
        public string StudID { get; set; }

        public DateTime? TimeCheck { get; set; }

        public int? NumCheck { get; set; }

        public virtual tblCourseHD tblCourseHD { get; set; }

        public virtual tblStudent tblStudent { get; set; }
    }
}
