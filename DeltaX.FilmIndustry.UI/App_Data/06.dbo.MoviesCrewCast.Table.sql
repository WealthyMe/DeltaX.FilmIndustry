
/****** Object:  Table [dbo].[MoviesCrewCast]    Script Date: 18-01-2018 22:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviesCrewCast](
	[CrewCastId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[CrewCastRoleId] [int] NOT NULL,
 CONSTRAINT [PK_MoviesCrewCast] PRIMARY KEY CLUSTERED 
(
	[CrewCastId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MoviesCrewCast]  WITH CHECK ADD  CONSTRAINT [FK_MoviesCrewCast_CrewCastRoles] FOREIGN KEY([CrewCastRoleId])
REFERENCES [dbo].[CrewCastRoles] ([CrewCastRoleId])
GO
ALTER TABLE [dbo].[MoviesCrewCast] CHECK CONSTRAINT [FK_MoviesCrewCast_CrewCastRoles]
GO
ALTER TABLE [dbo].[MoviesCrewCast]  WITH CHECK ADD  CONSTRAINT [FK_MoviesCrewCast_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO
ALTER TABLE [dbo].[MoviesCrewCast] CHECK CONSTRAINT [FK_MoviesCrewCast_Movies]
GO
ALTER TABLE [dbo].[MoviesCrewCast]  WITH CHECK ADD  CONSTRAINT [FK_MoviesCrewCast_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[MoviesCrewCast] CHECK CONSTRAINT [FK_MoviesCrewCast_Persons]
GO
