USE [LocalizacaoAmigos]
GO

/****** Object:  Table [dbo].[Friends]    Script Date: 15/09/2019 03:41:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Friends](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Latitude] [int] NULL,
	[Longitude] [int] NULL,
	[Distance] [decimal] NULL,
 CONSTRAINT [PK_dbo.Friends] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



-------------SCRIPT DE CARGA -----------------------------

INSERT INTO dbo.Friends
           (Name
		   ,Latitude
		   ,Longitude)
     VALUES
			('Marcos', 4,9)
			,('Camila', 3,4)
			,('Ale', 3,8)
			,('Marta', 8,10)
			,('Carlos', 10,22)
			,('Claiton', 12,4)
			,('Denis', 44,28)
			,('Murilo', 10,15)
			,('Samantha', 56,52)
			,('Paulo', 52,24)
			,('João', 124,248)
-------------------------------------------------------------
