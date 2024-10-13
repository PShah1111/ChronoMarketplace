SELECT 
   BrandName, 
    COUNT(ProductID) product_count
FROM 
    Products
    INNER JOIN Brands  
        ON BrandId = BrandId
GROUP BY 
    BrandName;
/* The Above SQL Statement counts and returns the number of products for each brand. */