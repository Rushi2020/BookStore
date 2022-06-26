create procedure UpdateAddress
( 
  @AddressId int,
  @Address varchar(900),
  @City varchar(90),
  @State varchar(90),
  @TypeId int
)
as
begin 
		update Address set Address=@Address,City=@City,State=@State,TypeId=@TypeId where AddressId=@AddressId	
end 