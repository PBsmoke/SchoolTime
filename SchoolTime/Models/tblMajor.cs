namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMajor")]
    public partial class tblMajor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMajor()
        {
            tblMinors = new HashSet<tblMinor>();
            tblTeachers = new HashSet<tblTeacher>();
        }

        [Key]
        [StringLength(36)]
        public string MajorID { get; set; }

        [Required]
        [StringLength(250)]
        public string MajorCode { get; set; }

        [StringLength(250)]
        public string MajorName { get; set; }

        public string MajorDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMinor> tblMinors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTeacher> tblTeachers { get; set; }
    }
}
