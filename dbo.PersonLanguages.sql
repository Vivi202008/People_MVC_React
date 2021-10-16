CREATE TABLE [dbo].[PersonLanguages] (
    [PersonId]   INT NULL,
    [LanguageId] INT NULL,
    [ID]         INT NOT NULL,
    CONSTRAINT [PK_PersonLanguages] PRIMARY KEY CLUSTERED ([ID] ),
    CONSTRAINT [FK_PersonLanguages_Languages_LanguageId] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Languages] ([LanguageId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonLanguages_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([PersonId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PersonLanguages_LanguageId]
    ON [dbo].[PersonLanguages]([LanguageId] ASC);

