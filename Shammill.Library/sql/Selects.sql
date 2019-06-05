-- Select with a Like
SELECT TOP 1000 [AuditDate]
      ,[Username]
      ,[IPAddress]
      ,[EntityTypeId]
      ,[EntityId]
      ,[UI]
      ,[Operation]
      ,[Changes]
      ,[EntityGuid]
      ,[EntityKey]
      ,[AuditLogId]
      ,[RelatedEntityTypeId]
      ,[RelatedEntityId]
  FROM [Prod].[dbo].[AuditLog]
  WHERE EntityTypeId = 74
  AND [Changes] LIKE '%EntityId="352" EntityIdType="System.Int32">%'
  AND [Changes] LIKE '%<DayAttended>true</DayAttended>%'


  -- Select with a NOT Like
  SELECT *
  FROM [dbo].[ClientContacts]
  Where Type = 'Company'
  AND LastName NOT LIKE '%pty%'



-- Select Distinct Example
SELECT DISTINCT TV.[TestCentreId]
      ,TS.[TestCentreLocationId]
      ,[LocationDescription]
      ,[TestSessionDescription]
	,TCL.Name
	,TCL.DisplayName
	,AD.AddressId
	,AD.SuburbOrTown
  FROM [Dev].[dbo].[TestSession] as TS
  INNER JOIN [Dev].[dbo].[TestCentreLocation] as TCL
  ON TS.TestCentreLocationId = TCL.TestCentreLocationId
    INNER JOIN [Dev].[dbo].TestVenue as TV
  ON TV.TestCentreId = TS.TestCentreId
      INNER JOIN [Dev].[dbo].Address as AD
  ON AD.AddressId = TV.AddressId
  WHERE DisplayName = 'CityName'
  ORDER BY TCL.Name

-- Example of a select using COUNT, GETUTCDATE, GroupBy and Having
SELECT t.TestApplicationId, Count(t.TestApplicationId) FROM Test t (NOLOCK) WHERE t.testTypeFlag = 7
AND t.DateOfTest >= GETUTCDATE()
GROUP BY t.TestApplicationId
HAVING Count(t.TestApplicationId) > 1



-- Selecting a column of XML, and selecting within that. This one is really useful. :)
BEGIN
DECLARE @auditLogRecord XML;

Set @auditLogRecord = (SELECT TOP 1 [Changes]
  FROM [Prod].[dbo].[AuditLog]
  WHERE EntityTypeId = 74
  And Operation = 4 --Delete Operation
  AND [Changes] LIKE '%EntityId="576" EntityIdType="System.Int32">'
  AND [Changes] LIKE '%<ScheduleDate>2017-05-16T00:00:00</ScheduleDate>%'
ORDER BY AuditDate DESC);

SELECT @auditLogRecord
SELECT @auditLogRecord.value('(/AuditLog//ActualStartTime)[1]', 'varchar(max)')
SELECT @auditLogRecord.value('(/AuditLog//ActualEndTime)[1]', 'varchar(max)')
SELECT @auditLogRecord.value('(/AugitLog/ScheduleDate)[1]', 'varchar(max)')
SELECT SUBSTRING(@auditLogRecord.value('(/ScheduleDate)[1]', 'varchar(max)'), 1, 17);
end


