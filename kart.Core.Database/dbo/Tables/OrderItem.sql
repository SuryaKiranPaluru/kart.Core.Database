CREATE TABLE [dbo].[OrderItem] (
    [order_item_id] INT IDENTITY (51, 1) NOT NULL,
    [order_id]      INT NULL,
    [product_id]    INT NULL,
    [quantity]      INT NULL,
    PRIMARY KEY CLUSTERED ([order_item_id] ASC),
    FOREIGN KEY ([order_id]) REFERENCES [dbo].[Order] ([order_id]),
    FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([product_id])
);

