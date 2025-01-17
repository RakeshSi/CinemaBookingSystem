USE [CinemaBookingDB]
GO
/****** Object:  Table [dbo].[tblBookingSeat]    Script Date: 01/09/2020 2:20:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBookingSeat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeatNumber] [int] NULL,
	[BookingStatus] [bit] NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_tblBookingSeat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 01/09/2020 2:20:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SeatNumber] [int] NULL,
	[SecretKey] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblErrorLog]    Script Date: 01/09/2020 2:20:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblErrorLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Message] [nvarchar](max) NULL,
	[Method] [nvarchar](50) NULL,
	[Controller] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblErrorLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblBookingSeat] ON 

INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (1, 1, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (2, 2, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (3, 3, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (4, 4, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (5, 5, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (6, 6, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (7, 7, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (8, 8, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (9, 9, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (10, 10, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (11, 11, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (12, 12, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (13, 13, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (14, 14, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (15, 15, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (16, 16, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (17, 17, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (18, 18, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (19, 19, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (20, 20, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (21, 21, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (22, 22, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (23, 23, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (24, 24, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (25, 25, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (26, 26, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (27, 27, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (28, 28, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (29, 29, 0, NULL)
INSERT [dbo].[tblBookingSeat] ([Id], [SeatNumber], [BookingStatus], [CustomerId]) VALUES (30, 30, 0, NULL)
SET IDENTITY_INSERT [dbo].[tblBookingSeat] OFF
/****** Object:  StoredProcedure [dbo].[SP_BookSheet]    Script Date: 01/09/2020 2:20:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Create By	:	Rakesh Singh
-- Create date	:	08-01-2020
-- Description	:	To Create Customer and book sheet
-- =============================================

/* 
SP_BookSheet @CustomerName='Shub',@Email='shub@cisinlabs.com',@SeatNumbers='13,14,16'

*/

CREATE PROCEDURE [dbo].[SP_BookSheet]
@CustomerName VARCHAR(50)='',
@Email NVARCHAR(50)='', 
@SeatNumbers NVARCHAR(50)=''

AS

Begin  
	BEGIN TRAN
		BEGIN TRY		 
			  DECLARE @Temp TABLE (sno INT IDENTITY (1,1),SeatNumber INT)
	  
			  INSERT INTO @Temp(SeatNumber)
			  SELECT value AS SeatNumber  FROM STRING_SPLIT(@SeatNumbers,',')

			  DECLARE @MAXVAL INT=0, @MINVAL INT =0, @SeatNum int =0, @custId bigint=0	 
			  SELECT @MAXVAL=max(sno) from @Temp

			  WHILE(@MINVAL<=@MAXVAL)	  
			  BEGIN
					SELECT @SeatNum= SeatNumber FROM @Temp   WHERE  sno=@MINVAL
					IF((SELECT BookingStatus FROM tblBookingSeat WHERE SeatNumber=(@SeatNum))=0)
					BEGIN
						Declare @SecretKey Nvarchar(10)=''
						SELECT @SecretKey=CAST(RAND() * 1000000 AS INT)  
						INSERT INTO tblCustomer(CustomerName,Email,SeatNumber,SecretKey) VALUES (@CustomerName,@Email,@SeatNum,@SecretKey)
						Set @custId=(select @@IDENTITY)
						UPDATE tblBookingSeat set BookingStatus=1, CustomerId=@custId WHERE SeatNumber=@SeatNum
					END
					SET @MINVAL=@MINVAL+1;
			  END	 
			  
			  SELECT * FROM tblCustomer WHERE CustomerName=@CustomerName and Email=@Email AND SeatNumber in (select SeatNumber from @Temp)

			  COMMIT TRAN

		END TRY
		BEGIN CATCH	
		  
		  SELECT ERROR_MESSAGE() ErrorMessage, ERROR_NUMBER() ErrorNumber
		  ROLLBACK TRAN

		END CATCH

End 
GO
