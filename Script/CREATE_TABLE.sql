/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.600)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [SchoolTime]
GO
/****** Object:  Table [dbo].[tblCheckIN]    Script Date: 9/16/2017 10:43:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCheckIN](
	[CheckInID] [varchar](36) NOT NULL,
	[CourseHDID] [varchar](36) NOT NULL,
	[StudID] [varchar](36) NULL,
	[TimeCheck] [datetime] NULL,
	[NumCheck] [int] NULL,
 CONSTRAINT [PK_dbo.tblCheckIN] PRIMARY KEY CLUSTERED 
(
	[CheckInID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCourseDT]    Script Date: 9/16/2017 10:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourseDT](
	[CourseDTID] [varchar](36) NOT NULL,
	[CourseHDID] [varchar](36) NULL,
	[StudID] [varchar](36) NULL,
 CONSTRAINT [PK_dbo.tblCourseDT] PRIMARY KEY CLUSTERED 
(
	[CourseDTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCourseHD]    Script Date: 9/16/2017 10:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourseHD](
	[CourseHDID] [varchar](36) NOT NULL,
	[SujectID] [varchar](36) NULL,
	[CourseCode] [varchar](250) NULL,
	[CourseYear] [int] NULL,
	[Semester] [int] NULL,
	[teachID] [varchar](36) NULL,
	[TimeStart] [int] NOT NULL,
	[TimeStart_txt] [nvarchar](max) NULL,
	[TimeEnd] [int] NOT NULL,
	[TimeEnd_txt] [nvarchar](max) NULL,
	[TimeLate] [int] NULL,
	[NumCheckIN] [int] NULL,
	[Entitled] [int] NULL,
	[NotEntitled] [int] NULL,
	[Contact] [int] NULL,
	[IsClose] [bit] NULL,
 CONSTRAINT [PK_dbo.tblCourseHD] PRIMARY KEY CLUSTERED 
(
	[CourseHDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMajor]    Script Date: 9/16/2017 10:43:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMajor](
	[MajorID] [varchar](36) NOT NULL,
	[MajorCode] [varchar](250) NOT NULL,
	[MajorName] [varchar](250) NULL,
	[MajorDetail] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.tblMajor] PRIMARY KEY CLUSTERED 
(
	[MajorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMinor]    Script Date: 9/16/2017 10:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMinor](
	[MinorID] [varchar](36) NOT NULL,
	[MajorID] [varchar](36) NOT NULL,
	[MinorCode] [varchar](250) NOT NULL,
	[MinorName] [varchar](250) NULL,
	[MinorDetail] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.tblMinor] PRIMARY KEY CLUSTERED 
(
	[MinorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudent]    Script Date: 9/16/2017 10:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent](
	[StudID] [varchar](36) NOT NULL,
	[StudCode] [varchar](100) NOT NULL,
	[FullName] [varchar](500) NULL,
	[MajorID] [varchar](36) NULL,
	[MinorID] [varchar](36) NULL,
	[Year] [int] NULL,
	[BirthDate] [datetime] NOT NULL,
	[Tel] [varchar](20) NULL,
	[Email] [varchar](500) NULL,
	[Remark] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.tblStudent] PRIMARY KEY CLUSTERED 
(
	[StudID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSuject]    Script Date: 9/16/2017 10:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSuject](
	[SujectID] [varchar](36) NOT NULL,
	[SujectCode] [varchar](250) NOT NULL,
	[SujectName] [varchar](250) NULL,
	[SujectDetail] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.tblSuject] PRIMARY KEY CLUSTERED 
(
	[SujectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTeacher]    Script Date: 9/16/2017 10:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTeacher](
	[teachID] [varchar](36) NOT NULL,
	[teachCode] [varchar](100) NOT NULL,
	[FullName] [varchar](500) NULL,
	[Education] [varchar](500) NULL,
	[Position] [varchar](500) NULL,
	[Expert] [varchar](500) NULL,
	[MajorID] [varchar](36) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Tel] [varchar](20) NULL,
	[Email] [varchar](500) NULL,
	[Remark] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.tblTeacher] PRIMARY KEY CLUSTERED 
(
	[teachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 9/16/2017 10:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [varchar](36) NOT NULL,
	[UserName] [varchar](250) NULL,
	[Password] [varchar](100) NULL,
	[relateID] [varchar](50) NULL,
	[relateTable] [varchar](50) NULL,
	[Remark] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uv_Course]    Script Date: 9/16/2017 10:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uv_Course](
	[CourseHDID] [varchar](36) NOT NULL,
	[CourseCode] [varchar](250) NOT NULL,
	[teachID] [varchar](36) NOT NULL,
	[teachCode] [varchar](100) NOT NULL,
	[SujectCode] [varchar](250) NOT NULL,
	[TimeStart_txt] [nvarchar](128) NOT NULL,
	[TimeStart] [int] NOT NULL,
	[TimeEnd_txt] [nvarchar](128) NOT NULL,
	[TimeEnd] [int] NOT NULL,
	[CourseYear] [int] NULL,
	[Semester] [int] NULL,
	[FullNameT] [varchar](500) NULL,
	[SujectID] [varchar](36) NULL,
	[SujectName] [varchar](250) NULL,
	[IsClose] [bit] NOT NULL,
	[TimeLate] [int] NULL,
	[NumCheckIN] [int] NULL,
	[Entitled] [int] NULL,
	[NotEntitled] [int] NULL,
	[Contact] [int] NULL,
	[CourseDTID] [varchar](36) NULL,
	[StudID] [varchar](36) NULL,
	[StudCode] [varchar](100) NULL,
	[FullNameS] [varchar](500) NULL,
	[MinorID] [varchar](36) NULL,
	[MinorCode] [varchar](250) NULL,
	[MinorName] [varchar](250) NULL,
 CONSTRAINT [PK_dbo.uv_Course] PRIMARY KEY CLUSTERED 
(
	[CourseHDID] ASC,
	[CourseCode] ASC,
	[teachID] ASC,
	[teachCode] ASC,
	[SujectCode] ASC,
	[TimeStart_txt] ASC,
	[TimeStart] ASC,
	[TimeEnd_txt] ASC,
	[TimeEnd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCheckIN]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCheckIN_dbo.tblCourseHD_CourseHDID] FOREIGN KEY([CourseHDID])
REFERENCES [dbo].[tblCourseHD] ([CourseHDID])
GO
ALTER TABLE [dbo].[tblCheckIN] CHECK CONSTRAINT [FK_dbo.tblCheckIN_dbo.tblCourseHD_CourseHDID]
GO
ALTER TABLE [dbo].[tblCheckIN]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCheckIN_dbo.tblStudent_StudID] FOREIGN KEY([StudID])
REFERENCES [dbo].[tblStudent] ([StudID])
GO
ALTER TABLE [dbo].[tblCheckIN] CHECK CONSTRAINT [FK_dbo.tblCheckIN_dbo.tblStudent_StudID]
GO
ALTER TABLE [dbo].[tblCourseDT]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCourseDT_dbo.tblCourseHD_CourseHDID] FOREIGN KEY([CourseHDID])
REFERENCES [dbo].[tblCourseHD] ([CourseHDID])
GO
ALTER TABLE [dbo].[tblCourseDT] CHECK CONSTRAINT [FK_dbo.tblCourseDT_dbo.tblCourseHD_CourseHDID]
GO
ALTER TABLE [dbo].[tblCourseDT]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCourseDT_dbo.tblStudent_StudID] FOREIGN KEY([StudID])
REFERENCES [dbo].[tblStudent] ([StudID])
GO
ALTER TABLE [dbo].[tblCourseDT] CHECK CONSTRAINT [FK_dbo.tblCourseDT_dbo.tblStudent_StudID]
GO
ALTER TABLE [dbo].[tblCourseHD]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCourseHD_dbo.tblSuject_SujectID] FOREIGN KEY([SujectID])
REFERENCES [dbo].[tblSuject] ([SujectID])
GO
ALTER TABLE [dbo].[tblCourseHD] CHECK CONSTRAINT [FK_dbo.tblCourseHD_dbo.tblSuject_SujectID]
GO
ALTER TABLE [dbo].[tblCourseHD]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCourseHD_dbo.tblTeacher_teachID] FOREIGN KEY([teachID])
REFERENCES [dbo].[tblTeacher] ([teachID])
GO
ALTER TABLE [dbo].[tblCourseHD] CHECK CONSTRAINT [FK_dbo.tblCourseHD_dbo.tblTeacher_teachID]
GO
ALTER TABLE [dbo].[tblMinor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblMinor_dbo.tblMajor_MajorID] FOREIGN KEY([MajorID])
REFERENCES [dbo].[tblMajor] ([MajorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblMinor] CHECK CONSTRAINT [FK_dbo.tblMinor_dbo.tblMajor_MajorID]
GO
ALTER TABLE [dbo].[tblStudent]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblStudent_dbo.tblMinor_MinorID] FOREIGN KEY([MinorID])
REFERENCES [dbo].[tblMinor] ([MinorID])
GO
ALTER TABLE [dbo].[tblStudent] CHECK CONSTRAINT [FK_dbo.tblStudent_dbo.tblMinor_MinorID]
GO
ALTER TABLE [dbo].[tblTeacher]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblTeacher_dbo.tblMajor_MajorID] FOREIGN KEY([MajorID])
REFERENCES [dbo].[tblMajor] ([MajorID])
GO
ALTER TABLE [dbo].[tblTeacher] CHECK CONSTRAINT [FK_dbo.tblTeacher_dbo.tblMajor_MajorID]
GO
