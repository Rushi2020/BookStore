create procedure GetAllOrders
	@id INT
AS
BEGIN
	select 
		BookTable.BookId,BookTable.BookName,BookTable.AuthorName,BookTable.DiscountPrice,BookTable.OriginalPrice,BookTable.Image,Orders.OrdersId,Orders.Order_Date
		FROM BookTable
		inner join Orders
		on Orders.BookId=BookTable.BookId where Orders.id=@id
END