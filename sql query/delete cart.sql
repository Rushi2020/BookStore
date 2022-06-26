create procedure DeleteCart
(
 @CartId int
)
as
begin 
	if(Exists(select * from CartTable where CartId=@CartId))
	begin
		delete from CartTable where CartId=@CartId
	end
	else
	begin
		select 2
	end
end