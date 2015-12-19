/*==============================================================*/
/* Database name:  CarAppDB                                     */
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2013/9/12 16:40:32                           */
/*==============================================================*/


drop database CarAppDB
go

/*==============================================================*/
/* Database: CarAppDB                                           */
/*==============================================================*/
create database CarAppDB
go

use CarAppDB
go

/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table Customer (
   Id                   int                  identity,
   Name                 nvarchar(20)         null,
   Phone                nvarchar(11)         null,
   PassWord             nvarchar(20)         null,
   Sex                  nvarchar(4)          null,
   Province             nvarchar(16)         null,
   City                 nvarchar(16)         null,
   IDType               nvarchar(14)         null,
   IDNumber             nvarchar(20)         null,
   Address              nvarchar(Max)        null,
   PostCode             nvarchar(10)         null,
   constraint PK_CUSTOMER primary key (Id)
)
go

/*==============================================================*/
/* Table: Product                                               */
/*==============================================================*/
create table Product (
   Id                   int                  identity,
   Name                 nvarchar(30)         null,
   constraint PK_PRODUCT primary key (Id)
)
go

/*==============================================================*/
/* Table: ProductOrder                                          */
/*==============================================================*/
create table ProductOrder (
   OrderId              nvarchar(30)         not null,
   CreateTime           nvarchar(Max)        null,
   CustomerServices     nvarchar(Max)        null,
   Customer             nvarchar(Max)        null,
   Address              nvarchar(Max)        null,
   TEL                  nvarchar(Max)        null,
   ProductName          nvarchar(Max)        null,
   Quantity             nvarchar(Max)        null,
   PayoutStatus         nvarchar(Max)        null,
   Sim                  nvarchar(Max)        null,
   SimStatus            nvarchar(Max)        null,
   LogisticsId          nvarchar(Max)        null,
   ReceivingStatus      nvarchar(Max)        null,
   CollectionStatus     nvarchar(Max)        null,
   constraint PK_PRODUCTORDER primary key (OrderId)
)
go

/*==============================================================*/
/* Table: ReplyMessage                                          */
/*==============================================================*/
create table ReplyMessage (
   Id                   int                  identity,
   AcceptanceDep        nvarchar(50)         null,
   SI                   nvarchar(50)         null,
   WorkOrderId          nvarchar(20)         null,
   AcceptancePer        nvarchar(20)         null,
   ProcessingMode       nvarchar(20)         null,
   CreateTime           nvarchar(20)         null,
   ProcessingTime       nvarchar(20)         null,
   Suggestion           nvarchar(Max)        null,
   Attachment           nvarchar(Max)        null,
   Phone                nvarchar(Max)        null,
   constraint PK_REPLYMESSAGE primary key (Id)
)
go

/*==============================================================*/
/* Table: SysDepartment                                         */
/*==============================================================*/
create table SysDepartment (
   Id                   int                  identity,
   Name                 nvarchar(50)         null,
   ParentId             int                  null,
   Sort                 nvarchar(20)         null,
   State                nvarchar(20)         null,
   constraint PK_SYSDEPARTMENT primary key (Id)
)
go

