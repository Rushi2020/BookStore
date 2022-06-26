create proc SP_Admin_Login
(
@EmailId varchar(225),
@Password Varchar(225)
)
As
Begin
		select * From Admin Where EmailId = @EmailId and Password = @Password;
end