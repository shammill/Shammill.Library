
-- A Child Record was missing a Parent. 
-- This creates the Parent based on the Child information
-- Creates and Removes a temporary Id column to connect the records after the parent is made.
ALTER TABLE [dbo].[MasterExtras]
ADD temp_MatterExtraId int NULL;

INSERT INTO [dbo].[MasterExtras] (Name, Amount, temp_MatterExtraId)
SELECT Name, Amount, Id
FROM [dbo].[MatterExtras]
WHERE IsMasterExtra = 1 AND MatterExtra_MasterExtra IS NULL;

UPDATE [MatterExtras]
SET [MatterExtras].[MatterExtra_MasterExtra] = MasterE.Id
FROM [MatterExtras] Extra
INNER JOIN MasterExtras MasterE 
ON MasterE.temp_MatterExtraId = Extra.Id

ALTER TABLE [dbo].[MasterExtras]
DROP COLUMN temp_MatterExtraId;