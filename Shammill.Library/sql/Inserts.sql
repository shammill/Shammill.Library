



-- Insert from one table to another (creates master records where none exist for children)
INSERT INTO [dbo].[Species] (Name, Amount)
SELECT Name, Amount, Id
FROM [dbo].[Animals]
WHERE IsAlive = 1 AND Species IS NULL;