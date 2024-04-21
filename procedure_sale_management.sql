USE sale_management;
GO
--create procedure login
CREATE PROC login @username NVARCHAR(20), @password NVARCHAR(20)
AS
BEGIN
    SELECT *
    FROM accounts
    WHERE username = @username
      AND pASsword = @password
END
GO

--create procedure load products
CREATE PROCEDURE load_products
AS
SELECT p.id       as product_id,
       p.bar_code as product_barcode,
       p.name     as product_name,
       p.note     as product_note
FROM products p
GO

-- create procedure add customer
CREATE PROCEDURE add_customer @name NVARCHAR(255),
                              @address NVARCHAR(255),
                              @phone_number VARCHAR(20),
                              @note NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO customers(name, address, phone_number, note, enable)
    VALUES (@name, @address, @phone_number, @note, 1)
END
GO

--get price list
CREATE PROC getListProductPrice @product_id INT
AS
BEGIN
    SELECT u.id, u.name, u.note, p.price
    FROM units u
             join price p on u.id = p.unit_id
    WHERE p.product_id = @product_id
END
GO

-- delete product
CREATE PROC delete_product @product_id INT
AS
BEGIN
    DELETE price WHERE product_id = @product_id;
    DELETE products WHERE id = @product_id;
    DELETE products WHERE id = @product_id;
END
GO
-- get product price
CREATE PROC getProductPrice @pId INT, @uId INT
AS
SELECT price
FROM price p
WHERE p.product_id = @pId
  AND p.unit_id = @uId
GO
--trigger calculator total price
CREATE TRIGGER trgCalculateTotalPrice
    ON carts
    AFTER INSERT, UPDATE
    AS
BEGIN
    IF UPDATE(price) OR UPDATE(quantity)
        BEGIN
            UPDATE carts
            SET total_price = inserted.price * inserted.quantity
            FROM carts
                     INNER JOIN inserted ON carts.id = inserted.id
        END
END;
GO