USE [Dapper1]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[AddressType] [varchar](10) NOT NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[PostalCode] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[Title] [varchar](50) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] NOT NULL,
	[StateName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [ContactId], [AddressType], [StreetAddress], [City], [StateId], [PostalCode]) VALUES (1, 1, N'Home', N'123 Main Street', N'Chicago', 17, N'60290')
INSERT [dbo].[Addresses] ([Id], [ContactId], [AddressType], [StreetAddress], [City], [StateId], [PostalCode]) VALUES (2, 1, N'Work', N'1901 W Madison St', N'Chicago', 17, N'60612')
INSERT [dbo].[Addresses] ([Id], [ContactId], [AddressType], [StreetAddress], [City], [StateId], [PostalCode]) VALUES (3, 2, N'Home', N'123 Main Street', N'Los Angeles', 6, N'90001')
INSERT [dbo].[Addresses] ([Id], [ContactId], [AddressType], [StreetAddress], [City], [StateId], [PostalCode]) VALUES (4, 3, N'Home', N'123 Main Street', N'Milwaukee', 55, N'53201')
INSERT [dbo].[Addresses] ([Id], [ContactId], [AddressType], [StreetAddress], [City], [StateId], [PostalCode]) VALUES (5, 4, N'Home', N'123 Main Street', N'Oakland', 6, N'94577')
INSERT [dbo].[Addresses] ([Id], [ContactId], [AddressType], [StreetAddress], [City], [StateId], [PostalCode]) VALUES (6, 5, N'Home', N'123 Main Street', N'Boston', 25, N'02101')
INSERT [dbo].[Addresses] ([Id], [ContactId], [AddressType], [StreetAddress], [City], [StateId], [PostalCode]) VALUES (7, 6, N'Home', N'456 Main Street', N'Houston', 48, N'77001')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [Email], [Company], [Title]) VALUES (1, N'Michael', N'Jordan', N'michael@bulls.com', N'Chicago Bulls', N'MVP')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [Email], [Company], [Title]) VALUES (2, N'LaBron', N'James', N'labron@lakers.com', N'Los Angeles Lakers', N'King James')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [Email], [Company], [Title]) VALUES (3, N'Giannis', N'Antetokounmpo', N'giannis@bucks.com', N'Milwaukee Bucks', N'The Greek Freak')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [Email], [Company], [Title]) VALUES (4, N'Kevin', N'Durant', N'kevin@warriors.com', N'Golden State Warriors', N'KD')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [Email], [Company], [Title]) VALUES (5, N'Kyrie', N'Irving', N'kyrie@celtics.com', N'Boston Celtics', N'Uncle Drew')
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [Email], [Company], [Title]) VALUES (6, N'James', N'Harden', N'james@rockets.com', N'Houston Rockets', N'The Beard')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
INSERT [dbo].[States] ([Id], [StateName]) VALUES (1, N'Alabama')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (2, N'Alaska')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (4, N'Arizona')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (5, N'Arkansas')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (6, N'California')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (8, N'Colorado')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (9, N'Connecticut')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (10, N'Delaware')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (11, N'District of Columbia')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (12, N'Florida')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (13, N'Georgia')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (15, N'Hawaii')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (16, N'Idaho')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (17, N'Illinois')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (18, N'Indiana')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (19, N'Iowa')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (20, N'Kansas')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (21, N'Kentucky')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (22, N'Louisiana')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (23, N'Maine')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (24, N'Maryland')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (25, N'Massachusetts')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (26, N'Michigan')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (27, N'Minnesota')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (28, N'Mississippi')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (29, N'Missouri')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (30, N'Montana')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (31, N'Nebraska')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (32, N'Nevada')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (33, N'New Hampshire')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (34, N'New Jersey')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (35, N'New Mexico')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (36, N'New York')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (37, N'North Carolina')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (38, N'North Dakota')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (39, N'Ohio')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (40, N'Oklahoma')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (41, N'Oregon')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (42, N'Pennsylvania')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (44, N'Rhode Island')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (45, N'South Carolina')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (46, N'South Dakota')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (47, N'Tennessee')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (48, N'Texas')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (49, N'Utah')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (50, N'Vermont')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (51, N'Virginia')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (53, N'Washington')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (54, N'West Virginia')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (55, N'Wisconsin')
INSERT [dbo].[States] ([Id], [StateName]) VALUES (56, N'Wyoming')
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Contacts]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_States]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAddress]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAddress]
	@Id int
AS
BEGIN
	DELETE FROM Addresses WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteContact]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteContact]
	@Id int
AS
BEGIN
	DELETE FROM Contacts
	WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetContact]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[GetContact]
	@Id int
AS
BEGIN
	SELECT [Id]
		  ,[FirstName]
		  ,[LastName]
		  ,[Company]
		  ,[Title]
		  ,[Email]
	  FROM [dbo].[Contacts]
	WHERE Id = @Id;

	SELECT 
		Id,
		ContactId,
		AddressType,
		StreetAddress,
		City,
		StateId,
		PostalCode
	FROM [dbo].[Addresses] 
	WHERE ContactID = @Id;

END
GO
/****** Object:  StoredProcedure [dbo].[SaveAddress]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SaveAddress]
	@Id            int output,
	@ContactId     int,
	@AddressType   varchar(10),
	@StreetAddress varchar(50),
	@City          varchar(50),
	@StateId       int,
	@PostalCode    varchar(20)
AS
BEGIN
	UPDATE	Addresses
	SET		ContactId     = @ContactId,
	        AddressType   = @AddressType,
	        StreetAddress = @StreetAddress,
			City          = @City,
			StateId       = @StateId,
			PostalCode    = @PostalCode
	WHERE	Id            = @Id

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Addresses
		(ContactId, AddressType, StreetAddress, City, StateId, PostalCode)
		VALUES (@ContactId, @AddressType, @StreetAddress, @City, @StateId, @PostalCode);
		
		SET @Id = cast(scope_identity() as int)
	END;
END;
GO
/****** Object:  StoredProcedure [dbo].[SaveContact]    Script Date: 1/9/2024 2:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[SaveContact]
	@Id     	int output,
	@FirstName	varchar(50),
	@LastName	varchar(50),	
	@Company	varchar(50),
	@Title		varchar(50),
	@Email		varchar(50)
AS
BEGIN
	UPDATE	Contacts
	SET		FirstName = @FirstName,
			LastName  = @LastName,
			Company   = @Company,
			Title     = @Title,
			Email     = @Email
	WHERE	Id        = @Id

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO [dbo].[Contacts]
           ([FirstName]
           ,[LastName]
           ,[Company]
           ,[Title]
           ,[Email])
		VALUES
           (@FirstName,
           @LastName, 
           @Company,
           @Title,
           @Email);
		SET @Id = cast(scope_identity() as int)
	END;
END;
GO
USE [master]
GO
ALTER DATABASE [Dapper1] SET  READ_WRITE 
GO
