CREATE TABLE [dbo].[Category] (
    [category_id]   INT            IDENTITY (101, 1) NOT NULL,
    [category_name] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([category_id] ASC)
);

