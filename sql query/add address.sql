create procedure AddAddress
(
  @id int,
  @Address varchar(900),
  @City varchar(90),
  @State varchar(90),
  @TypeId int
)
 as
begin 	
		insert into Address(id,Address,City,State,TypeId) values (@id,@Address,@City,@State,@TypeId)	
end 