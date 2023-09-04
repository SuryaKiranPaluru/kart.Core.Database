CREATE TABLE [dbo].[User] (
    [user_id]      INT            NOT NULL,
    [role_id]      INT            NOT NULL,
    [first_name]   NVARCHAR (50)  NOT NULL,
    [last_name]    NVARCHAR (50)  NULL,
    [email]        NVARCHAR (100) NOT NULL,
    [user_address] NVARCHAR (255) NOT NULL,
    [user_contact] NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC),
    FOREIGN KEY ([role_id]) REFERENCES [dbo].[Role] ([role_id])
);

