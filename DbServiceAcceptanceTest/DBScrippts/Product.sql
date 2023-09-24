CREATE DATABASE Product

-- Connect to product database before executing the scripts below.

GRANT ALL
ON ALL TABLES
IN SCHEMA "public"
TO testuser;

CREATE TABLE Currency (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    CurrencyCode CHAR(3) NOT NULL
);

CREATE TABLE ProductBrand (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

CREATE TABLE Product (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Description TEXT,
    Price DECIMAL NOT NULL,
    CurrencyId UUID NOT NULL,
    ProductBrandId UUID NOT NULL,
    FOREIGN KEY (CurrencyId) REFERENCES Currency(Id),
    FOREIGN KEY (ProductBrandId) REFERENCES ProductBrand(Id)
);

CREATE TABLE ProductMedia (
    Id UUID PRIMARY KEY,
    MediaUrl VARCHAR(100) NOT NULL,
    IsDisplayPicture BOOLEAN NOT NULL,
    ProductId UUID NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);