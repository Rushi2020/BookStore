create table Admin
(
AdminId int identity(1,1) primary key,
FullName varchar (200) NOT NULL,
EmailId varchar (200) NOT NULL,
Password varchar (250) NOT NULL,
MobileNumber BigInt NOT NULL,
Address varchar (max) NOT NULL
)
Insert into Admin 
values('Rushi','189489rishi@gmail.com','Rushi@123','8329778818','Kolhapur');