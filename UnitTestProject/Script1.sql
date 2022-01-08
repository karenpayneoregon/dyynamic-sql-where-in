USE [master]
GO
/****** Object:  Database [WhereConditionsSample]    Script Date: 1/7/2022 5:37:28 PM ******/
CREATE DATABASE [WhereConditionsSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WhereConditionsSample', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WhereConditionsSample.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WhereConditionsSample_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WhereConditionsSample_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WhereConditionsSample] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WhereConditionsSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WhereConditionsSample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET ARITHABORT OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WhereConditionsSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WhereConditionsSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WhereConditionsSample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WhereConditionsSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WhereConditionsSample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET RECOVERY FULL 
GO
ALTER DATABASE [WhereConditionsSample] SET  MULTI_USER 
GO
ALTER DATABASE [WhereConditionsSample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WhereConditionsSample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WhereConditionsSample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WhereConditionsSample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [WhereConditionsSample]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 1/7/2022 5:37:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 1/7/2022 5:37:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (1, N'Microsoft')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (2, N'Apple')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (3, N'IBM')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (4, N'FaceBook')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (5, N'Karen''s Coffee')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (6, N'Macy''s')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (7, N'JetBrains')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (8, N'Telerik')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (9, N'GemBox Software')
INSERT [dbo].[Company] ([id], [CompanyName]) VALUES (10, N'Red Gate')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventID], [StartDate]) VALUES (1, CAST(N'2018-01-01' AS Date))
INSERT [dbo].[Events] ([EventID], [StartDate]) VALUES (2, CAST(N'2018-01-02' AS Date))
INSERT [dbo].[Events] ([EventID], [StartDate]) VALUES (3, CAST(N'2017-01-03' AS Date))
INSERT [dbo].[Events] ([EventID], [StartDate]) VALUES (4, CAST(N'2017-01-04' AS Date))
INSERT [dbo].[Events] ([EventID], [StartDate]) VALUES (5, CAST(N'2018-01-05' AS Date))
INSERT [dbo].[Events] ([EventID], [StartDate]) VALUES (6, CAST(N'2017-01-06' AS Date))
INSERT [dbo].[Events] ([EventID], [StartDate]) VALUES (7, CAST(N'2017-01-07' AS Date))
SET IDENTITY_INSERT [dbo].[Events] OFF
USE [master]
GO
ALTER DATABASE [WhereConditionsSample] SET  READ_WRITE 
GO
