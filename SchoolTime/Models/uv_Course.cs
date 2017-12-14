namespace SchoolTime.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class uv_Course
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(36)]
        public string CourseHDID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string CourseCode { get; set; }

        public int? CourseYear { get; set; }

        public int? Semester { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(36)]
        public string teachID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string teachCode { get; set; }

        [StringLength(500)]
        public string FullNameT { get; set; }

        [StringLength(36)]
        public string SujectID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(250)]
        public string SujectCode { get; set; }

        [StringLength(250)]
        public string SujectName { get; set; }

        [Key]
        [Column(Order = 5)]
        public string TimeStart_txt { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeStart { get; set; }

        [Key]
        [Column(Order = 7)]
        public string TimeEnd_txt { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeEnd { get; set; }

        public bool IsClose { get; set; }

        public int? TimeLate { get; set; }

        public int? NumCheckIN { get; set; }

        public int? Entitled { get; set; }

        public int? NotEntitled { get; set; }

        public int? Contact { get; set; }

        [StringLength(36)]
        public string CourseDTID { get; set; }

        [StringLength(36)]
        public string StudID { get; set; }

        [StringLength(100)]
        public string StudCode { get; set; }

        [StringLength(500)]
        public string FullNameS { get; set; }

        [StringLength(36)]
        public string MinorID { get; set; }

        [StringLength(250)]
        public string MinorCode { get; set; }

        [StringLength(250)]
        public string MinorName { get; set; }
    }
}
