 USE SandBox

IF OBJECT_ID('tempdb..#Table1') IS NOT NULL DROP TABLE #Table1

CREATE TABLE #Table1 (ID INT IDENTITY(1,1),XMLDoc XML)

DECLARE @LOG_NAME NVARCHAR(MAX)
DECLARE @LogXML XML;
DECLARE @SQL varchar(500)
  
DECLARE LOG_CURSOR CURSOR  
LOCAL  FORWARD_ONLY  FOR  
SELECT Name FROM [dbo].[PlayerLogXML] 
OPEN LOG_CURSOR  
FETCH NEXT FROM LOG_CURSOR INTO @LOG_NAME
WHILE @@FETCH_STATUS = 0  
BEGIN  
	SET @SQL = 'INSERT INTO #TABLE1 SELECT XMLData FROM PlayerLogXML WHERE [Name] =''' + @LOG_NAME +''''
	EXEC(@SQL)
	FETCH NEXT FROM LOG_CURSOR INTO @LOG_NAME
END  
CLOSE LOG_CURSOR  
DEALLOCATE LOG_CURSOR;

WITH CTE as (
SELECT ID,
T.c.value('TransactionId[1]','bigint') AS 'TransactionId',
T.c.value('ContentName[1]','varchar(100)') AS 'ContentName',
T.c.value('When[1]','datetime') AS 'When',
T.c.value('Action[1]','varchar(30)') AS 'Action'
FROM #Table1
CROSS APPLY #Table1.XMLDoc.nodes('/PlayLogItem') T(c)
)

SELECT TransactionID, 
	   ContentName, [When], 
	   Action 
FROM CTE WHere (ContentName like '%US-T%')
--AND [WHen] > '06/15/2019' AND [WHen] < '06/17/2019'
Order by [When]


----DROP TABLE #TABLE1
