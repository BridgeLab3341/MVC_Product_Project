Create Database ProductList_Machine


CREATE TABLE ProductStore
(
    ProductId INT IDENTITY(1,1) PRIMARY KEY, 
    Code VARCHAR(50) UNIQUE NOT NULL,         
    Name VARCHAR(250) NOT NULL,            
    Description VARCHAR(4000),              
    ExpiryDate DATE CHECK (ExpiryDate >= GETDATE()), 
    Category VARCHAR(50) ,
    Image VARCHAR(MAX),                    
    Status VARCHAR(10) DEFAULT 'Active',      
    CreationDate DATETIME DEFAULT GETDATE()  
);


select * from ProductStore

INSERT INTO ProductStore(Code,Name,Description,ExpiryDate,Category,Image,Status,CreationDate) 
Values('232','Somu','erwr','2024-12-20','A','fefvev','Active','')

CREATE OR ALTER PROCEDURE Sp_InsertProduct
    @Code VARCHAR(50),
    @Name VARCHAR(250),
    @Description VARCHAR(4000),
    @ExpiryDate DATE,
    @Category VARCHAR(50),
    @Image VARCHAR(MAX),
    @Status VARCHAR(10)
AS
BEGIN
    BEGIN TRY
        INSERT INTO ProductStore (Code, Name, Description, ExpiryDate, Category, Image, Status)
        VALUES (@Code, @Name, @Description, @ExpiryDate, @Category, @Image, @Status);
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;

CREATE or ALTER PROCEDURE Sp_GetAllProducts
AS
BEGIN
BEGIN TRY
SELECT * FROM ProductStore;
END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
END;

CREATE OR ALTER PROCEDURE Sp_DeleteProduct
@ProductId Int
AS
BEGIN
BEGIN TRY
DELETE FROM ProductStore where ProductId=@ProductId;
END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() as ErrorMessage;
END CATCH;
END;


Declare @Code VARCHAR(50)= '29';
Declare @Name VARCHAR(250) = 'Anil';
Declare @Description VARCHAR(4000) = 'Subject';
Declare @ExpiryDate DATE = '2024-12-20';
Declare @Category VARCHAR(50) = 'B';
Declare @Image VARCHAR(MAX) = 'hfgd.jpg';
Declare @Status VARCHAR(10) = 'Active';

EXEC Sp_InsertProduct @Code,@Name,@Description,@ExpiryDate,@Category,@Image,@Status;

EXEC Sp_InsertProduct '289','Shekar','Subject','2024-12-20','B','dfgfdg','Active';

Select * from ProductStore;

EXEC Sp_DeleteProduct 21;
