CREATE PROCEDURE Tissot
As
BEGIN
Select 
*
FROM
Products
WHERE
BrandId = 'Tissot'
END
/* The above query creates a stored procedure to retrieve all products from the "Tissot" brand. */