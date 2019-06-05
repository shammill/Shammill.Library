



-- Insert from one table to another
INSERT INTO [dbo].[MasterExtras] (Name, Amount, temp_MatterExtraId)
SELECT Name, Amount, Id
FROM [dbo].[MatterExtras]
WHERE IsMasterExtra = 1 AND MatterExtra_MasterExtra IS NULL;