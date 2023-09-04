CREATE TABLE [dbo].[Product] (
    [product_id]     INT             IDENTITY (501, 1) NOT NULL,
    [product_name]   NVARCHAR (255)  NOT NULL,
    [product_desc]   NVARCHAR (255)  NULL,
    [category_id]    INT             NOT NULL,
    [stock_quantity] INT             NOT NULL,
    [discount]       INT             NOT NULL,
    [price]          DECIMAL (10, 2) NULL,
    [user_id]        INT             NULL,
    PRIMARY KEY CLUSTERED ([product_id] ASC),
    FOREIGN KEY ([category_id]) REFERENCES [dbo].[Category] ([category_id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
);

