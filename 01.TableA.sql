USE [fsdbunit]
GO

/****** Object:  Table [dbo].[TableA]    Script Date: 12/12/2013 14:54:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TableA](
	[TableA_PK] [int] IDENTITY(1,1) NOT NULL,
	[TableA_Code] [nvarchar](20) NULL,
	[TableA_Name1] [nvarchar](50) NULL,
	[TableA_Name2] [nvarchar](50) NULL,
 CONSTRAINT [PK_TableA] PRIMARY KEY CLUSTERED 
(
	[TableA_PK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


