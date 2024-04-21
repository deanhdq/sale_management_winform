/*CREATE DATABASE sale_management;
GO
*/
USE sale_management;
GO

CREATE TABLE accounts
(
    id       INT IDENTITY PRIMARY KEY,
    username NVARCHAR(20)  NOT NULL UNIQUE,
    password NVARCHAR(20)  NOT NULL,
    name     NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE units
(
    id   INT IDENTITY PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE,
    note NVARCHAR(MAX)
)
GO

CREATE TABLE products
(
    id       INT IDENTITY PRIMARY KEY,
    bar_code VARCHAR(20) UNIQUE NOT NULL,
    name     NVARCHAR(MAX)      NOT NULL,
    note     NVARCHAR(MAX)
);
GO

CREATE TABLE price
(
    id         INT IDENTITY PRIMARY KEY,
    product_id INT FOREIGN KEY REFERENCES products (id),
    unit_id    INT FOREIGN KEY REFERENCES units (id),
    price      INT,
    UNIQUE (product_id, unit_id)
)
GO

CREATE TABLE customers
(
    id           INT IDENTITY PRIMARY KEY,
    name         NVARCHAR(255) NOT NULL,
    address      NVARCHAR(255),
    phone_number VARCHAR(20),
    note         NVARCHAR(MAX),
    enable       TINYINT,
    UNIQUE (name, phone_number)
);
GO

CREATE TABLE carts
(
    id             INT IDENTITY PRIMARY KEY,
    transaction_no VARCHAR(50),
    product_id     INT,
    product_name   NVARCHAR(MAX),
    unit_name           NVARCHAR(50),
    price          INT,
    quantity       INT,
    total_price    INT
)
GO

create table bill
(
    id             int identity primary key,
    transaction_no VARCHAR(50) UNIQUE,
    total_price    INT,
    date_buy       DATETIME
)
GO

create table bill_info
(
    id             int identity primary key,
    transaction_no VARCHAR(50) UNIQUE,
    product_id     INT,
    unit_name      VARCHAR(50),
    price          INT,
    quantity       INT,
    total_price    INT
)
GO