create procedure ForgotPassword
(
@EmailId varchar(50)
)
as
begin 
     update UserSignup set Password=null where EmailId=@EmailId
end 