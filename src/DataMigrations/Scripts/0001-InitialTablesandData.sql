USE [CleanApiDb]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 4/20/2023 12:54:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[Address] [nvarchar](60) NOT NULL,
	[Country] [nvarchar](max) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/20/2023 12:54:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Age] [int] NOT NULL,
	[Position] [nvarchar](20) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([CompanyId], [Name], [Address], [Country]) VALUES (1, N'IT_Solutions Ltd', N'583 Wall Dr. Gwynn Oak, MD 21207', N'USA')
GO
INSERT [dbo].[Companies] ([CompanyId], [Name], [Address], [Country]) VALUES (2, N'Admin_Solutions Ltd', N'312 Forest Avenue, BF 923', N'USA')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([EmployeeId], [Name], [Age], [Position], [CompanyId]) VALUES (1, N'Sam Raiden', 26, N'Software developer', 1)
GO
INSERT [dbo].[Employees] ([EmployeeId], [Name], [Age], [Position], [CompanyId]) VALUES (2, N'Jana McLeaf', 30, N'Software developer', 2)
GO
INSERT [dbo].[Employees] ([EmployeeId], [Name], [Age], [Position], [CompanyId]) VALUES (3, N'Kane Miller', 35, N'Administrator', 2)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([CompanyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Companies_CompanyId]
GO
