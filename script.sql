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
INSERT [dbo].[tblMajor] ([MajorID], [MajorCode], [MajorName], [MajorDetail]) VALUES (N'79222006-11c3-4cbd-905c-df4e15220f8f', N'MA0003', N'หลักสูตรเตรียมสถาปัตยกรรมศาสตร์', N'หลักสูตรเตรียมสถาปัตยกรรมศาสตร์')
INSERT [dbo].[tblMajor] ([MajorID], [MajorCode], [MajorName], [MajorDetail]) VALUES (N'a392a271-59d4-450b-80e7-bad05dd25df2', N'MA0001', N'หลักสูตรเตรียมบริหารธุรกิจ', N'หลักสูตรเตรียมบริหารธุรกิจ')
INSERT [dbo].[tblMajor] ([MajorID], [MajorCode], [MajorName], [MajorDetail]) VALUES (N'fcdccd2e-4698-4f6d-8f2c-e8a304d16f7c', N'MA0002', N'หลักสูตรเตรียมวิศวกรรมศาสตร์', N'หลักสูตรเตรียมวิศวกรรมศาสตร์')
INSERT [dbo].[tblTeacher] ([teachID], [teachCode], [FullName], [Education], [Position], [Expert], [MajorID], [BirthDate], [Tel], [Email], [Remark]) VALUES (N'092d01f3-ca79-4f38-9881-7a00bef4abf3', N'T01', N'นายอดิศร กวาวสิบสาม', N'ปริญญาเอก วิศวกรรมศาสตรดุษฎีบัณฑิต วศ.ด. (วิศวกรรมเครื่องกล) มหาวิทยาลัยเชียงใหม่', N'หัวหน้าหลักสูตรเตรียมวิศวกรรมศาสตร์', N'การวัดขนาดอนุภาคนาโนด้วยเทคนิคการเคลื่อนตัวเชิงไฟฟ้า', N'fcdccd2e-4698-4f6d-8f2c-e8a304d16f7c', CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'053-266518', N'adisorn_401@hotmail.com', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'007cdb17-6430-4833-b4b6-6269e882c8c7', N'GECEL107', N'ภาษาจีนขั้นกลาง', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'0bfa4385-6a51-4cc2-a4a9-882b150f384f', N'GECWL106', N'ภาษาอังกฤษเพื่องานวิศวกรรม 2', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'0c9918e3-822c-451d-abd4-4c23b1f25d2e', N'GECSS103', N'ภูมิศาสตร์', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'48c52f45-35a8-41ee-9508-67b3940d7154', N'GECEL105', N'ภาษาญี่ปุ่นขั้นกลาง', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'598a1336-0eac-4f2b-8da3-693463d1bdf8', N'GECWL103', N'ภาษาอังกฤษโลกกว้าง 1', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'5afb37a3-bd2f-4480-9afa-574f9e370e85', N'GECEL103', N'ภาษาไทย 3', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'62c1b5f1-86d1-4ae3-90e1-185ec50e9ec8', N'GECEL101', N'ภาษาไทย 1', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'641e879f-dd36-488c-9f3b-aace9dbeeeec', N'GECSS105', N'ศาสนา ศีลธรรม จริยธรรม กับการพัฒนาชีวิต', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'79fcddad-f239-4905-b8db-7b7fcac4e661', N'GECEL104', N'ภาษาญี่ปุ่นขั้นต้น', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'7f576274-af09-4352-b684-6090d51577ad', N'GECSS104', N'พัฒนาการทางประวัติศาสตร์', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'90b1f334-bcf1-441a-b610-e4b7aa75ec13', N'GECWL108', N'หลักการออกเสียงภาษาอังกฤษ', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'918b2048-a243-4862-bdb2-0f8710938128', N'GECWL105', N'ภาษาอังกฤษเพื่องานวิศวกรรม 1 ', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'9c61534b-173b-4f57-ada4-d3ff620de1cb', N'GECWL101', N'ภาษาอังกฤษพื้นฐาน 1 ', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'9cebb6c1-6429-4d79-8a91-c1e3f78316fe', N'GECSS102', N' เศรษฐศาสตร์เบื้องต้นและเศรษฐกิจพอเพียง ', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'b264f241-e2de-4639-881a-e20a4a919074', N'GECEL102', N'ภาษาไทย 2', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'b6b590d3-c466-4d5b-80f7-6882fe02f205', N'GECWL102', N'ภาษาอังกฤษพื้นฐาน 2 ', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'c0c4e5f4-a69b-4634-922d-7b178e755b0e', N'GECSS101', N'พลเมืองดี วิถีไทย', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'e0d328c3-b908-4efe-8623-c5794c2721b3', N'GECWL107', N'หลักการเขียนภาษาอังกฤษ', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'e1f29fbb-1e77-4f46-b623-9de6c01a5ebd', N'GECEL106', N'ภาษาจีนขั้นต้น ', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'e6422423-7148-444e-9ee1-49c105a8ac64', N'GECSS106', N'อาเซียนศึกษา', NULL)
INSERT [dbo].[tblSuject] ([SujectID], [SujectCode], [SujectName], [SujectDetail]) VALUES (N'ed404b58-c39f-4b49-bc5a-e9c7e05693ce', N'GECWL104', N'ภาษาอังกฤษโลกกว้าง 2', NULL)
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'03991266-5ffc-47e1-a630-b72a55c700c5', N'79222006-11c3-4cbd-905c-df4e15220f8f', N'MN006', N'สาขางานสถาปัตยกรรมและสถาปัตยกรรมผังเมือง', N'สาขางานสถาปัตยกรรมและสถาปัตยกรรมผังเมือง')
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'1dd9c553-a2b2-4b1b-b33c-649c02bb78d1', N'79222006-11c3-4cbd-905c-df4e15220f8f', N'MN007', N'สาขางานออกแบบอุตสาหกรรม', N'สาขางานออกแบบอุตสาหกรรม')
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'4369733b-4266-44a1-bbe5-2f6c8f756995', N'fcdccd2e-4698-4f6d-8f2c-e8a304d16f7c', N'MN004', N'สาขาวิชาเครื่องกล', N'สาขาวิชาเครื่องกล')
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'9276182b-e72a-42c3-8fb1-ca4eb67b8870', N'a392a271-59d4-450b-80e7-bad05dd25df2', N'MN002', N'สาขาคอมพิวเตอร์ธุรกิจ', N'สาขาคอมพิวเตอร์ธุรกิจ')
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'cd567161-78a6-43bb-8aac-b5c93f1b35e3', N'a392a271-59d4-450b-80e7-bad05dd25df2', N'MN001', N'สาขาบัญชี', N'สาขาบัญชี')
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'd4285ebb-def3-42d9-93a8-0e8e83d31d71', N'fcdccd2e-4698-4f6d-8f2c-e8a304d16f7c', N'MN005', N'สาขาวิชาโยธา', N'สาขาวิชาโยธา')
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'de5f45b4-094b-4222-932f-88f8368ddabd', N'79222006-11c3-4cbd-905c-df4e15220f8f', N'MN007', N'สาขางานสถาปัตยกรรมและสถาปัตยกรรมภายใน', N'สาขางานสถาปัตยกรรมและสถาปัตยกรรมภายใน')
INSERT [dbo].[tblMinor] ([MinorID], [MajorID], [MinorCode], [MinorName], [MinorDetail]) VALUES (N'f408c752-c6da-4246-b41c-08d3215807c7', N'fcdccd2e-4698-4f6d-8f2c-e8a304d16f7c', N'MN003', N'สาขาวิชาไฟฟ้าและอิเล็กทรอนิกส์', N'สาขาวิชาไฟฟ้าและอิเล็กทรอนิกส์')
INSERT [dbo].[tblUser] ([UserID], [UserName], [Password], [relateID], [relateTable], [Remark]) VALUES (N'89DAC931-E5D2-428A-A35F-7973636647D7', N'admin', N'1', N'admin', N'admin', N'')
