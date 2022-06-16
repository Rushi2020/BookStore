create procedure ResetPassword
(
@EmailId varchar(50),
@Password varchar(50)
)

as
begin 
     update UserSignup set Password=@Password where EmailId=@EmailId
end 

select * from UserSignup