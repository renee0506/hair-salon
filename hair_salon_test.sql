USE [hair_salon_test]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2/24/2017 3:01:38 PM ******/
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
/****** Object:  Table [dbo].[stylists]    Script Date: 2/24/2017 3:01:38 PM ******/
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

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (231, N'Roy', 115)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (232, N'Jeff', 115)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (233, N'Kay', 115)
SET IDENTITY_INSERT [dbo].[clients] OFF
