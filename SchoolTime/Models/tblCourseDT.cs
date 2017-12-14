namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCourseDT")]
    public partial class tblCourseDT
    {
        [Key]
        [StringLength(36)]
        public string CourseDTID { get; set; }

        [StringLength(36)]
        public string CourseHDID { get; set; }

        [StringLength(36)]
        public string StudID { get; set; }

        public virtual tblCourseHD tblCourseHD { get; set; }

        public virtual tblStudent tblStudent { get; set; }
    }
}
