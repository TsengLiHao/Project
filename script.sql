USE [Project]
GO
/****** Object:  Table [dbo].[AdminInfo]    Script Date: 2021/9/15 下午 04:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminInfo](
	[AdminID] [uniqueidentifier] NOT NULL,
	[AdminName] [nvarchar](50) NOT NULL,
	[AdminAccount] [varchar](50) NOT NULL,
	[AdminPWD] [nvarchar](50) NOT NULL,
	[UserLevel] [int] NOT NULL,
 CONSTRAINT [PK_AdminInfo] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberInfo]    Script Date: 2021/9/15 下午 04:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberInfo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [uniqueidentifier] NOT NULL,
	[MemberName] [nvarchar](50) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[PWD] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobilePhone] [int] NOT NULL,
	[Adress] [nvarchar](50) NOT NULL,
	[UserLevel] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MemberInfo_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2021/9/15 下午 04:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[MemberName] [nvarchar](50) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[OrderedQuantity] [int] NOT NULL,
	[Payment] [nvarchar](50) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[ChangedDate] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2021/9/15 下午 04:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Body] [nvarchar](50) NULL,
	[WeightPerUnit] [decimal](18, 2) NOT NULL,
	[Discontinued] [int] NOT NULL,
	[ManufactureDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[Photo] [varchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 2021/9/15 下午 04:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[CurrentQuantity] [int] NOT NULL,
	[OrderedQuantity] [int] NOT NULL,
	[ProductStatus] [int] NOT NULL,
	[ChangedDate] [datetime] NOT NULL,
	[ExpirationQuantity] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdminInfo] ADD  CONSTRAINT [DF_AdminInfo_AdminID]  DEFAULT (newid()) FOR [AdminID]
GO
ALTER TABLE [dbo].[MemberInfo] ADD  CONSTRAINT [DF_MemberInfo_MemberID]  DEFAULT (newid()) FOR [MemberID]
GO
ALTER TABLE [dbo].[MemberInfo] ADD  CONSTRAINT [DF_MemberInfo_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF_Stock_ChangedDate]  DEFAULT (getdate()) FOR [ChangedDate]
GO
