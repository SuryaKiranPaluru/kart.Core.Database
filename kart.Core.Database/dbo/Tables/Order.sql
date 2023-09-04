CREATE TABLE [dbo].[Order] (
    [order_id]        INT             IDENTITY (150, 1) NOT NULL,
    [user_id]         INT             NOT NULL,
    [order_date]      DATE            NOT NULL,
    [transaction_id]  INT             NOT NULL,
    [total_amount]    DECIMAL (10, 2) NULL,
    [shipment_status] NVARCHAR (20)   NOT NULL,
    PRIMARY KEY CLUSTERED ([order_id] ASC),
    FOREIGN KEY ([transaction_id]) REFERENCES [dbo].[Transaction] ([transaction_id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
);

