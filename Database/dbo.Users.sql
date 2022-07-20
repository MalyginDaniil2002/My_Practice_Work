CREATE TABLE [dbo].[Users]
(
    [Id]          INT            NOT NULL PRIMARY KEY,
    [Name]        NVARCHAR (MAX) NULL,
    [Surname]     NVARCHAR (MAX) NULL,
    [Middle_Name] NVARCHAR (MAX) NULL,
    [Birth_Year]  INT            NULL,
    [Birth_Month] INT            NULL,
    [Birth_Day]   INT            NULL,
);