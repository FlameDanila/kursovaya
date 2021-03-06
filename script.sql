USE [Ocenki]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 16.05.2022 11:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[kuratorid] [int] NULL,
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kurators]    Script Date: 16.05.2022 11:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kurators](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[login] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[groupid] [int] NULL,
 CONSTRAINT [PK_kurators] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[students]    Script Date: 16.05.2022 11:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[groupId] [int] NULL,
	[login] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[math] [int] NULL,
	[rus] [int] NULL,
	[literature] [int] NULL,
	[fizra] [int] NULL,
 CONSTRAINT [PK_students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[groups] ON 

INSERT [dbo].[groups] ([id], [name], [kuratorid]) VALUES (1, N'Одуванчики', 1)
INSERT [dbo].[groups] ([id], [name], [kuratorid]) VALUES (2, N'Ромашки', 2)
INSERT [dbo].[groups] ([id], [name], [kuratorid]) VALUES (3, N'Потому что', 3)
INSERT [dbo].[groups] ([id], [name], [kuratorid]) VALUES (4, N'Гладиолусы', 4)
SET IDENTITY_INSERT [dbo].[groups] OFF
GO
SET IDENTITY_INSERT [dbo].[kurators] ON 

INSERT [dbo].[kurators] ([id], [name], [login], [password], [groupid]) VALUES (1, N'Марина', N'1', N'1', 1)
INSERT [dbo].[kurators] ([id], [name], [login], [password], [groupid]) VALUES (2, N'Алевтина', N'2', N'2', 2)
INSERT [dbo].[kurators] ([id], [name], [login], [password], [groupid]) VALUES (3, N'Екатерина', N'3', N'3', 3)
INSERT [dbo].[kurators] ([id], [name], [login], [password], [groupid]) VALUES (4, N'Павел', N'4', N'4', 4)
SET IDENTITY_INSERT [dbo].[kurators] OFF
GO
SET IDENTITY_INSERT [dbo].[students] ON 

INSERT [dbo].[students] ([id], [name], [groupId], [login], [password], [math], [rus], [literature], [fizra]) VALUES (1, N'Иван', 1, N'1', N'1', 5, 5, 5, 5)
INSERT [dbo].[students] ([id], [name], [groupId], [login], [password], [math], [rus], [literature], [fizra]) VALUES (2, N'Вован', 2, N'2', N'2', 3, 2, 2, 2)
INSERT [dbo].[students] ([id], [name], [groupId], [login], [password], [math], [rus], [literature], [fizra]) VALUES (4, N'Петя', 0, N'5', N'5', 3, 4, 5, 1)
SET IDENTITY_INSERT [dbo].[students] OFF
GO
ALTER TABLE [dbo].[groups]  WITH CHECK ADD  CONSTRAINT [FK_groups_kurators] FOREIGN KEY([kuratorid])
REFERENCES [dbo].[kurators] ([id])
GO
ALTER TABLE [dbo].[groups] CHECK CONSTRAINT [FK_groups_kurators]
GO