/*==============================================================*/
/* Table: SysMenu                                               */
/*==============================================================*/
create table SysMenu (
   Id                   nvarchar(50)         not null,
   Name                 nvarchar(Max)        null,
   Url                  nvarchar(max)        null,
   Iconic               nvarchar(50)         null,
   Sort                 int                  null,
   Remark               nvarchar(Max)        null,
   State                nvarchar(10)         null,
   IsLeaf               nvarchar(Max)        null,
   ParentId             nvarchar(50)         null,
   constraint PK_SYSMENU primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SysMenu') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SysMenu' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'À¸Ä¿', 
   'user', @CurrentUser, 'table', 'SysMenu'
go

/*==============================================================*/
/* Table: SysMenuSysRole                                        */
/*==============================================================*/
create table SysMenuSysRole (
   Id                   int                  not null,
   SysMenuId            nvarchar(50)         null,
   SysRoleId            int                  null,
   constraint PK_SYSMENUSYSROLE primary key (Id)
)
go

/*==============================================================*/
/* Table: SysPerson                                             */
/*==============================================================*/
create table SysPerson (
   Id                   int                  identity,
   Name                 nvarchar(20)         null,
   MyName               nvarchar(20)         null,
   Password             nvarchar(max)        null,
   Sex                  nvarchar(10)         null,
   SysRoleId            int                  null,
   SysDepartmentId      int                  null,
   PhoneNumber          nvarchar(11)         null,
   City                 nvarchar(20)         null,
   Village              nvarchar(20)         null,
   State                nvarchar(10)         null,
   Type                 nvarchar(10)         null,
   constraint PK_SYSPERSON primary key (Id)
)
go

/*==============================================================*/
/* Table: SysPersonSysMenu                                      */
/*==============================================================*/
create table SysPersonSysMenu (
   Id                   int                  not null,
   SysPersonId          int                  null,
   SysMenuId            nvarchar(50)         null,
   constraint PK_SYSPERSONSYSMENU primary key (Id)
)
go

/*==============================================================*/
/* Table: SysRole                                               */
/*==============================================================*/
create table SysRole (
   Id                   int                  identity,
   Name                 nvarchar(Max)        null,
   Description          nvarchar(Max)        null,
   Type                 nvarchar(Max)        null,
   State                nvarchar(5)          null,
   constraint PK_SYSROLE primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SysRole') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SysRole' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '½ÇÉ«', 
   'user', @CurrentUser, 'table', 'SysRole'
go

/*==============================================================*/
/* Table: WorkOrder                                             */
/*==============================================================*/
create table WorkOrder (
   Id                   nvarchar(20)         not null,
   Type                 nvarchar(10)         null,
   ProductId            int                  null,
   Quantity             int                  null,
   Contact              nvarchar(10)         null,
   Phone                nvarchar(11)         null,
   Sex                  nvarchar(4)          null,
   ProblemDescription   nvarchar(Max)        null,
   ProcessingMode       nvarchar(20)         null,
   Suggestion           nvarchar(Max)        null,
   SI                   nvarchar(50)         null,
   Attachment           nvarchar(Max)        null,
   SIM                  nvarchar(30)         null,
   Terminal             nvarchar(30)         null,
   Company              nvarchar(30)         null,
   State                nvarchar(8)          null,
   CreateTime           nvarchar(20)         null,
   ProcessingTime       nvarchar(20)         null,
   constraint PK_WORKORDER primary key (Id)
)
go

alter table ReplyMessage
   add constraint FK_REPLYMES_REFERENCE_WORKORDE foreign key (WorkOrderId)
      references WorkOrder (Id)
go

alter table SysDepartment
   add constraint FK_SYSDEPAR_REFERENCE_SYSDEPAR foreign key (ParentId)
      references SysDepartment (Id)
go

alter table SysMenu
   add constraint FK_SYSMENU_REFERENCE_SYSMENU foreign key (ParentId)
      references SysMenu (Id)
go

alter table SysMenuSysRole
   add constraint FK_SYSMENUS_REFERENCE_SYSMENU foreign key (SysMenuId)
      references SysMenu (Id)
go

alter table SysMenuSysRole
   add constraint FK_SYSMENUS_REFERENCE_SYSROLE foreign key (SysRoleId)
      references SysRole (Id)
go

alter table SysPerson
   add constraint FK_SYSPERSO_REFERENCE_SYSDEPAR foreign key (SysDepartmentId)
      references SysDepartment (Id)
go

alter table SysPerson
   add constraint FK_SYSPERSO_REFERENCE_SYSROLE foreign key (SysRoleId)
      references SysRole (Id)
go

alter table SysPersonSysMenu
   add constraint FK_SYSPERSO_REFERENCE_SYSMENU foreign key (SysMenuId)
      references SysMenu (Id)
go

alter table SysPersonSysMenu
   add constraint FK_SYSPERSO_REFERENCE_SYSPERSO foreign key (SysPersonId)
      references SysPerson (Id)
go

alter table WorkOrder
   add constraint FK_WORKORDE_REFERENCE_PRODUCT foreign key (ProductId)
      references Product (Id)
go

