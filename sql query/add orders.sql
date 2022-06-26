create procedure AddOrders
(
@BookId int,
@id int,
@AddressId int
)
As
declare @DiscountPrice float;
declare @OriginalPrice float;
declare @BookQuantity int;
Begin TRY
      if(Exists(select * from Address where AddressId = @AddressId))
		Begin
			Begin Transaction
			select @BookQuantity = OrderQuantity From CartTable where BookId =@BookId and id =@id;
			set @DiscountPrice = (select DiscountPrice from BookTable where BookId = @BookId);
			set @OriginalPrice = (select @OriginalPrice From BookTable where BookId = @BookId);

			  If((Select BookCount From BookTable where BookId =@BookId)>=@BookQuantity)
			   Begin
							insert into Orders
								Values(GETDATE(), @BookQuantity, @DiscountPrice * @BookQuantity, @OriginalPrice * @BookQuantity, @BookId, @id,@AddressId);

								update BookTable Set BookCount = BookCount - @BookQuantity where BookId = @BookId;
								delete From CartTable where BookId = @BookId and id =@id;
					End
					else
					Begin
							select 2;
					end
				Commit Transaction
			end
		ELSE
			begin
			select 3
			end
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
END CATCH