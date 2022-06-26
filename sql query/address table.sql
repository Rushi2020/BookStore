create Table Address(
AddressId int not null Identity(1,1) Primary key,
id int not null FOREIGN KEY (id) REFERENCES UserSignup(id), 
Address varchar(900),
City varchar(90), 
State varchar(90), 
TypeId int FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId)
);

Select * From Address
Select * From UserSignup
Select * From BookTable