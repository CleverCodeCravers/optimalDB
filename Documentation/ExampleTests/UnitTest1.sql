CREATE PROCEDURE TEST_ThereShouldBeNoEngineers
    AS
BEGIN
	/* There should be no engineers!
	   If there are we should fire them :)
	   (If this procedure returns any rows, then there is a problem.)
	*/
	SELECT * 
	  FROM HumanResources.Employee
	 WHERE JobTitle LIKE 'Engineering%'
END	


SELECT *
  FROM INFORMATION_SCHEMA.ROUTINES
 WHERE ROUTINE_NAME LIKE 'TEST_%'

SELECT * FROM sys.databases