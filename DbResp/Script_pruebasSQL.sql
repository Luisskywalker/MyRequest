USE [pruebasSql]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 02/11/2021 07:51:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Edad] [int] NULL,
	[Bdate] [date] NULL,
	[Depto] [nchar](10) NULL,
	[puesto] [nchar](10) NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImgProp]    Script Date: 02/11/2021 07:51:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImgProp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](50) NULL,
	[ImageText] [nvarchar](max) NULL,
	[DateConverted] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspInsImgData]    Script Date: 02/11/2021 07:51:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspInsImgData]
@ImageName nvarchar(50),
@ImageText nvarchar(max),
@DateConverted datetime

as 
begin
INSERT INTO [dbo].[ImgProp]
           ([ImageName]
           ,[ImageText]
           ,[DateConverted])
     VALUES
        (@ImageName,@ImageText,@DateConverted )
End
GO
/****** Object:  StoredProcedure [dbo].[uspListImgProp]    Script Date: 02/11/2021 07:51:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspListImgProp]
as
begin
Select Id,ImageName,ImageText,DateConverted from ImgProp
End
GO
