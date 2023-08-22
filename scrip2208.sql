USE [master]
GO
/****** Object:  Database [Doctris]    Script Date: 22/08/2023 11:58:32 am ******/
CREATE DATABASE [Doctris]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Doctris', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Doctris.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Doctris_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Doctris_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Doctris] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Doctris].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Doctris] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Doctris] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Doctris] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Doctris] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Doctris] SET ARITHABORT OFF 
GO
ALTER DATABASE [Doctris] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Doctris] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Doctris] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Doctris] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Doctris] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Doctris] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Doctris] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Doctris] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Doctris] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Doctris] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Doctris] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Doctris] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Doctris] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Doctris] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Doctris] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Doctris] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Doctris] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Doctris] SET RECOVERY FULL 
GO
ALTER DATABASE [Doctris] SET  MULTI_USER 
GO
ALTER DATABASE [Doctris] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Doctris] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Doctris] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Doctris] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Doctris] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Doctris] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Doctris', N'ON'
GO
ALTER DATABASE [Doctris] SET QUERY_STORE = OFF
GO
USE [Doctris]
GO
/****** Object:  Table [dbo].[appointment]    Script Date: 22/08/2023 11:58:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appointment](
	[appointment_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[age] [int] NULL,
	[gender] [nvarchar](10) NULL,
	[department_id] [int] NULL,
	[date] [date] NULL,
	[doctor] [int] NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[appointment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dayofweek]    Script Date: 22/08/2023 11:58:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dayofweek](
	[event_id] [int] IDENTITY(1,1) NOT NULL,
	[setting_id] [int] NULL,
	[start_time] [time](7) NULL,
	[end_time] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[event_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[department]    Script Date: 22/08/2023 11:58:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[department_id] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 22/08/2023 11:58:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[setting](
	[setting_id] [int] NOT NULL,
	[setting_type] [nvarchar](30) NOT NULL,
	[setting_name] [nvarchar](30) NOT NULL,
	[setting_description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[setting_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 22/08/2023 11:58:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [int] NOT NULL,
	[full_name] [nvarchar](50) NOT NULL,
	[email] [char](50) NULL,
	[mobile] [char](20) NULL,
	[user_name] [nvarchar](50) NULL,
	[password] [varchar](30) NULL,
	[avatar] [varchar](255) NULL,
	[gender] [bit] NULL,
	[experience] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_role]    Script Date: 22/08/2023 11:58:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_role](
	[role_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[appointment] ON 

INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (1, N'Howard Tanner', N'howard@contact.com', 25, N'Male', 1, CAST(N'2023-08-15' AS Date), 2, 1)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (2, N'Hiepcheckedit', N'wendy@contact.com', 22, NULL, 2, CAST(N'2023-08-15' AS Date), 2, 1)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (3, N'GGG', N'adsda@gmail.com', 3, NULL, 1, CAST(N'2023-08-22' AS Date), 2, 1)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (4, N'Wendy Filson', N'wendy@contact.com', 12, NULL, 1, CAST(N'2023-08-22' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (5, N'Check 2', N'Check2@gmail.com', 12, NULL, 1, CAST(N'2023-08-22' AS Date), 2, 1)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (6, N'Ronald Curtis', N'ronald@contact.com', 23, N'Male', 1, CAST(N'2023-08-25' AS Date), 2, 1)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (9, N'hh', N'hh@dff', 12, N'Male', 4, CAST(N'2023-08-19' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (10, N'nn', N'nn@mm', 22, N'Male', 3, CAST(N'2023-08-26' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (11, N'khoa', N'khoa@gmail.com', 44, N'Male', 3, CAST(N'2023-08-22' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (12, N'quan', N'quan@gmail.com', 22, N'Male', 3, CAST(N'2023-08-22' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (13, N'HiepAHIH', N'ahihi@gmail.com', 44, N'Male', 3, CAST(N'2023-08-22' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (14, N'HiepCheck228', N'228@gmail.com', 34, N'Male', 3, CAST(N'2023-08-22' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (15, N'Khoa12', N'ronald@contact.com', 12, N'Male', 1, CAST(N'2023-08-22' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (16, N'quan12', N'adsda@gmail.com', 12, N'Male', 1, CAST(N'2023-08-22' AS Date), 1, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (17, N'Check4', N'Check4@gmail.com', 12, N'Male', 1, CAST(N'2023-08-22' AS Date), 2, 0)
INSERT [dbo].[appointment] ([appointment_id], [name], [email], [age], [gender], [department_id], [date], [doctor], [is_active]) VALUES (19, N'Wendy Filson', N'adsda@gmail.com', 12, N'Male', 1, CAST(N'2023-08-22' AS Date), 2, 0)
SET IDENTITY_INSERT [dbo].[appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[dayofweek] ON 

INSERT [dbo].[dayofweek] ([event_id], [setting_id], [start_time], [end_time]) VALUES (1, 4, CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[dayofweek] ([event_id], [setting_id], [start_time], [end_time]) VALUES (2, 5, CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[dayofweek] ([event_id], [setting_id], [start_time], [end_time]) VALUES (3, 6, CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[dayofweek] ([event_id], [setting_id], [start_time], [end_time]) VALUES (4, 7, CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[dayofweek] ([event_id], [setting_id], [start_time], [end_time]) VALUES (5, 8, CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[dayofweek] ([event_id], [setting_id], [start_time], [end_time]) VALUES (6, 9, CAST(N'09:00:00' AS Time), CAST(N'15:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[dayofweek] OFF
GO
INSERT [dbo].[department] ([department_id], [name]) VALUES (1, N'Eye Care')
INSERT [dbo].[department] ([department_id], [name]) VALUES (2, N'Gynecologist')
INSERT [dbo].[department] ([department_id], [name]) VALUES (3, N'Dentist')
INSERT [dbo].[department] ([department_id], [name]) VALUES (4, N'Gastrologist')
GO
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (1, N'role', N'admin', N'Co quyen chinh sua all')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (2, N'role', N'doctor', N'Crud Appointment')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (3, N'role', N'employee', N'add appointment')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (4, N'dayofweek', N'Monday', N'Lich Lam viec hang tuan ')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (5, N'dayofweek', N'Tuesday', N'Lich Lam viec hang tuan ')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (6, N'dayofweek', N'Thursday', N'Lich Lam viec hang tuan ')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (7, N'dayofweek', N'Friday', N'Lich Lam viec hang tuan ')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (8, N'dayofweek', N'Saturday', N'Lich Lam viec hang tuan ')
INSERT [dbo].[setting] ([setting_id], [setting_type], [setting_name], [setting_description]) VALUES (9, N'dayofweek', N'Sunday', N'Lich Lam viec hang tuan ')
GO
INSERT [dbo].[user] ([user_id], [full_name], [email], [mobile], [user_name], [password], [avatar], [gender], [experience]) VALUES (1, N'admin', N'admin@gmail.com                                   ', N'0587061111          ', N'admin', N'12', N'01.jpg', 1, N'Good')
INSERT [dbo].[user] ([user_id], [full_name], [email], [mobile], [user_name], [password], [avatar], [gender], [experience]) VALUES (2, N'doctor', N'doctor@gmail.com                                  ', N'0587061112          ', N'doctor', N'12', N'02.jpg', 1, N'Good')
INSERT [dbo].[user] ([user_id], [full_name], [email], [mobile], [user_name], [password], [avatar], [gender], [experience]) VALUES (3, N'employee', N'employee@gmail.com                                ', N'0587061113          ', N'employee', N'12', N'03.jpg', 1, N'Good')
GO
INSERT [dbo].[user_role] ([role_id], [user_id], [is_active]) VALUES (1, 1, 1)
INSERT [dbo].[user_role] ([role_id], [user_id], [is_active]) VALUES (2, 2, 1)
INSERT [dbo].[user_role] ([role_id], [user_id], [is_active]) VALUES (3, 3, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__user__7C9273C46C1E4263]    Script Date: 22/08/2023 11:58:33 am ******/
ALTER TABLE [dbo].[user] ADD UNIQUE NONCLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__user__A32E2E1C24712A3F]    Script Date: 22/08/2023 11:58:33 am ******/
ALTER TABLE [dbo].[user] ADD UNIQUE NONCLUSTERED 
(
	[mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__user__AB6E61641BEC5A87]    Script Date: 22/08/2023 11:58:33 am ******/
ALTER TABLE [dbo].[user] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[appointment]  WITH CHECK ADD FOREIGN KEY([department_id])
REFERENCES [dbo].[department] ([department_id])
GO
ALTER TABLE [dbo].[appointment]  WITH CHECK ADD FOREIGN KEY([doctor])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[dayofweek]  WITH CHECK ADD FOREIGN KEY([setting_id])
REFERENCES [dbo].[setting] ([setting_id])
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[setting] ([setting_id])
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
GO
USE [master]
GO
ALTER DATABASE [Doctris] SET  READ_WRITE 
GO
