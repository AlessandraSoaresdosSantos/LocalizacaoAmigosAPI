﻿USE [LocalizacaoAmigos]
GO
 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalculoHistoricoLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateLog] [Datetime] NULL,
	[Latitude] [int] NULL,
	[Longitude] [int] NULL,
	[FriendLatitude] [int] NULL,
	[FriendLongitude] [int] NULL,
	[Result] [decimal] NULL,
 CONSTRAINT [PK_dbo.CalculoHistoricoLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)  

GO
 