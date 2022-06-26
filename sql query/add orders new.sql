alter procedure AddOrders
(
@id int,
@AddressId int,
@BookId int
)
As
declare @DiscountPrice float;
declare @BookQuantity int;
declare @OriginalPrice float;

     begin 
	    if( exists (select * from Address where AddressId=@AddressId) )
	    
	    begin
		 select @BookQuantity = OrderQuantity from CartTable where BookId=@BookId and id=@id;
		 set @DiscountPrice = (select DiscountPrice from BookTable where BookId=@BookId);
		 set @OriginalPrice = (select OriginalPrice from BookTable where BookId=@BookId);

		  if ((select BookCount from BookTable where BookId=@BookId) >=@BookQuantity)
		    
		  begin
		    insert into Orders values(GetDate(), @BookQuantity,@DiscountPrice*@BookQuantity,@OriginalPrice*@BookQuantity,@id,@AddressId,@BookId)
			update BookTable set BookCount = BookCount - @BookQuantity where BookId=@BookId 
			delete from CartTable where BookId=@BookId and id=@id
			end
		else
		  begin
		     select 2 ;
		  end
	end	


  end       

  exec AddOrders @id=1,@AddressId=1,@BookId=4