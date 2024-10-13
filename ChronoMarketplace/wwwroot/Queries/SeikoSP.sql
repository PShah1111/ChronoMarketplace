CREATE PROCEDURE Seiko
As
BEGIN
Select 
*
FROM
Products
WHERE
BrandId = 'Seiko'
END
/* The above query creates a stored procedure to retrieve all products from the "Seiko" brand. */