USE [AppDB]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[ActingRoles]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[Directs]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[DislikedBy]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[Genres]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[HasSubgenres]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[LikedBy]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[Members]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[Movies]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[Profiles]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[RelatedMovies]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[Scores]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[SuperLikedBy]    Script Date: 11/16/2022 10:06:53 AM ******/
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
/****** Object:  Table [dbo].[WatchedBy]    Script Date: 11/16/2022 10:06:53 AM ******/
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
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Email], [UserName], [Password], [isAdmin]) VALUES (121, N'admin@admin.com', N'adaAdminTest', N'adaAdminTest', 1)
INSERT [dbo].[Accounts] ([Id], [Email], [UserName], [Password], [isAdmin]) VALUES (122, N'rafaelCadenas@gmail.com', N'rafaelCadenas', N'rafaelCadenas', 0)
INSERT [dbo].[Accounts] ([Id], [Email], [UserName], [Password], [isAdmin]) VALUES (123, N'tomasCaetano@gmail.com', N'tomasCaetano', N'tomasCaetano', 0)
INSERT [dbo].[Accounts] ([Id], [Email], [UserName], [Password], [isAdmin]) VALUES (124, N'joaquinBonifacino@gmail.com', N'joaquinBonifacino', N'joaquinBonifacino', 0)
INSERT [dbo].[Accounts] ([Id], [Email], [UserName], [Password], [isAdmin]) VALUES (125, N'nataliaSencion@gmail.com', N'nataliaSencion', N'nataliaSencion', 0)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[ActingRoles] ON 

INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (540, N'Batman', 1449, 958)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (541, N'The Joker', 1449, 959)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (542, N'Harvey Dent', 1449, 960)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (543, N'Lucius Fox', 1449, 961)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (544, N'Judy Hopps', 1441, 964)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (545, N'Nick Wilde', 1441, 965)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (546, N'The Killer', 1445, 969)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (547, N'Drew', 1445, 970)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (548, N'Anna', 1450, 966)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (549, N'Elsa', 1450, 967)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (550, N'Olaf', 1450, 968)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (551, N'Ralph', 1444, 971)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (552, N'Vanellope', 1444, 972)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (553, N'Pumpkin', 1452, 975)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (554, N'Honey Bunny', 1452, 976)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (555, N'Vincent Vega', 1452, 977)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (556, N'Jules Winnfield', 1452, 978)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (557, N'Forrest Gump', 1453, 980)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (558, N'Mrs. Gump', 1453, 981)
INSERT [dbo].[ActingRoles] ([Id], [Name], [ActingMovie_Id], [Member_Id]) VALUES (559, N'Young Forrest', 1453, 982)
SET IDENTITY_INSERT [dbo].[ActingRoles] OFF
GO
INSERT [dbo].[Directs] ([MovieRefId], [MemberRefId]) VALUES (1447, 956)
INSERT [dbo].[Directs] ([MovieRefId], [MemberRefId]) VALUES (1449, 957)
INSERT [dbo].[Directs] ([MovieRefId], [MemberRefId]) VALUES (1441, 962)
INSERT [dbo].[Directs] ([MovieRefId], [MemberRefId]) VALUES (1441, 963)
INSERT [dbo].[Directs] ([MovieRefId], [MemberRefId]) VALUES (1452, 974)
INSERT [dbo].[Directs] ([MovieRefId], [MemberRefId]) VALUES (1453, 979)
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (961, N'Comedy', N'Comedy is a genre of fiction that consists of discourses or works intended to be humorous or amusing by inducing laughter')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (962, N'Animation', N'Animated film is a collection of illustrations that are photographed frame-by-frame and then played in a quick successions')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (963, N'Adventure', N'The adventure genre consists of books where the protagonist goes on an epic journey, either personally or geographically')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (964, N'Family', N'Family film is a genre that is contains appropriate content for younger viewers.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (965, N'Action', N'Movies in the action genre are fast-paced and include a lot of action like fight scenes, chase scenes, and slow-motion shots')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (966, N'Fantasy', N'By definition, fantasy is a genre that typically features the use of magic or other supernatural phenomena in the plot, setting, or theme')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (967, N'Drama', N'In film and television, drama is a category or genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (968, N'Crime', N'is a film genre inspired by and analogous to the crime fiction literary genre')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (969, N'Romance', N'A romance novel or romantic novel generally refers to a type of genre fiction novel which places its primary focus on the relationship and romantic love')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1440, 961)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1441, 961)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1443, 961)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1444, 961)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1450, 961)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1451, 961)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1459, 961)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1440, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1441, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1442, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1443, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1444, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1446, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1450, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1451, 963)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1442, 964)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1446, 966)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1455, 966)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1456, 966)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1458, 966)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1459, 966)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1448, 967)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1449, 967)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1452, 967)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1454, 967)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1457, 967)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1458, 967)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1449, 968)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1453, 969)
INSERT [dbo].[HasSubgenres] ([MovieRefId], [GenreRefId]) VALUES (1457, 969)
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (956, 1, N'Francis Ford Coppola', CAST(N'1939-04-07T00:00:00.000' AS DateTime), N'./Images/francisFordCoppola.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (957, 1, N'Cristopher Nolan', CAST(N'1970-07-30T00:00:00.000' AS DateTime), N'./Images/cristopherNolan.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (958, 0, N'Christian Bale', CAST(N'1973-01-30T00:00:00.000' AS DateTime), N'./Images/christianBale.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (959, 2, N'Heath Ledger', CAST(N'1979-04-04T00:00:00.000' AS DateTime), N'./Images/heathLedger.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (960, 0, N'Aaron Eckhart', CAST(N'1968-03-12T00:00:00.000' AS DateTime), N'./Images/aaronEckhart.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (961, 2, N'Morgan Freeman', CAST(N'1937-06-01T00:00:00.000' AS DateTime), N'./Images/morganFreeman.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (962, 1, N'Byron Howard', CAST(N'1968-12-26T00:00:00.000' AS DateTime), N'./Images/byronHoward.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (963, 1, N'Rich Moore', CAST(N'1963-05-10T00:00:00.000' AS DateTime), N'./Images/richMoore.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (964, 0, N'Ginnifer Goodwin', CAST(N'1978-05-22T00:00:00.000' AS DateTime), N'./Images/ginniferGoodwin.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (965, 0, N'Jason Bateman', CAST(N'1969-01-14T00:00:00.000' AS DateTime), N'./Images/jasonBateman.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (966, 0, N'Kristen Anne Bell', CAST(N'1980-07-18T00:00:00.000' AS DateTime), N'./Images/kristenAnneBell.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (967, 0, N'Idina Menzel', CAST(N'1971-05-30T00:00:00.000' AS DateTime), N'./Images/idinaMenzel.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (968, 0, N'Josh Gad', CAST(N'1981-02-23T00:00:00.000' AS DateTime), N'./Images/joshGad.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (969, 0, N'Dave Sheridan', CAST(N'1969-03-10T00:00:00.000' AS DateTime), N'./Images/daveSheridan.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (970, 0, N'Carmen Electra', CAST(N'1972-04-20T00:00:00.000' AS DateTime), N'./Images/carmenElectra.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (971, 0, N'John C. Reilly', CAST(N'1965-05-24T00:00:00.000' AS DateTime), N'./Images/johnCReilly.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (972, 0, N'Sarah Silverman', CAST(N'1970-12-01T00:00:00.000' AS DateTime), N'./Images/sarahSilverman.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (974, 1, N'Quentin Tarantino', CAST(N'1963-04-27T09:00:17.000' AS DateTime), N'./Images/quentinTarantino.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (975, 0, N'Tim Roth', CAST(N'1961-05-14T09:01:18.000' AS DateTime), N'./Images/timRoth.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (976, 0, N'Amanda Plummer', CAST(N'1957-05-23T09:02:52.000' AS DateTime), N'./Images/amandaPlummer.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (977, 0, N'John Joseph Travolta', CAST(N'1954-02-18T09:04:18.000' AS DateTime), N'./Images/jhonTravolta.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (978, 0, N'Samuel L. Jackson', CAST(N'1948-12-21T09:06:00.000' AS DateTime), N'./Images/samuelLJackson.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (979, 1, N'Robert Zemeckis', CAST(N'1952-05-14T09:16:55.000' AS DateTime), N'./Images/robertZemeckis.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (980, 0, N'Tom Hanks', CAST(N'1956-07-09T09:17:59.000' AS DateTime), N'./Images/tomHanks.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (981, 0, N'Sally Field', CAST(N'1946-11-06T09:27:50.000' AS DateTime), N'./Images/sallyField.jpg')
INSERT [dbo].[Members] ([Id], [Type], [Name], [BirthDate], [ProfilePicture]) VALUES (982, 0, N'Michael Conner Humphreys', CAST(N'1985-11-16T09:29:48.000' AS DateTime), N'./Images/michaelConnerHumphreys.PNG')
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1440, N'Tangled', N'./Images/tangled.jpg', N'The magically long-haired Rapunzel has spent her entire life in a tower, but now that a runaway thief has stumbled upon her, she is about to discover the world for the first time, and who she really is.', 1, 0, CAST(N'2011-01-06T00:00:00.000' AS DateTime), 962)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1441, N'Zootopia', N'./Images/Zootopia.jpg', N'In a city of anthropomorphic animals, a rookie bunny cop and a cynical con artist fox must work together to uncover a conspiracy.', 1, 1, CAST(N'2016-03-04T00:00:00.000' AS DateTime), 962)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1442, N'Spirited Away', N'./Images/SpiritedAway.jpg', N'During her family''s move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.', 1, 0, CAST(N'2001-07-20T00:00:00.000' AS DateTime), 962)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1443, N'Frozen', N'./Images/Frozen.jpg', N'When the newly crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister Anna teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition.', 1, 0, CAST(N'2013-11-27T00:00:00.000' AS DateTime), 962)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1444, N'Wreck-It Ralph', N'./Images/wreckItRalph.jpg', N'A video game villain wants to be a hero and sets out to fulfill his dream, but his quest brings havoc to the whole arcade where he lives.', 1, 0, CAST(N'2012-12-28T00:00:00.000' AS DateTime), 962)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1445, N'Scary Movie', N'./Images/ScaryMovie.jpg', N'A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.', 0, 0, CAST(N'2000-07-07T00:00:00.000' AS DateTime), 961)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1446, N'Star Wars: Episode V', N'./Images/starWarsV.jpg', N'After the Rebels are brutally overpowered by the Empire on the ice planet Hoth, Luke Skywalker begins Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.', 1, 0, CAST(N'1978-01-01T00:00:00.000' AS DateTime), 965)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1447, N'The Shawshank Redemption', N'./Images/theShawshankRedemption.jpg', N'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 0, 0, CAST(N'1995-08-11T00:00:00.000' AS DateTime), 967)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1448, N'The Godfather', N'./Images/theGodfather.jpg', N'The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son', 0, 0, CAST(N'1972-08-10T00:00:00.000' AS DateTime), 968)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1449, N'The Dark Knight', N'./Images/theDarkKnight.jpg', N'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice', 0, 1, CAST(N'2008-07-18T00:00:00.000' AS DateTime), 965)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1450, N'Frozen 2', N'./Images/frozen2.jpg', N'Anna, Elsa, Kristoff, Olaf and Sven leave Arendelle to travel to an ancient, autumn-bound forest of an enchanted land. They set out to find the origin of Elsa''s powers in order to save their kingdom.', 1, 0, CAST(N'2019-12-05T08:50:10.000' AS DateTime), 962)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1451, N'Wreck-It Ralph 2', N'./Images/wreckItRalph2.jpg', N'Six years after the events of \"Wreck-It Ralph\", Ralph and Vanellope, now friends, discover a wi-fi router in their arcade, leading them into a new adventure.', 1, 0, CAST(N'2018-11-02T08:52:40.000' AS DateTime), 962)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1452, N'Pulp Fiction', N'./Images/pulpFiction.jpg', N'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', 0, 0, CAST(N'1994-07-01T08:56:19.000' AS DateTime), 968)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1453, N'Forrest Gump', N'./Images/forrestGump.jpg', N'The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.', 0, 0, CAST(N'1994-10-20T09:15:33.000' AS DateTime), 967)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1454, N'The Silence of the Lambs', N'./Images/theSilenceOfTheLambs.jpg', N'A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.', 0, 0, CAST(N'1991-10-02T09:34:06.000' AS DateTime), 968)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1455, N'The Matrix', N'./Images/theMatrix.jpg', N'When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.', 0, 0, CAST(N'1999-10-02T09:34:06.000' AS DateTime), 965)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1456, N'The Matrix Reloaded', N'./Images/theMatrixReloaded.jpg', N'Freedom fighters Neo, Trinity and Morpheus continue to lead the revolt against the Machine Army, unleashing their arsenal of extraordinary skills and weaponry against the systematic forces of repression and exploitation.', 0, 0, CAST(N'2003-10-02T09:34:06.000' AS DateTime), 965)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1457, N'Life Is Beautiful', N'./Images/lifeIsBeautiful.jpg', N'When an open-minded Jewish waiter and his son become victims of the Holocaust, he uses a perfect mixture of will, humor, and imagination to protect his son from the dangers around their camp.', 0, 0, CAST(N'1997-11-16T09:41:55.000' AS DateTime), 961)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1458, N'Interstellar', N'./Images/Interestellar.PNG', N'A team of explorers travel through a wormhole in space in an attempt to ensure humanity''s survival.', 0, 0, CAST(N'2014-11-16T09:41:55.000' AS DateTime), 963)
INSERT [dbo].[Movies] ([Id], [Name], [Poster], [Description], [IsPG], [IsSponsored], [ReleaseDate], [PrimaryGenre_Id]) VALUES (1459, N'Back to the Future', N'./Images/backToTheFuture.jpg', N'Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.', 0, 0, CAST(N'1985-11-16T09:45:22.000' AS DateTime), 963)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Profiles] ON 

INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (121, 1, N'admin', N'11111', 0, 121)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (122, 0, N'adminJoaquin', N'11111', 0, 121)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (123, 0, N'adminRafael', N'11111', 0, 121)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (124, 0, N'adminTomas', N'11111', 0, 121)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (125, 1, N'rafaOriginal', N'11111', 0, 122)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (126, 1, N'tomasOriginal', N'11111', 0, 123)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (127, 0, N'rafaDos', N'11111', 0, 122)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (128, 0, N'rafaTres', N'11111', 0, 122)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (129, 0, N'rafaCuatro', N'11111', 0, 122)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (130, 0, N'tomasDos', N'11111', 0, 123)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (131, 0, N'tomasTres', N'11111', 0, 123)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (132, 0, N'tomasCuatro', N'11111', 0, 123)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (133, 1, N'joacoOriginal', N'11111', 0, 124)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (134, 0, N'joacoDos', N'11111', 0, 124)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (135, 0, N'joacoTres', N'11111', 0, 124)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (136, 0, N'joacoCuatro', N'11111', 0, 124)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (137, 1, N'natiOriginal', N'11111', 0, 125)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (138, 0, N'natiDos', N'11111', 0, 125)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (139, 0, N'natiTres', N'11111', 0, 125)
INSERT [dbo].[Profiles] ([Id], [IsOwner], [Alias], [Pin], [IsChildren], [Account_Id]) VALUES (140, 0, N'natiCuatro', N'11111', 0, 125)
SET IDENTITY_INSERT [dbo].[Profiles] OFF
GO
INSERT [dbo].[RelatedMovies] ([MovieRefId], [RelatedRefId]) VALUES (1450, 1443)
INSERT [dbo].[RelatedMovies] ([MovieRefId], [RelatedRefId]) VALUES (1451, 1444)
INSERT [dbo].[RelatedMovies] ([MovieRefId], [RelatedRefId]) VALUES (1443, 1450)
INSERT [dbo].[RelatedMovies] ([MovieRefId], [RelatedRefId]) VALUES (1444, 1451)
INSERT [dbo].[RelatedMovies] ([MovieRefId], [RelatedRefId]) VALUES (1456, 1455)
INSERT [dbo].[RelatedMovies] ([MovieRefId], [RelatedRefId]) VALUES (1455, 1456)
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
