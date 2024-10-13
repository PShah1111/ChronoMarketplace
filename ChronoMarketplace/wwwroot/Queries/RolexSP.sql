﻿CREATE PROCEDURE Rolex
As
BEGIN
Select 
*
FROM
Products
WHERE
BrandId = 'Rolex'
END
/* The above query creates a stored procedure to retrieve all products from the "Rolex" brand. */