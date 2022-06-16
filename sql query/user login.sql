create procedure UserLogin

(
@EmailId varchar(50),
@Password varchar(50)
)

as
begin 
     select * from UserSignup where (EmailId = @EmailId and Password = @Password)
end 
