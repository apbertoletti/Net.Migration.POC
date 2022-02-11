USE master
go

/****************************************************************************************************
SANDBOX DATABASE
*****************************************************************************************************/

CREATE DATABASE LegacyDB_Sandbox
GO

USE LegacyDB_Sandbox
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 1/21/2022 3:09:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Province] [char](2) NULL,
	[Note] [text] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 1', 'Address 1', 'City 1', 'FL', 'Note 1')
INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 2', 'Address 2', 'City 2', 'FL', 'Note 2')
INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 3', 'Address 3', 'City 3', 'FL', 'Note 3')
INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 4', 'Address 4', 'City 4', 'FL', 'Note 4')
GO



/****** Object:  Table [dbo].[Product]    Script Date: 1/21/2022 3:10:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Category] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------
INSERT INTO [dbo].[Product] ([Name] ,[Category]) VALUES ('Product 1','AB')
INSERT INTO [dbo].[Product] ([Name] ,[Category]) VALUES ('Product 2','TR')
INSERT INTO [dbo].[Product] ([Name] ,[Category]) VALUES ('Product 3','AB')
GO

/****************************************************************************************************
PRODUCTION DATABASE
*****************************************************************************************************/

CREATE DATABASE LegacyDB
GO

USE LegacyDB
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 1/21/2022 3:09:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Province] [char](2) NULL,
	[Note] [text] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 1', 'Address 1', 'City 1', 'FL', 'Note 1')
INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 2', 'Address 2', 'City 2', 'FL', 'Note 2')
INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 3', 'Address 3', 'City 3', 'FL', 'Note 3')
INSERT INTO [dbo].[Customer] ([Name],[Address],[City],[Province],[Note]) VALUES ('Customer 4', 'Address 4', 'City 4', 'FL', 'Note 4')
GO



/****** Object:  Table [dbo].[Product]    Script Date: 1/21/2022 3:10:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Category] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--------------------------------------------
INSERT INTO [dbo].[Product] ([Name] ,[Category]) VALUES ('Product 1','AB')
INSERT INTO [dbo].[Product] ([Name] ,[Category]) VALUES ('Product 2','TR')
INSERT INTO [dbo].[Product] ([Name] ,[Category]) VALUES ('Product 3','AB')
GO
