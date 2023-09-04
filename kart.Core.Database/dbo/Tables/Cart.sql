CREATE TABLE [dbo].[Cart] (
    [session_id] INT NOT NULL,
    [product_id] INT NULL,
    [user_id]    INT NULL,
    PRIMARY KEY CLUSTERED ([session_id] ASC),
    FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([product_id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[User] ([user_id])
);

