USE [master]
GO
/****** Object:  Database [RegisterTasks]    Script Date: 12.06.2017 0:06:32 ******/
CREATE DATABASE [RegisterTasks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RegisterTasks', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RegisterTasks.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RegisterTasks_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\RegisterTasks_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RegisterTasks] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RegisterTasks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RegisterTasks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RegisterTasks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RegisterTasks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RegisterTasks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RegisterTasks] SET ARITHABORT OFF 
GO
ALTER DATABASE [RegisterTasks] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RegisterTasks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RegisterTasks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RegisterTasks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RegisterTasks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RegisterTasks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RegisterTasks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RegisterTasks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RegisterTasks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RegisterTasks] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RegisterTasks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RegisterTasks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RegisterTasks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RegisterTasks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RegisterTasks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RegisterTasks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RegisterTasks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RegisterTasks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RegisterTasks] SET  MULTI_USER 
GO
ALTER DATABASE [RegisterTasks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RegisterTasks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RegisterTasks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RegisterTasks] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [RegisterTasks]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12.06.2017 0:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](50) NULL,
	[Middle_Name] [varchar](50) NULL,
	[Last_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 12.06.2017 0:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[Size] [varchar](50) NULL,
	[Start_date] [date] NULL,
	[End_date] [date] NULL,
	[Employe_id] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [First_Name], [Middle_Name], [Last_Name]) VALUES (2, N'Andrew', N'Vladimirovich', N'Sever')
INSERT [dbo].[Employees] ([Id], [First_Name], [Middle_Name], [Last_Name]) VALUES (4, N'Egor', N'Yurevich', N'Holod')
INSERT [dbo].[Employees] ([Id], [First_Name], [Middle_Name], [Last_Name]) VALUES (5, N'Kristina', N'Nikolaevna', N'Prostaya')
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([Id], [Name], [Size], [Start_date], [End_date], [Employe_id], [Status]) VALUES (8, N'Task 1    ', N'334', CAST(N'2004-04-02' AS Date), CAST(N'2005-05-05' AS Date), 5, N'Not Started')
INSERT [dbo].[Tasks] ([Id], [Name], [Size], [Start_date], [End_date], [Employe_id], [Status]) VALUES (9, N'Task 2    ', N'555', CAST(N'2003-03-01' AS Date), CAST(N'2004-05-01' AS Date), 2, N'Not Started')
INSERT [dbo].[Tasks] ([Id], [Name], [Size], [Start_date], [End_date], [Employe_id], [Status]) VALUES (11, N'Task 4    ', N'222', CAST(N'2002-02-02' AS Date), CAST(N'2003-03-02' AS Date), 4, N'Delayed')
INSERT [dbo].[Tasks] ([Id], [Name], [Size], [Start_date], [End_date], [Employe_id], [Status]) VALUES (12, N'Task 5    ', N'6', CAST(N'2005-04-04' AS Date), CAST(N'2006-04-03' AS Date), 2, N'Done')
INSERT [dbo].[Tasks] ([Id], [Name], [Size], [Start_date], [End_date], [Employe_id], [Status]) VALUES (13, N'Task 6    ', N'333', CAST(N'2003-03-03' AS Date), CAST(N'2006-03-03' AS Date), 5, N'Delayed')
SET IDENTITY_INSERT [dbo].[Tasks] OFF
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Employees] FOREIGN KEY([Employe_id])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Employees]
GO
USE [master]
GO
ALTER DATABASE [RegisterTasks] SET  READ_WRITE 
GO
