create procedure UpdateCart
(
 @CartId int,
 @OrderQuantity int
)
as
begin
update CartTable set OrderQuantity=@OrderQuantity where CartId=@CartId;
end