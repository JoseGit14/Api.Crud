CREATE TABLE [dbo].[ProductCart](
	[CartId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]
GO
