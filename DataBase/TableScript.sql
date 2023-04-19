USE [Labourdetails]
GO
/****** Object:  Table [dbo].[importdata]    Script Date: 04/18/2023 21:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[importdata](
	[Contractname] [varchar](50) NULL,
	[CommonlabourCategory] [varchar](50) NULL,
	[DisplayName] [varchar](50) NULL,
	[Shortname] [varchar](50) NULL,
	[EEO] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
