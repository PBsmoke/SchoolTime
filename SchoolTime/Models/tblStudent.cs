namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblStudent")]
    public partial class tblStudent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStudent()
        {
            tblCheckINs = new HashSet<tblCheckIN>();
            tblCourseDTs = new HashSet<tblCourseDT>();
        }

        [Key]
        [StringLength(36)]
        public string StudID { get; set; }

        [Required]
        [StringLength(100)]
        public string StudCode { get; set; }

        [StringLength(500)]
        public string FullName { get; set; }

        [StringLength(36)]
        public string MajorID { get; set; }

        [StringLength(36)]
        public string MinorID { get; set; }

        public int? Year { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCheckIN> tblCheckINs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCourseDT> tblCourseDTs { get; set; }

        public virtual tblMinor tblMinor { get; set; }
    }
}
