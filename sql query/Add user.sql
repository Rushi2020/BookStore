create procedure AddUser

(
@FullName varchar(200),
@EmailId varchar(50),
@Password varchar(50),
@MobileNumber varchar(50)
)

as
begin try
     insert into UserSignup values ( @FullName, @EmailId, @Password, @MobileNumber)	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch