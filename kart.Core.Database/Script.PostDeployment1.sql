/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


Insert into Category(category_name) 
Values 
('Footwear'),
('Ladies stuff'),
('Mobile Phone');

INSERT INTO Product (product_name, product_desc, category_id, stock_quantity, discount, price, user_id)
VALUES
('Nike Shooes', 'Men''s Running Shoes', 101, 10, 0, 150, 1501),
('Ladies Handbag', 'Nice and cool looking bag', 102, 15, 10, 120,1501),
('Adidas Sliders', 'Men''s footwear', 101, 20, 15, 180,1501),
('5g Smartphone', 'Top 5g smartphone in market', 103, 25, 20, 170,1502),
('Iphone 15', 'Brand new Iphone', 103, 30, 25, 80,1502);

Insert Into Role (role_id, role_name) 
values 
(1 , 'seller'),
(2, 'customer');

insert into [User](user_id,role_id,first_name,last_name,email,user_address,user_contact)
values
(1501,1,'Seller','One','seller1@email.com','p1, Address line 1, Address line 2','123456790'),
(1502,1,'Seller','Two','seller2@email.com','p2, Address line 1, Address line 2','6875618725'),
(1503,2,'Customer','One','customer1@email.com','p3, Address line 1, Address line 2','4646515655'),
(1504,2,'Customer','Two','customer2@email.com','p4, Address line 1, Address line 2','6546485221'),
(1505,2,'Customer','Three','customer3@email.com','p5, Address line 1, Address line 2','6468462261');


DELETE TOP (5) FROM Product;