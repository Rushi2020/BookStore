create procedure DeleteAddress
(
 @AddressId int
)
as
begin 
	delete from Address where AddressId=@AddressId
end 