create table Feedback
(FeedbackId int identity (1,1) primary key,
id int foreign key (id) references UserSignup(id),
BookId int foreign key (BookId) references BookTable(BookId), 
Comments varchar(900) not null,
OverallRating int null)
