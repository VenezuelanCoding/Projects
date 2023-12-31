USE [AppDB]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[isAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActingRoles]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActingRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ActingMovie_Id] [int] NULL,
	[Member_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ActingRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directs]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directs](
	[MovieRefId] [int] NOT NULL,
	[MemberRefId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Directs] PRIMARY KEY CLUSTERED 
(
	[MovieRefId] ASC,
	[MemberRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DislikedBy]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DislikedBy](
	[MovieRefId] [int] NOT NULL,
	[ProfileRefId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DislikedBy] PRIMARY KEY CLUSTERED 
(
	[MovieRefId] ASC,
	[ProfileRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HasSubgenres]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HasSubgenres](
	[MovieRefId] [int] NOT NULL,
	[GenreRefId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.HasSubgenres] PRIMARY KEY CLUSTERED 
(
	[MovieRefId] ASC,
	[GenreRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikedBy]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikedBy](
	[MovieRefId] [int] NOT NULL,
	[ProfileRefId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LikedBy] PRIMARY KEY CLUSTERED 
(
	[MovieRefId] ASC,
	[ProfileRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[BirthDate] [datetime] NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Poster] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsPG] [bit] NOT NULL,
	[IsSponsored] [bit] NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[PrimaryGenre_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsOwner] [bit] NOT NULL,
	[Alias] [nvarchar](max) NULL,
	[Pin] [nvarchar](max) NULL,
	[IsChildren] [bit] NOT NULL,
	[Account_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelatedMovies]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelatedMovies](
	[MovieRefId] [int] NOT NULL,
	[RelatedRefId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RelatedMovies] PRIMARY KEY CLUSTERED 
(
	[MovieRefId] ASC,
	[RelatedRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scores]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Points] [int] NOT NULL,
	[Genre_Id] [int] NULL,
	[Profile_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Scores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuperLikedBy]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperLikedBy](
	[MovieRefId] [int] NOT NULL,
	[ProfileRefId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SuperLikedBy] PRIMARY KEY CLUSTERED 
(
	[MovieRefId] ASC,
	[ProfileRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WatchedBy]    Script Date: 11/16/2022 10:06:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WatchedBy](
	[MovieRefId] [int] NOT NULL,
	[ProfileRefId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.WatchedBy] PRIMARY KEY CLUSTERED 
(
	[MovieRefId] ASC,
	[ProfileRefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActingRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ActingRoles_dbo.Members_Member_Id] FOREIGN KEY([Member_Id])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[ActingRoles] CHECK CONSTRAINT [FK_dbo.ActingRoles_dbo.Members_Member_Id]
GO
ALTER TABLE [dbo].[ActingRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ActingRoles_dbo.Movies_ActingMovie_Id] FOREIGN KEY([ActingMovie_Id])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[ActingRoles] CHECK CONSTRAINT [FK_dbo.ActingRoles_dbo.Movies_ActingMovie_Id]
GO
ALTER TABLE [dbo].[Directs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Directs_dbo.Members_MemberRefId] FOREIGN KEY([MemberRefId])
REFERENCES [dbo].[Members] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Directs] CHECK CONSTRAINT [FK_dbo.Directs_dbo.Members_MemberRefId]
GO
ALTER TABLE [dbo].[Directs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Directs_dbo.Movies_MovieRefId] FOREIGN KEY([MovieRefId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Directs] CHECK CONSTRAINT [FK_dbo.Directs_dbo.Movies_MovieRefId]
GO
ALTER TABLE [dbo].[DislikedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DislikedBy_dbo.Movies_MovieRefId] FOREIGN KEY([MovieRefId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DislikedBy] CHECK CONSTRAINT [FK_dbo.DislikedBy_dbo.Movies_MovieRefId]
GO
ALTER TABLE [dbo].[DislikedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DislikedBy_dbo.Profiles_ProfileRefId] FOREIGN KEY([ProfileRefId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DislikedBy] CHECK CONSTRAINT [FK_dbo.DislikedBy_dbo.Profiles_ProfileRefId]
GO
ALTER TABLE [dbo].[HasSubgenres]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HasSubgenres_dbo.Genres_GenreRefId] FOREIGN KEY([GenreRefId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HasSubgenres] CHECK CONSTRAINT [FK_dbo.HasSubgenres_dbo.Genres_GenreRefId]
GO
ALTER TABLE [dbo].[HasSubgenres]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HasSubgenres_dbo.Movies_MovieRefId] FOREIGN KEY([MovieRefId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HasSubgenres] CHECK CONSTRAINT [FK_dbo.HasSubgenres_dbo.Movies_MovieRefId]
GO
ALTER TABLE [dbo].[LikedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LikedBy_dbo.Movies_MovieRefId] FOREIGN KEY([MovieRefId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LikedBy] CHECK CONSTRAINT [FK_dbo.LikedBy_dbo.Movies_MovieRefId]
GO
ALTER TABLE [dbo].[LikedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LikedBy_dbo.Profiles_ProfileRefId] FOREIGN KEY([ProfileRefId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LikedBy] CHECK CONSTRAINT [FK_dbo.LikedBy_dbo.Profiles_ProfileRefId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Movies_dbo.Genres_PrimaryGenre_Id] FOREIGN KEY([PrimaryGenre_Id])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_dbo.Movies_dbo.Genres_PrimaryGenre_Id]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Profiles_dbo.Accounts_Account_Id] FOREIGN KEY([Account_Id])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_dbo.Profiles_dbo.Accounts_Account_Id]
GO
ALTER TABLE [dbo].[RelatedMovies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RelatedMovies_dbo.Movies_MovieRefId] FOREIGN KEY([MovieRefId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[RelatedMovies] CHECK CONSTRAINT [FK_dbo.RelatedMovies_dbo.Movies_MovieRefId]
GO
ALTER TABLE [dbo].[RelatedMovies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RelatedMovies_dbo.Movies_RelatedRefId] FOREIGN KEY([RelatedRefId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[RelatedMovies] CHECK CONSTRAINT [FK_dbo.RelatedMovies_dbo.Movies_RelatedRefId]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Scores_dbo.Genres_Genre_Id] FOREIGN KEY([Genre_Id])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_dbo.Scores_dbo.Genres_Genre_Id]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Scores_dbo.Profiles_Profile_Id] FOREIGN KEY([Profile_Id])
REFERENCES [dbo].[Profiles] ([Id])
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_dbo.Scores_dbo.Profiles_Profile_Id]
GO
ALTER TABLE [dbo].[SuperLikedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SuperLikedBy_dbo.Movies_MovieRefId] FOREIGN KEY([MovieRefId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SuperLikedBy] CHECK CONSTRAINT [FK_dbo.SuperLikedBy_dbo.Movies_MovieRefId]
GO
ALTER TABLE [dbo].[SuperLikedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SuperLikedBy_dbo.Profiles_ProfileRefId] FOREIGN KEY([ProfileRefId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SuperLikedBy] CHECK CONSTRAINT [FK_dbo.SuperLikedBy_dbo.Profiles_ProfileRefId]
GO
ALTER TABLE [dbo].[WatchedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WatchedBy_dbo.Movies_MovieRefId] FOREIGN KEY([MovieRefId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WatchedBy] CHECK CONSTRAINT [FK_dbo.WatchedBy_dbo.Movies_MovieRefId]
GO
ALTER TABLE [dbo].[WatchedBy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WatchedBy_dbo.Profiles_ProfileRefId] FOREIGN KEY([ProfileRefId])
REFERENCES [dbo].[Profiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WatchedBy] CHECK CONSTRAINT [FK_dbo.WatchedBy_dbo.Profiles_ProfileRefId]
GO
