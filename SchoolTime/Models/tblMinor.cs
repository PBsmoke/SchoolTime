namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMinor")]
    public partial class tblMinor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMinor()
        {
            tblStudents = new HashSet<tblStudent>();
        }

        [Key]
        [StringLength(36)]
        public string MinorID { get; set; }

        [Required]
        [StringLength(36)]
        public string MajorID { get; set; }

        [Required]
        [StringLength(250)]
        public string MinorCode { get; set; }

        [StringLength(250)]
        public string MinorName { get; set; }

        public string MinorDetail { get; set; }

        public virtual tblMajor tblMajor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStudent> tblStudents { get; set; }
    }
}
