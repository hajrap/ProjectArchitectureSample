--1. States table data
If Exists(Select top 1 1 from [dbo].[States] where Id = 1)
	Update [dbo].[States] Set Code='VIC' where Id=1
ELSE
	INSERT INTO [dbo].[States] ([Id], [Code]) VALUES (1, N'VIC')

If Exists(Select top 1 1 from [dbo].[States] where Id = 2)
	Update [dbo].[States] Set Code='NSW' where Id=2
ELSE
	INSERT INTO [dbo].[States] ([Id], [Code]) VALUES (3, N'NSW')

If Exists(Select top 1 1 from [dbo].[States] where Id = 3)
	Update [dbo].[States] Set Code='VIC' where Id=3
ELSE
	INSERT INTO [dbo].[States] ([Id], [Code]) VALUES (3, N'VIC')