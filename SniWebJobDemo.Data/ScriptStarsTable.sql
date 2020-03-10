CREATE TABLE [dbo].[Stars]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(MAX) NOT NULL
)
;

INSERT [dbo].[Stars] (Name) VALUES ('North Star')
;

SELECT * FROM [dbo].[Stars]
