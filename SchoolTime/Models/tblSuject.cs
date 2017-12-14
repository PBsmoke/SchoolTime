namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSuject")]
    public partial class tblSuject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSuject()
        {
            tblCourseHDs = new HashSet<tblCourseHD>();
        }

        [Key]
        [StringLength(36)]
        public string SujectID { get; set; }

        [Required]
        [StringLength(250)]
        public string SujectCode { get; set; }

        [StringLength(250)]
        public string SujectName { get; set; }

        public string SujectDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCourseHD> tblCourseHDs { get; set; }
    }
}
