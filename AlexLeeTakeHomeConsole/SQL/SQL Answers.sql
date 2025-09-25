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
