DROP TABLE Products
DROP TABLE Prices	
DROP TABLE Categories
DROP TABLE Desctiptions
DROP TABLE Manufacturers
DROP TABLE __EFMigrationsHistory



INSERT INTO Manufacturers VALUES ('Apple')
INSERT INTO Categories VALUES ('PHONE')
INSERT INTO Descriptions VALUES ('A1', 'A2', 'A3')
INSERT INTO Prices VALUES (100.00, 50.00)
INSERT INTO Products VALUES ('ARTICLE 1','Title 1',1 , 1, 1, 1)


SELECT * FROM Products AS p
JOIN Manufacturers AS m ON m.Id = p.ManufacturerId
JOIN Categories AS c ON c.Id = p.CategoryId
JOIN Desctiptions AS d ON d.Id = p.DescriptionId
JOIN Prices AS pr ON pr.Id = p.PriceListId