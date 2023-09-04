CREATE TABLE [dbo].[Transaction] (
    [transaction_id]     INT            NOT NULL,
    [transaction_type]   NVARCHAR (255) NOT NULL,
    [transaction_status] NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([transaction_id] ASC)
);

