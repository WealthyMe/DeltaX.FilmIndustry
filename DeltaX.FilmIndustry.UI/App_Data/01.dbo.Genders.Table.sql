
/****** Object:  Table [dbo].[Genders]    Script Date: 18-01-2018 22:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genders](
	[GenderID] [int] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Genders] ([GenderID], [Gender]) VALUES (1, N'Male')
INSERT [dbo].[Genders] ([GenderID], [Gender]) VALUES (2, N'Female')
