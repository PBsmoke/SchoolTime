namespace SchoolTime.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SchoolTime.Models;

    public partial class SchoolTimeContext : DbContext
    {
        public SchoolTimeContext()
            : base("name=SchoolTimeContext")
        {
        }

        public virtual DbSet<tblCheckIN> tblCheckINs { get; set; }
        public virtual DbSet<tblCourseDT> tblCourseDTs { get; set; }
        public virtual DbSet<tblCourseHD> tblCourseHDs { get; set; }
        public virtual DbSet<tblMajor> tblMajors { get; set; }
        public virtual DbSet<tblMinor> tblMinors { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
        public virtual DbSet<tblSuject> tblSujects { get; set; }
        public virtual DbSet<tblTeacher> tblTeachers { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<uv_Course> uv_Course { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCheckIN>()
                .Property(e => e.CheckInID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCheckIN>()
                .Property(e => e.CourseHDID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCheckIN>()
                .Property(e => e.StudID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseDT>()
                .Property(e => e.CourseDTID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseDT>()
                .Property(e => e.CourseHDID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseDT>()
                .Property(e => e.StudID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseHD>()
                .Property(e => e.CourseHDID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseHD>()
                .Property(e => e.SujectID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseHD>()
                .Property(e => e.CourseCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseHD>()
                .Property(e => e.teachID)
                .IsUnicode(false);

            modelBuilder.Entity<tblCourseHD>()
                .HasMany(e => e.tblCheckINs)
                .WithRequired(e => e.tblCourseHD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblMajor>()
                .Property(e => e.MajorID)
                .IsUnicode(false);

            modelBuilder.Entity<tblMajor>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblMajor>()
                .Property(e => e.MajorName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMajor>()
                .Property(e => e.MajorDetail)
                .IsUnicode(false);

            modelBuilder.Entity<tblMinor>()
                .Property(e => e.MinorID)
                .IsUnicode(false);

            modelBuilder.Entity<tblMinor>()
                .Property(e => e.MajorID)
                .IsUnicode(false);

            modelBuilder.Entity<tblMinor>()
                .Property(e => e.MinorCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblMinor>()
                .Property(e => e.MinorName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMinor>()
                .Property(e => e.MinorDetail)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.StudID)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.StudCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.MajorID)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.MinorID)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblStudent>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tblSuject>()
                .Property(e => e.SujectID)
                .IsUnicode(false);

            modelBuilder.Entity<tblSuject>()
                .Property(e => e.SujectCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblSuject>()
                .Property(e => e.SujectName)
                .IsUnicode(false);

            modelBuilder.Entity<tblSuject>()
                .Property(e => e.SujectDetail)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.teachID)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.teachCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.Education)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.Expert)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.MajorID)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeacher>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.relateID)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.relateTable)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.CourseHDID)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.CourseCode)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.teachID)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.teachCode)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.FullNameT)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.SujectID)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.SujectCode)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.SujectName)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.CourseDTID)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.StudID)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.StudCode)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.FullNameS)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.MinorID)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.MinorCode)
                .IsUnicode(false);

            modelBuilder.Entity<uv_Course>()
                .Property(e => e.MinorName)
                .IsUnicode(false);
        }
    }
}
