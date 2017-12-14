namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTeacher")]
    public partial class tblTeacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTeacher()
        {
            tblCourseHDs = new HashSet<tblCourseHD>();
        }

        [Key]
        [StringLength(36)]
        public string teachID { get; set; }

        [Required]
        [StringLength(100)]
        public string teachCode { get; set; }

        [StringLength(500)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string Education { get; set; }

        [StringLength(500)]
        public string Position { get; set; }

        [StringLength(500)]
        public string Expert { get; set; }

        [StringLength(36)]
        public string MajorID { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCourseHD> tblCourseHDs { get; set; }

        public virtual tblMajor tblMajor { get; set; }
    }
}
