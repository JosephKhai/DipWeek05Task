CREATE TABLE [dbo].[Borrow]
(
	[StudentID] NVARCHAR(50) NOT NULL , 
    [ISBN] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Borrow] PRIMARY KEY ([StudentID], [ISBN] ), 
    CONSTRAINT [FK_Borrow_ToTable] FOREIGN KEY ([StudentID]) REFERENCES [Student]([StudentID]), 
    CONSTRAINT [FK_Borrow_ToTable_1] FOREIGN KEY ([ISBN]) REFERENCES [Book]([ISBN])
)
