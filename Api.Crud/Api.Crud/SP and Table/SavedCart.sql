CREATE TABLE [dbo].[SavedCart](
	[CartId] [int] NULL,
	[TotalAmount] [money] NULL,
	[Cash] [money] NULL,
	[ChangeCash] [money] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL
) ON [PRIMARY]
GO
