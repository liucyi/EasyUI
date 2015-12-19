 
create table Upload (
   Id                   int                  identity,
   ExName               nvarchar(Max)        null,
   CreateTime           nvarchar(20)         null,
   Size                 nvarchar(Max)        null,
   Url                  nvarchar(Max)        null,
   constraint PK_UPLOAD primary key (Id)
)
go
 