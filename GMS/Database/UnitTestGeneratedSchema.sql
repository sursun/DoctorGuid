
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3A1EFBEAF8351AF9]') AND parent_object_id = OBJECT_ID('Clients'))
alter table Clients  drop constraint FK3A1EFBEAF8351AF9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_CommonCode_ParentCommonCode]') AND parent_object_id = OBJECT_ID('CommonCodes'))
alter table CommonCodes  drop constraint fk_CommonCode_ParentCommonCode


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_Department_ParentDepartment]') AND parent_object_id = OBJECT_ID('Departments'))
alter table Departments  drop constraint fk_Department_ParentDepartment


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9200792C432377B7]') AND parent_object_id = OBJECT_ID('SysLogs'))
alter table SysLogs  drop constraint FK9200792C432377B7


    if exists (select * from dbo.sysobjects where id = object_id(N'Clients') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Clients

    if exists (select * from dbo.sysobjects where id = object_id(N'CommonCodes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CommonCodes

    if exists (select * from dbo.sysobjects where id = object_id(N'Departments') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Departments

    if exists (select * from dbo.sysobjects where id = object_id(N'SysLogs') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SysLogs

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    create table Clients (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Mac NVARCHAR(255) null,
       Ip NVARCHAR(255) null,
       CurIp NVARCHAR(255) null,
       LastLoginTime DATETIME null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       DepartmentFk INT null,
       primary key (Id)
    )

    create table CommonCodes (
        Id INT IDENTITY NOT NULL,
       Type INT null,
       Name NVARCHAR(255) null,
       Param NVARCHAR(255) null,
       Note NVARCHAR(255) null,
       ParentFk INT null,
       primary key (Id)
    )

    create table Departments (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Level INT null,
       Note NVARCHAR(255) null,
       ParentFk INT null,
       primary key (Id)
    )

    create table SysLogs (
        Id INT IDENTITY NOT NULL,
       LogInfo NVARCHAR(255) null,
       CreateTime DATETIME null,
       UserFk INT null,
       primary key (Id)
    )

    create table Users (
        Id INT IDENTITY NOT NULL,
       LoginName NVARCHAR(255) null,
       MemberShipId UNIQUEIDENTIFIER null,
       RealName NVARCHAR(255) null,
       NickName NVARCHAR(255) null,
       Gender INT null,
       Mobile NVARCHAR(255) null,
       Enabled INT null,
       Note NVARCHAR(255) null,
       CreateTime DATETIME null,
       primary key (Id)
    )

    alter table Clients 
        add constraint FK3A1EFBEAF8351AF9 
        foreign key (DepartmentFk) 
        references Departments

    alter table CommonCodes 
        add constraint fk_CommonCode_ParentCommonCode 
        foreign key (ParentFk) 
        references CommonCodes

    alter table Departments 
        add constraint fk_Department_ParentDepartment 
        foreign key (ParentFk) 
        references Departments

    alter table SysLogs 
        add constraint FK9200792C432377B7 
        foreign key (UserFk) 
        references Users
