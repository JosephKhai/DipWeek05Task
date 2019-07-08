CREATE TABLE [dbo].[Book]
(
	[ISBN] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [YearPublish] DATE NOT NULL, 
    [AuthorID] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Book_ToTable] FOREIGN KEY ([AuthorID]) REFERENCES [Author]([AuthorID])
)
