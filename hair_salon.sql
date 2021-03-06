USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2/24/2017 3:00:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 2/24/2017 3:00:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[age] [int] NULL,
	[bio] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (2, N'Joe', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3, N'Owen', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (4, N'Jennifer', 1)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (5, N'Sandy', 1)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name], [age], [bio]) VALUES (1, N'Roy', 25, N'5 years in fashion industry')
INSERT [dbo].[stylists] ([id], [name], [age], [bio]) VALUES (2, N'Fred', 15, N'graduated from Academic of Styling')
SET IDENTITY_INSERT [dbo].[stylists] OFF
