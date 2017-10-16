CREATE TABLE [dbo].[appEvents] (
    [Id]         UNIQUEIDENTIFIER              NOT NULL,
    [user_id]    UNIQUEIDENTIFIER NULL,
    [event_date] DATETIME         NULL,
    [event_type] VARCHAR (50)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

