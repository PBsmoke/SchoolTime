namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCourseHD")]
    public partial class tblCourseHD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCourseHD()
        {
            tblCheckINs = new HashSet<tblCheckIN>();
            tblCourseDTs = new HashSet<tblCourseDT>();
        }

        [Key]
        [StringLength(36)]
        public string CourseHDID { get; set; }

        [StringLength(36)]
        public string SujectID { get; set; }

        //[Required]
        [StringLength(250)]
        public string CourseCode { get; set; }

        public int? CourseYear { get; set; }

        public int? Semester { get; set; }

        //[Required]
        [StringLength(36)]
        public string teachID { get; set; }

        public int TimeStart { get; set; }

        //[Required]
        public string TimeStart_txt { get; set; }

        public int TimeEnd { get; set; }

        //[Required]
        public string TimeEnd_txt { get; set; }

        public int? TimeLate { get; set; }

        public int? NumCheckIN { get; set; }

        public int? Entitled { get; set; }

        public int? NotEntitled { get; set; }

        public int? Contact { get; set; }

        public bool IsClose { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCheckIN> tblCheckINs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCourseDT> tblCourseDTs { get; set; }

        public virtual tblSuject tblSuject { get; set; }

        public virtual tblTeacher tblTeacher { get; set; }
    }
}
