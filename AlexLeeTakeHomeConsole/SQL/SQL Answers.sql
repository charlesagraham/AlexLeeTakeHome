--4. (SQL) – The table PurchaseDetailItem has records that were inconsistently inserted for two different Purchase Order numbers, 
--can you write a quick query to create a line number column per item per purchase order number?

SELECT [PurchaseDetailItemAutoId]
      ,[PurchaseOrderNumber]
      ,ROW_NUMBER() OVER (PARTITION BY [PurchaseOrderNumber] ORDER BY [PurchaseOrderNumber], [ItemNumber], [LastModifiedDateTime]) AS [LineNumber]
      ,[ItemNumber]
      ,[ItemName]
      ,[ItemDescription]
      ,[PurchasePrice]
      ,[PurchaseQuantity]
      ,[LastModifiedByUser]
      ,[LastModifiedDateTime]
FROM [PurchaseDetailItem]
GO
--5. (SQL) – The PurchaseDetailItem table also seems to have duplicate records, can you write a query to identify the duplicates inserted that have the same 
--purchase order number, item number, purchase price and quantity that are the same? Provide the query below: 

IF OBJECT_ID('tempdb..#T_Duplicates') IS NOT NULL
    DROP TABLE #T_Duplicates

SELECT [PurchaseOrderNumber], [ItemNumber], [PurchasePrice], [PurchaseQuantity]
    INTO #T_Duplicates
FROM [PurchaseDetailItem]
GROUP BY [PurchaseOrderNumber], [ItemNumber], [PurchasePrice], [PurchaseQuantity]
HAVING COUNT(*) > 1

--NOT Suire weather you wanted the duplicate records or just a summary of the duplicates by the criteria, so I gave you both    
SELECT * FROM #T_Duplicates

SELECT pdi.*
FROM #T_Duplicates AS d
JOIN [PurchaseDetailItem] AS pdi ON 
    d.[PurchaseOrderNumber] = pdi.[PurchaseOrderNumber] 
    AND d.[ItemNumber] = pdi.[ItemNumber] 
    AND d.[PurchasePrice] = pdi.[PurchasePrice]
    AND d.[PurchaseQuantity] = pdi.[PurchaseQuantity]


--6. (SQL) – Create a stored procedure that lists out all the purchase detail records with the line number field from question #4. 
GO
CREATE OR ALTER PROCEDURE sp_GetAllPurchaseDetailItemsWithLineNumbers
AS
SELECT [PurchaseDetailItemAutoId]
      ,[PurchaseOrderNumber]
      ,ROW_NUMBER() OVER (PARTITION BY [PurchaseOrderNumber] ORDER BY [PurchaseOrderNumber], [ItemNumber], [LastModifiedDateTime]) AS [LineNumber]
      ,[ItemNumber]
      ,[ItemName]
      ,[ItemDescription]
      ,[PurchasePrice]
      ,[PurchaseQuantity]
      ,[LastModifiedByUser]
      ,[LastModifiedDateTime]
FROM [PurchaseDetailItem]

GO

--7. (SQL) – Given a table Employees with columns: EmployeeID, Name, ManagerID.
--Write a recursive CTE to display the hierarchy starting from the top-level manager.
--Include EmployeeID, Name, ManagerID, ManagerName, and Level (depth in the hierarchy).

WITH CTE_EmployeeLevel AS (

    SELECT
        EmployeeID,
        Name,
        ManagerID,
        1 AS Level 
    FROM
        Employees
    WHERE
        ManagerID IS NULL 

    UNION ALL

    SELECT
        e.EmployeeID,
        e.Name,
        e.ManagerID,
        eh.Level + 1 AS Level
    FROM
        Employees AS e
    INNER JOIN
        CTE_EmployeeLevel AS eh ON e.ManagerID = eh.EmployeeID
    WHERE
        eh.Level < 100 
)
SELECT
    cte.EmployeeID,
    cte.Name,
    COALESCE(m.Name, 'N/A') AS ManagerName,
    cte.Level
FROM
    CTE_EmployeeLevel AS cte
    LEFT JOIN Employees as m on cte.ManagerID = m.EmployeeID
ORDER BY
    Level, EmployeeID;

