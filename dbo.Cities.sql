CREATE TABLE [dbo].[Cities] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [CountryID] INT            NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Cities_Countries_CountryID] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Countries] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Cities_CountryID]
    ON [dbo].[Cities]([CountryID] ASC);

