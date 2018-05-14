UPDATE [TestSession]
SET [TestSession].TestCentreLocationFeeId = TF.TestCentreLocationFeeId
FROM [TestSession] TS
INNER JOIN TestCentreLocationFee TF 
ON TF.TestCentreLocationId = TS.TestCentreLocationId

UPDATE TEST
SET TestApplicationId=NULL,ReservationExpiryDate=NULL,TestStatusId=1
WHERE TestApplicationId=4323793;


 /****** Reset all passwords to inferno ******/ 
update aspnet_Membership set [Password] = 's0dKKxU7YDBqqpsKDawaKJVdYAQ=', [PasswordSalt] = '5GOTOBcmMlz4/EY6Oja+5g==',
IsLockedOut = 0,
FailedPasswordAttemptWindowStart = '1754-01-01 00:00:00.000',
FailedPasswordAnswerAttemptWindowStart = '1754-01-01 00:00:00.000'
WHERE [Password] != 's0dKKxU7YDBqqpsKDawaKJVdYAQ='