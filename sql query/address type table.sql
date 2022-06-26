create table AddressType(TypeId int not null Identity(1,1) primary key, Type varchar(50));

insert into AddressType (Type) Values ('Home')
insert into AddressType (Type) Values ('Work')
insert into AddressType (Type) Values ('Other')

Select * From AddressType