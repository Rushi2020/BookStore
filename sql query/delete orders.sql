create procedure DeleteOrders
(
 @OrdersId int
)
as
begin 
	
		delete from Orders where OrdersId=@OrdersId
end