Use TravelExperts
select * from Products_Suppliers
select * from Suppliers
select * from Products

SELECT *
FROM Products
INNER JOIN Products_Suppliers
ON Products.ProductId=Products_Suppliers.ProductId


SELECT Products.ProductId, ProdName, Suppliers.SupplierId, SupName
FROM Products
INNER JOIN Products_Suppliers
ON Products.ProductId=Products_Suppliers.ProductId
INNER JOIN Suppliers
ON Products_Suppliers.SupplierId = Suppliers.SupplierId