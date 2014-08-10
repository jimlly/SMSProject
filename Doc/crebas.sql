/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2014/8/9 14:40:35                            */
/*==============================================================*/


if exists (select 1
          from sysobjects
          where  id = object_id('Addr_FN_Split')
          and type in ('IF', 'FN', 'TF'))
   drop function Addr_FN_Split
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactGroup_CreateSingleCGroup')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactGroup_CreateSingleCGroup
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactGroup_DeleteCGroups')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactGroup_DeleteCGroups
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactGroup_SetMemberCount')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactGroup_SetMemberCount
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactGroup_UpdateCGroupInfo')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactGroup_UpdateCGroupInfo
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactorGroupManager_GetCGroupsListPage')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactorGroupManager_GetCGroupsListPage
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactorGroupManager_GetContactorsList')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactorGroupManager_GetContactorsList
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactorGroupManager_GetUnGroupedContactors')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactorGroupManager_GetUnGroupedContactors
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactorGroupManager_GetUserContactorsCount')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactorGroupManager_GetUserContactorsCount
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_ContactorGroupManager_GetUserGroupContactors')
          and type in ('P','PC'))
   drop procedure UP_Addr_ContactorGroupManager_GetUserGroupContactors
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_AddContactor')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_AddContactor
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_AddMultiContactorToMultiGroup')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_AddMultiContactorToMultiGroup
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_AddMutilField')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_AddMutilField
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_AddSingleToCGroups')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_AddSingleToCGroups
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_DelFromAllContactors')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_DelFromAllContactors
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_DelFromSingleCGroup')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_DelFromSingleCGroup
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_GetSingleFullInfo')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_GetSingleFullInfo
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_SetMutilField')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_SetMutilField
go

if exists (select 1
          from sysobjects
          where  id = object_id('UP_Addr_Contactor_SetName')
          and type in ('P','PC'))
   drop procedure UP_Addr_Contactor_SetName
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_VW_AllContactors_FullInfo')
            and   type = 'V')
   drop view Addr_VW_AllContactors_FullInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_VW_Contactors_InContactGroup')
            and   type = 'V')
   drop view Addr_VW_Contactors_InContactGroup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_TB_ContactField')
            and   type = 'U')
   drop table Addr_TB_ContactField
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_TB_ContactGroup')
            and   type = 'U')
   drop table Addr_TB_ContactGroup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_TB_ContactGroupMembers')
            and   type = 'U')
   drop table Addr_TB_ContactGroupMembers
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_TB_Contactor')
            and   type = 'U')
   drop table Addr_TB_Contactor
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_TB_ContactorDetail')
            and   type = 'U')
   drop table Addr_TB_ContactorDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Addr_TB_ImportGroupList')
            and   type = 'U')
   drop table Addr_TB_ImportGroupList
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SMS_IB_SM_Account')
            and   type = 'U')
   drop table SMS_IB_SM_Account
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SMS_TB_MsgType_Config')
            and   type = 'U')
   drop table SMS_TB_MsgType_Config
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SMS_TB_SM_Company')
            and   type = 'U')
   drop table SMS_TB_SM_Company
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SMS_TB_SM_User')
            and   type = 'U')
   drop table SMS_TB_SM_User
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SMS_TB_Send_Bill')
            and   type = 'U')
   drop table SMS_TB_Send_Bill
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SMS_TB_Send_Detail_Bill')
            and   type = 'U')
   drop table SMS_TB_Send_Detail_Bill
go

/*==============================================================*/
/* Table: Addr_TB_ContactField                                  */
/*==============================================================*/
create table Addr_TB_ContactField (
   SysID                int                  identity(1,1),
   ContactorID          bigint               not null,
   UserID               int                  not null,
   CompID               int                  not null,
   Field                varchar(200)         null,
   FieldType            int                  null,
   constraint PK_ADDR_TB_CONTACTFIELD primary key (SysID)
)
go

/*==============================================================*/
/* Table: Addr_TB_ContactGroup                                  */
/*==============================================================*/
create table Addr_TB_ContactGroup (
   ContactGroupID       int                  identity(1,1),
   GroupName            nvarchar(50)         not null,
   UserID               int                  not null,
   CompID               int                  not null,
   MemberCount          int                  not null default 0,
   Remark               nvarchar(200)        null,
   Shared               tinyint              null,
   DeleteMark           tinyint              null,
   LastModifyTime       datetime             null,
   ModifyUserID         int                  null,
   CreateTime           datetime             null default getdate(),
   constraint PK_ADDR_TB_CONTACTGROUP primary key (ContactGroupID)
)
go

/*==============================================================*/
/* Table: Addr_TB_ContactGroupMembers                           */
/*==============================================================*/
create table Addr_TB_ContactGroupMembers (
   MemberID             bigint               identity(1,1),
   UserID               int                  not null,
   ContactGroupID       int                  not null,
   ContactorID          bigint               not null,
   DeleteMark           tinyint              not null default 0,
   constraint PK_ADDR_TB_CONTACTGROUPMEMBERS primary key (MemberID)
)
go

/*==============================================================*/
/* Table: Addr_TB_Contactor                                     */
/*==============================================================*/
create table Addr_TB_Contactor (
   ContactorID          bigint               identity(1,1),
   Name                 nvarchar(20)         not null,
   UserID               int                  not null,
   CompID               int                  not null,
   JobPhone             varchar(32)          null,
   JobFax               varchar(32)          null,
   Mobile               varchar(12)          null,
   HomePhone            varchar(32)          null,
   DefaultWayID         int                  null default 0,
   Spell                nvarchar(20)         null,
   Shared               tinyint              null,
   DeleteMark           tinyint              null,
   LastModifyTime       datetime             null,
   ModifyUserID         int                  null,
   CreateTime           datetime             null default getdate(),
   constraint PK_ADDR_TB_CONTACTOR primary key (ContactorID)
)
go

/*==============================================================*/
/* Table: Addr_TB_ContactorDetail                               */
/*==============================================================*/
create table Addr_TB_ContactorDetail (
   ContactorID          bigint               not null,
   Sex                  tinyint              null,
   Birthday             varchar(32)          null,
   Address              nvarchar(50)         null,
   Company              nvarchar(50)         null,
   Dept                 nvarchar(20)         null,
   Business             nvarchar(20)         null,
   Email                nvarchar(50)         null,
   Url                  nvarchar(100)        null,
   ZipCode              nvarchar(10)         null,
   Remark               nvarchar(max)        null,
   LastModifyTime       datetime             null,
   ModifyUserID         int                  null,
   CreateTime           datetime             null default getdate(),
   constraint PK_ADDR_TB_CONTACTORDETAIL primary key (ContactorID)
)
go

/*==============================================================*/
/* Table: Addr_TB_ImportGroupList                               */
/*==============================================================*/
create table Addr_TB_ImportGroupList (
   SysID                int                  identity(1,1),
   DocGUID              uniqueidentifier     null,
   AddrType             tinyint              null,
   GroupID              int                  not null default 0,
   UserID               int                  not null,
   ImportedCount        int                  null,
   Status               tinyint              not null default 0,
   DeleteMark           tinyint              not null default 0,
   CreateTime           datetime             not null default getdate(),
   constraint PK_ADDR_TB_IMPORTGROUPLIST primary key (SysID)
)
go

/*==============================================================*/
/* Table: SMS_IB_SM_Account                                     */
/*==============================================================*/
create table SMS_IB_SM_Account (
   AccountID            int                  identity(1,1),
   UserID               int                  not null,
   Amount               bigint               null,
   GiveAmount           bigint               null,
   CreateTime           datetime             not null default getdate(),
   CreateUserID         int                  not null,
   constraint PK_SMS_IB_SM_ACCOUNT primary key (AccountID)
)
go

/*==============================================================*/
/* Table: SMS_TB_MsgType_Config                                 */
/*==============================================================*/
create table SMS_TB_MsgType_Config (
   ID                   int                  null
)
go

/*==============================================================*/
/* Table: SMS_TB_SM_Company                                     */
/*==============================================================*/
create table SMS_TB_SM_Company (
   CompID               int                  identity(1,1),
   CompanyName          nvarchar(100)        null,
   Status               tinyint              null,
   ManagerUserID        int                  null,
   CreateTime           datetime             null,
   LastModifyedTime     datetime             null,
   CreateUserID         int                  null,
   constraint PK_SMS_TB_SM_COMPANY primary key (CompID)
)
go

/*==============================================================*/
/* Table: SMS_TB_SM_User                                        */
/*==============================================================*/
create table SMS_TB_SM_User (
   UserID               int                  identity(1,1),
   CompID               int                  null,
   UserAccount          varchar(50)          not null,
   Pwd                  varchar(50)          not null,
   UserName             varchar(50)          null,
   DepID                int                  null,
   DutyID               int                  null,
   IsAdmin              int                  null default 0,
   Remark               varchar(200)         null,
   Email                varchar(100)         not null,
   State                int                  not null default 1,
   CreateTime           datetime             null,
   LastModifyedTime     datetime             null,
   CreateUserID         int                  null,
   constraint PK_SMS_TB_SM_USER primary key (UserID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0.非管理员 1.管理员',
   'user', @CurrentUser, 'table', 'SMS_TB_SM_User', 'column', 'IsAdmin'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0.禁用 1.启用',
   'user', @CurrentUser, 'table', 'SMS_TB_SM_User', 'column', 'State'
go

/*==============================================================*/
/* Table: SMS_TB_Send_Bill                                      */
/*==============================================================*/
create table SMS_TB_Send_Bill (
   TaskName             nvarchar(100)        null,
   MsgID                varchar(20)          not null,
   UserID               int                  not null,
   Sender               nvarchar(30)         null,
   Priority             tinyint              null,
   InputType            tinyint              null,
   SendWay              tinyint              null,
   SendTime             datetime             null,
   SubmitTime           datetime             null default getdate(),
   Message              nvarchar(500)        not null,
   Status               tinyint              not null default 0,
   CompletedTime        datetime             null,
   IsDelete             bit                  null,
   SendCount            int                  not null default 0,
   SuccessCount         int                  not null default 0,
   FailCount            int                  not null default 0,
   SmsType              int                  null,
   Amount               bigint               not null default 0,
   ApprovalTimeApprovalTime datetime             null,
   MsgType              tinyint              null,
   CreateTime           datetime             not null default getdate(),
   constraint PK_SMS_TB_SEND_BILL primary key (MsgID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1 手工录入
   2 文本导入
   3 excel导入',
   'user', @CurrentUser, 'table', 'SMS_TB_Send_Bill', 'column', 'InputType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1 即时
   2 定时',
   'user', @CurrentUser, 'table', 'SMS_TB_Send_Bill', 'column', 'SendWay'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1 普通短信
   2 长短信
   3 免费短信',
   'user', @CurrentUser, 'table', 'SMS_TB_Send_Bill', 'column', 'SmsType'
go

/*==============================================================*/
/* Table: SMS_TB_Send_Detail_Bill                               */
/*==============================================================*/
create table SMS_TB_Send_Detail_Bill (
   SysID                int                  identity(1,1),
   MsgID                nvarchar(20)         not null,
   Mobile               varchar(12)          not null,
   Name                 nvarchar(20)         null,
   SendTime             datetime             null,
   Status               tinyint              not null default 0,
   ChennelID            int                  null,
   CreateTime           datetime             not null default getdate(),
   constraint PK_SMS_TB_SEND_DETAIL_BILL primary key (SysID)
)
go

/*==============================================================*/
/* View: Addr_VW_AllContactors_FullInfo                         */
/*==============================================================*/
create view Addr_VW_AllContactors_FullInfo as
SELECT     A.ContactorID, A.UserID, A.CompID, A.Name, A.JobPhone, A.JobFax, A.Mobile, A.HomePhone, A.Shared, A.DeleteMark, B.Sex, B.Birthday, B.Address, B.Company, 
                      B.Dept, B.Business, B.Email, B.Url, B.Remark, A.DefaultWayID, C.SysID, C.Field
FROM         dbo.Addr_TB_Contactor AS A WITH (NOLOCK) LEFT OUTER JOIN
                      dbo.Addr_TB_ContactorDetail AS B WITH (NOLOCK) ON A.ContactorID = B.ContactorID LEFT OUTER JOIN
                      dbo.Addr_TB_ContactField AS C WITH (NOLOCK) ON A.DefaultWayID = C.SysID
go

/*==============================================================*/
/* View: Addr_VW_Contactors_InContactGroup                      */
/*==============================================================*/
create view Addr_VW_Contactors_InContactGroup as
SELECT     A.UserID AS GOwnerUserID, A.CompID AS GOwnerCompID, B.ContactorID, B.ContactGroupID, B.DeleteMark, A.GroupName, C.UserID, C.CompID, C.Name, C.JobPhone, 
                      C.JobFax, C.Mobile, C.HomePhone, C.Shared, A.Shared AS GroupShared, A.DeleteMark AS GroupDeleteMark, C.DeleteMark AS ContactorDeleteMark, D.Sex, 
                      D.Birthday, D.Address, D.Company, D.Dept, D.Business, D.Email, D.Url, D.Remark, C.DefaultWayID, E.SysID, E.Field
FROM         dbo.Addr_TB_ContactGroup AS A WITH (NOLOCK) INNER JOIN
                      dbo.Addr_TB_ContactGroupMembers AS B WITH (NOLOCK) ON A.ContactGroupID = B.ContactGroupID AND A.UserID = B.UserID INNER JOIN
                      dbo.Addr_TB_Contactor AS C WITH (NOLOCK) ON B.ContactorID = C.ContactorID LEFT OUTER JOIN
                      dbo.Addr_TB_ContactorDetail AS D WITH (NOLOCK) ON C.ContactorID = D.ContactorID LEFT OUTER JOIN
                      dbo.Addr_TB_ContactField AS E WITH (NOLOCK) ON C.DefaultWayID = E.SysID
WHERE     (A.DeleteMark = 0) AND (B.DeleteMark = 0) AND (C.DeleteMark = 0)
go


Create Function [dbo].[Addr_FN_Split](@SourceSql Varchar(8000),@StrSeprate Varchar(10))
    Returns @temp Table(a Varchar(100))
    --实现split功能 的函数
As
    Begin
        Declare @i Int
        Set @SourceSql=rtrim(ltrim(@SourceSql))
        Set @i=charindex(@StrSeprate,@SourceSql)
        While @i>=1
        Begin
            Insert @temp Values(left(@SourceSql,@i-1))
            Set @SourceSql=substring(@SourceSql,@i+1,len(@SourceSql)-@i)
            Set @i=charindex(@StrSeprate,@SourceSql)
        End
        IF @SourceSql<>''
        Insert @temp Values(@SourceSql)
        Return 
    End
go



/*
作用：创建联系组
日期：2009-03-11
作者：lj
参数说明：

修改人：

修改日期：

修改内容：

*/
Create Procedure [dbo].[UP_Addr_ContactGroup_CreateSingleCGroup]
@UserID Int, --用户编号
@CompID INT,
@GroupName NVarchar(50),
@SharedFlag TINYINT,--0 不共享 1 共享
@ContactorGroupID int output,
@Remark nvarchar(1024)
As
Begin
	IF @UserID<=0 OR @GroupName='' RETURN 0;

	--如果存在同名的未删除的组，则不允许再生成一个同名的组
	IF(EXISTS(SELECT 1 FROM Addr_TB_ContactGroup WHERE UserID = @UserID AND GroupName = @GroupName AND DELETEMARK =0 ))
		RETURN -1;--do not edit this value
	--如果是个人用户(@CompID=0)，则默认为非共享
	IF @CompID = 0 SET @SharedFlag = 0;
	
	Declare @Now DateTime Set @Now = getdate()

	Insert Into Addr_TB_ContactGroup
	(
	 UserID
	,CompID
	,GroupName
	,Shared
	,ModifyUserID
	,LastModifyTime	
	,CreateTime
	,Remark
	)
	Values
	(
	 @UserID
	,@CompID
	,@GroupName
	,@SharedFlag
	,@UserID
	,@Now	
	,@Now
	,@Remark
	)
	IF @@Rowcount >0
		Set @ContactorGroupID = @@Identity
	Return 1
End
go



/*
作用：删除一个或多个联系组，根据Addr_SP_ContactGroup_DeleteCGroups修改
日期：20140719
作者：
*/
Create Procedure [dbo].[UP_Addr_ContactGroup_DeleteCGroups]
@UserID INT, --用户编号
@CompID INT=0,--企业编号，个人用户=0
@ContactGroupIDsList VARCHAR(256),--最大10
@Result INT=0 OUTPUT
AS
BEGIN
	Set @Result = 0;
	Declare @TempContactGroupID Table ( ContactGroupID Int ) 
	INSERT @TempContactGroupID (ContactGroupID)
	SELECT distinct a From Addr_FN_Split(@ContactGroupIDsList,',');
	IF(@@Rowcount=0) Return 0;--认为是异常
	
	--删除组，仅更新联系组主表[Addr_TB_ContactGroup].[DeleteMark]，组的其它属性(成员、成员数、共享设置)不更新
	Update a
	Set a.[DeleteMark] = 1,a.LastModifyTime=GETDATE()
	FROM [Addr_TB_ContactGroup] a, @TempContactGroupID b
	Where [UserID] = @UserID And CompID = @CompID AND a.[ContactGroupID] = b.[ContactGroupID];

	--删除组成员
	DELETE A FROM dbo.Addr_TB_ContactGroupMembers A, @TempContactGroupID b
	 WHERE [UserID] = @UserID AND a.[ContactGroupID] = b.[ContactGroupID];

	SET @Result = 1;
	RETURN 1;
END
go


/*
作用：设置联系组中联系人个数
日期：2014-07-11
作者：lj
参数说明：
@ContactGroupID      	组标识；  	
@MemberCount      	正数1表示增加1；负数表示减少1）
修改人：

修改日期：

修改内容：

*/
Create Procedure [dbo].[Addr_SP_ContactGroup_SetMemberCount]
@ContactGroupID Int,
@MemberCount    Int
As
Begin
	Update Addr_TB_ContactGroup 
	Set MemberCount =	
		CASE
			WHEN MemberCount + @MemberCount > 0 THEN MemberCount + @MemberCount
			WHEN MemberCount + @MemberCount <= 0 THEN 0
		END
	Where ContactGroupID=@ContactGroupID
End
go



/*
作用：编辑联系组信息
日期：2014-07-19
作者：lj
参数说明：
修改人：
修改日期：
修改内容：
*/
Create Procedure [dbo].[UP_Addr_ContactGroup_UpdateCGroupInfo]
@UserID Int,						--用户编号
@CompID Int,
@GroupName NVarchar(50),	--组名
@Remark  Varchar(1024),		--备注
@Shared       Int,			--是否共享
@ContactGroupID int			--联系组ID
AS
BEGIN
	IF @GroupName = '' RETURN 0;
	--如果存在同名的未删除的组，则不允许使用同该组名
	IF(EXISTS(SELECT 1 FROM Addr_TB_ContactGroup WHERE UserID = @UserID AND GroupName = @GroupName AND DELETEMARK =0 AND ContactGroupID<>@ContactGroupID ))
		RETURN -1;--do not edit this value	
	UPDATE dbo.Addr_TB_ContactGroup 
	SET GroupName=@GroupName,Shared=@Shared,Remark=@Remark,LastModifyTime=GETDATE()
	WHERE UserID=@UserID AND CompID = @CompID AND ContactGroupID=@ContactGroupID;
	
	RETURN 1;
End
go



/*=============================================================
对象名称: [UP_Addr_ContactorGroupManager_GetCGroupsListPage]
功能描述: 按照分页形式获取联系组记录列表
		= 0 时返回包含他人共享的所有联系组
		= 1 时返回自己非共享的联系组
		= 2 时返回自己共享的联系组
		= 3 时返回他人共享的联系组
		= 4 时返回不包含他人共享的联系组（含自己共享的，自己非共享的）
测试参数: 
创 建 人: ,2009-03-24
修改记录: #1.增加对个人用户的处理 
		返回的数据包含ShareType: 0-自有非共享联系组 1-自有共享联系组 2-他人共享联系组
		#2.,2013-07-24,重构+性能优化
		#3.2014-04-01，分页+重命名，原存储过程Addr_SP_ContactGroup_GetCGroupsListPage_V2
		exec UP_Addr_ContactorGroupManager_GetCGroupsListPage 254941,254940,0,1,100,'1'
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_ContactorGroupManager_GetCGroupsListPage]
	@UserID INT,  
	@CompID INT,--个人用户 CompID = 0,查找条件中，@CompID必须加上，用于过滤非法数据
	@SharedFlag TINYINT,--共享标识 0 – 所有的（默认）1 – 非共享联系组2 – 自己共享联系组3 – 他人共享联系组 4 - 不包含他人共享的联系组（含自己共享的，自己非共享的）  
	@PageIndex INT ,
    @PageSize INT,
	@SearchGroup NVARCHAR(200) 
AS
Begin
SET NOCOUNT ON

DECLARE
	@Sql NVARCHAR(MAX),
	@Where NVARCHAR(MAX),
	@ShareType NVARCHAR(MAX),
	@startRowIndex INT ,
    @endRowIndex INT
    
    SET @startRowIndex = @PageSize * ( @PageIndex - 1 ) + 1	-- 计算起始记录行
    SET @endRowIndex = @PageIndex * @PageSize	-- 计算结束记录行

SELECT
	@Sql = N'',
	@Where = N'',
	@ShareType = N''
	
IF (@UserID <= 0 OR @CompID < 0)
	RETURN 0;

IF (@SharedFlag NOT IN(0,1,2,3,4))
	RETURN 0;

IF (@CompID = 0)	--个人用户
BEGIN
	IF(@SharedFlag=0 OR @SharedFlag=4)--返回个人用户的所有联系组和不包含他人共享的联系组是一样的
	BEGIN
		SET @Where = ' AND UserID = @UserID'
		SET @ShareType = '
			CASE 
				WHEN [Shared]=0 THEN 0
				WHEN [Shared]=1 THEN 1 
			END'
	END
	ELSE IF(@SharedFlag=1)--返回自己非共享的联系组  
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 0'
		SET @ShareType = '0'
	END
	ELSE IF(@SharedFlag=2)--自己共享的联系组
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 1'
		SET @ShareType = '1'
	END    
END
ELSE	--企业用户
BEGIN
	IF(@SharedFlag=0)--返回企业用户的所有联系组
	BEGIN
		SET @Where = ' AND (UserID = @UserID OR [Shared] = 1)'
		SET @ShareType = '
			(CASE
				WHEN UserID = @UserID AND Shared = 0 THEN 0
				WHEN UserID = @UserID AND Shared = 1 THEN 1
				WHEN UserID <> @UserID AND Shared = 1 THEN 2
			END)'
	END
	ELSE IF(@SharedFlag=1)--返回自己非共享的联系组  
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 0'
		SET @ShareType = '0'
	END
	ELSE IF(@SharedFlag=2)--自己共享的联系组
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 1'
		SET @ShareType = '1'
	END
	ELSE IF(@SharedFlag=3)--他人共享的联系组
	BEGIN
		SET @Where = ' AND UserID <> @UserID AND [Shared] = 1'
		SET @ShareType = '2'
	END
	ELSE IF(@SharedFlag=4)--不包含他人共享的自有联系组
	BEGIN  
		SET @Where = ' AND UserID = @UserID'
		SET @ShareType =' 
			CASE 
				WHEN [Shared] = 0 THEN 0 
				WHEN [Shared] = 1 THEN 1		
			END'
	END
END

 --搜索内容
 IF @SearchGroup <> '' 
 Set @Where = @Where + ' And GroupName like ''%' + @SearchGroup +'%'''

SET @Sql = N'
SELECT
	rowid,
	[ContactGroupID],
	[UserID],
	[CompID],
	[GroupName],
	[MemberCount],
	[DeleteMark],
	[ModifyUserID],
	[LastModifyTime],
	[CreateTime],
	[Remark],
	[ShareType]
FROM
(
	SELECT
		rowid = ROW_NUMBER() OVER(ORDER BY ContactGroupID),
		[ContactGroupID],
		[UserID],
		[CompID],
		[GroupName],
		[MemberCount],
		[DeleteMark],
		[ModifyUserID],
		[LastModifyTime],
		[CreateTime],
		[Remark],
		[ShareType] = '+ @ShareType +'
	FROM dbo.Addr_TB_ContactGroup WITH (NOLOCK)
	WHERE CompID = @CompID
		AND DeleteMark = 0
	' + @Where +'
) T
WHERE rowid BETWEEN ' + CAST(@startRowIndex AS VARCHAR) + ' AND '
        + CAST(@endRowIndex AS VARCHAR)

EXEC sp_executesql
	@Sql,
	N'@CompID INT, @UserID INT,@startRowIndex INT,@endRowIndex INT,@SearchGroup VARCHAR(200)',
	@CompID = @CompID,
	@UserID = @UserID, 
	@startRowIndex = @startRowIndex,
    @endRowIndex = @endRowIndex,
	@SearchGroup=@SearchGroup
End
go



GO
/*=============================================================

对象名称: [UP_Addr_ContactorGroupManager_GetContactorsList]
功能描述: 按照分页形式获取联系人记录列表
		根据@SharedFlag 决定需要返回的数据(如果@CompID=0，则不会有以下的区分，仅按照seqno条件来取)
		针对返回所有联系人：
		= 0 时返回包含他人共享的联系人（仅在他人共享的联系组中的联系人不包含在内）
		= 1 时返回自己非共享的联系人
		= 2 时返回自己共享的联系人
		= 3 时返回他人共享的联系人
		= 4 时返回不包含他人共享的联系人（含自己共享的，自己非共享的）
		= 5 自己的还未添加到联系人中的联系方式
		= 6 他人的还未添加到联系人中的联系方式
		= 7 返回他人非共享的联系人
		= 8 返回他人的所有联系人（含他人共享的和他人非共享的）
		= 9 返回所有未添加到联系人中的联系方式

		针对返回自己的指定联系组中的联系人(即组编号<>0),@SharedFlag无效，也就是需要返回当前组中的所有未删除联系人
		针对他人共享的指定联系组中的联系人(即组编号<>0),@SharedFlag无效，也就是需要返回当前组中的所有未删除联系人

		以上均有带额外搜索条件和不带额外搜索条件两种
		返回的数据包含ShareType: 
		0-自有非共享联系人					"自己的非共享联系人"
		1-自有共享联系人					"自己的共享联系人"
		2-他有共享联系人					"他人的共享联系人"
		5-他有非共享联系人					"他人的非共享联系人"
测试参数: EXEC [UP_Addr_ContactorGroupManager_GetContactorsList] 398839, 254940,0,1,500,''
创 建 人: lj 2014-07-19
修改记录: 
		 exec Addr_SP_Tele_Contactor_GetContactorsListPage_New 
=============================================================*/
Create PROC [dbo].[UP_Addr_ContactorGroupManager_GetContactorsList]
	@UserID INT,
	@CompID INT,	--用于获取共享联系人
	@SharedFlag INT = 0,  --共享标识:0–所有的(默认),1–非共享用户,2–自己共享用户,3–他人共享用户,4-不包含他人共享的联系人(含自己共享的,自己非共享的)
	@PageIndex INT,
	@PageSize INT,
	@SearchContent VARCHAR(200)
AS
Begin
SET NOCOUNT ON

IF @UserID <= 0
	RETURN 0;

--个人用户查找他人共享的联系人，始终返回0行
IF(@CompID = 0 AND @SharedFlag=3) 
BEGIN
	RETURN 1;
END

DECLARE
	@Sql NVARCHAR(MAX),
	@ShareType NVARCHAR(255),
	@Where NVARCHAR(MAX),
	@startRowIndex INT,
	@endRowIndex INT
    
SET @startRowIndex = @PageSize * (@PageIndex - 1) + 1	-- 计算起始记录行
SET @endRowIndex = @PageIndex * @PageSize	-- 计算结束记录行


SELECT
	@Sql = N'',
	@Where = N''

--所有联系人页面使用的联系人共享属性判定
IF(@CompID = 0)  
BEGIN
	SET @ShareType = N'
			CASE
				WHEN [Shared]=0 THEN 0 
				WHEN [Shared]=1 THEN 1
			END' 
END
ELSE
BEGIN
	/*
	Addr_VW_InGroupContactors_FullInfo.SeqNo为联系人的所有人编号。
	UserID 与 @UserID是否相同即代表了该用户是否为他人共享用户
	CompID条件在这个case语句中不需要加，在where条件中进行获取有效数据时的判断
	*/
	SET @ShareType = N'
			CASE 
				WHEN [Shared]=0 AND UserID = ' + RTRIM(@UserID) + ' THEN 0 
				WHEN [Shared]=1 AND UserID = ' + RTRIM(@UserID) + ' THEN 1 
				WHEN [Shared]=1 AND UserID <> ' + RTRIM(@UserID) + ' THEN 2
				WHEN [Shared]=0 AND UserID <>' + RTRIM(@UserID) + ' THEN 5
			END
		' 
END

--获取数据的显示搜索条件
/*
根据共享标记返回联系人 add by hongdi begin
共享标识 0 – 所有的（默认）1 – 自己非共享用户 2 – 自己共享用户 3 – 他人共享用户 4 - 不包含他人共享的联系人（含自己共享的，自己非共享的）
针对所有联系人所有的列表的情况需要满足类似条件，以排除非自己的非共享用户：AND CompID = 1 AND (([Shared]=1 AND UserID <> 1) OR UserID = 1)
针对联系组成员的列表的情况需要满足类似条件，以排除非自己的非共享用户：AND CompID = 1 AND UserID = 1 AND (([Shared]=1 AND UserID <> COwnerUserID) OR UserID = COwnerUserID)
针对联系组成员的情况，只有UserID=COwnerUserID才是自有联系人
*/
IF @SharedFlag = 0
BEGIN		
	--所有联系人,只需依据CompID和UserID
	IF(@CompID = 0) --个人用户所有联系人
		SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID)
	ELSE --企业用户所有联系人
		SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND (([Shared]=1 AND UserID <> '+Cast(@UserID As Varchar)+') OR UserID = '+Cast(@UserID As Varchar)+')'
END  
ELSE IF @SharedFlag = 1 --自己非共享用户
BEGIN	
	--所有联系人中属于操作人自己的非共享部分
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 0'
END
ELSE IF @SharedFlag = 2 --自己共享用户(个人，企业同)
BEGIN	
	--所有联系人中属于操作人自己的共享部分
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 1'
END
ELSE IF @SharedFlag = 3 --他人共享用户(对于个人用户，此项无效，在入口处立即处理掉)
BEGIN
	--表示他人共享的联系人的条件为UserID <> @UserID And CompID = @CompID
	--表示他人共享的联系人的条件为UserID <> COwnerUserID And UserID = @UserID
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID <> ' + RTRIM(@UserID) + ' AND Shared = 1'
END
ELSE IF @SharedFlag = 4 --不包含他人共享的联系人（含自己共享的，自己非共享的）(个人，企业同)
BEGIN
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID) 
END

--搜索内容
 IF @SearchContent <> '' 
 Set @Where = @Where + 'And (Name like ''%' + @SearchContent +'%'' OR Field like ''%' + @SearchContent +'%'')'
 
--从所有联系人中获取
SET @Sql = N'
	SELECT *
	FROM
	(
		SELECT
			rowid = ROW_NUMBER() OVER(ORDER BY ContactorID DESC),
			A.[ContactorID],
			[UserID],
			[CompID],
			[Name],
			[JobPhone],
			[JobFax],
			[Mobile],
			[HomePhone],
			[Company],
			[Email],
			[DefaultWayID],
			[ShareType] = '+ @ShareType +',
			[Field],
			(SELECT COUNT(1) FROM dbo.Addr_TB_ContactField WHERE ContactorID=A.[ContactorID]) AS WayCount
		FROM dbo.Addr_VW_AllContactors_FullInfo A WITH(NOLOCK)
		WHERE DeleteMark = 0
		' + @Where + '
	) T
	WHERE rowid BETWEEN ' + CAST(@startRowIndex AS Varchar)	+ ' AND ' + CAST(@endRowIndex AS Varchar)
	PRINT(@Sql)
EXEC sp_executesql
	@Sql,
	N'@CompID INT, @UserID INT,@startRowIndex INT,@endRowIndex INT,@SearchContent VARCHAR(200)',
	@CompID = @CompID,
	@UserID = @UserID,
	@startRowIndex=@startRowIndex,
	@endRowIndex=@endRowIndex,
	@SearchContent=@SearchContent

RETURN 1;
End
go



/*=============================================================

对象名称: UP_Addr_ContactorGroupManager_GetUnGroupedContactors
功能描述: 获取未分组联系人
		根据@SharedFlag 决定需要返回的数据(如果@CompID=0，则不会有以下的区分，仅按照UserID条件来取)
		针对返回所有联系人：
		= 0 时返回包含他人共享的联系人（仅在他人共享的联系组中的联系人不包含在内）
		= 1 时返回自己非共享的联系人
		= 2 时返回自己共享的联系人
		= 3 时返回他人共享的联系人
		= 4 时返回不包含他人共享的联系人（含自己共享的，自己非共享的）
		= 5 自己的还未添加到联系人中的联系方式
		= 6 他人的还未添加到联系人中的联系方式
		= 7 返回他人非共享的联系人
		= 8 返回他人的所有联系人（含他人共享的和他人非共享的）
		= 9 返回所有未添加到联系人中的联系方式

		针对返回自己的指定联系组中的联系人(即组编号<>0),@SharedFlag无效，也就是需要返回当前组中的所有未删除联系人
		针对他人共享的指定联系组中的联系人(即组编号<>0),@SharedFlag无效，也就是需要返回当前组中的所有未删除联系人

		以上均有带额外搜索条件和不带额外搜索条件两种
		返回的数据包含ShareType: 
		0-自有非共享联系人					"自己的非共享联系人"
		1-自有共享联系人					"自己的共享联系人"
		2-他有共享联系人					"他人的共享联系人"
		5-他有非共享联系人					"他人的非共享联系人"
测试参数: EXEC UP_Addr_ContactorGroupManager_GetUnGroupedContactors 267553, 267552,0,1,100,''
创 建 人: lj 2014-07-6
		根据Addr_SP_Tele_Contactor_GetContactorsList修改
=============================================================*/
Create PROC [dbo].[UP_Addr_ContactorGroupManager_GetUnGroupedContactors]
    @UserID INT ,
    @CompID INT ,	--用于获取共享联系人
    @SharedFlag INT = 0 ,  --共享标识:0–所有的(默认),1–非共享用户,2–自己共享用户,3–他人共享用户,4-不包含他人共享的联系人(含自己共享的,自己非共享的)
    @PageIndex INT ,
    @PageSize INT ,
    @SearchContent VARCHAR(200)
AS
Begin
    SET NOCOUNT ON

    IF @UserID <= 0 
        RETURN 0;

--个人用户查找他人共享的联系人，始终返回0行
    IF ( @CompID = 0
         AND @SharedFlag = 3
       ) 
        BEGIN
            RETURN 1;
        END

    DECLARE @Sql NVARCHAR(MAX) ,
        @ShareType NVARCHAR(255) ,
        @Where NVARCHAR(MAX) ,
        @startRowIndex INT ,
        @endRowIndex INT
    
    SET @startRowIndex = @PageSize * ( @PageIndex - 1 ) + 1	-- 计算起始记录行
    SET @endRowIndex = @PageIndex * @PageSize	-- 计算结束记录行

    SELECT  @Sql = N'' ,
            @Where = N''

--所有联系人页面使用的联系人共享属性判定
    IF ( @CompID = 0 ) 
        BEGIN
            SET @ShareType = N'
			CASE
				WHEN [Shared]=0 THEN 0 
				WHEN [Shared]=1 THEN 1
			END' 
        END
    ELSE 
        BEGIN
	/*
	Addr_VW_InGroupContactors_FullInfo.UserID为联系人的所有人编号。
	UserID 与 @UserID是否相同即代表了该用户是否为他人共享用户
	CompID条件在这个case语句中不需要加，在where条件中进行获取有效数据时的判断
	*/
            SET @ShareType = N'
			CASE 
				WHEN [Shared]=0 AND A.UserID = ' + RTRIM(@UserID) + ' THEN 0 
				WHEN [Shared]=1 AND A.UserID = ' + RTRIM(@UserID) + ' THEN 1 
				WHEN [Shared]=1 AND A.UserID <> ' + RTRIM(@UserID) + ' THEN 2
				WHEN [Shared]=0 AND A.UserID <> ' + RTRIM(@UserID) + ' THEN 5
			END
		' 
        END

--获取数据的显示搜索条件
/*
根据共享标记返回联系人 add by hongdi begin
共享标识 0 – 所有的（默认）1 – 自己非共享用户 2 – 自己共享用户 3 – 他人共享用户 4 - 不包含他人共享的联系人（含自己共享的，自己非共享的）
针对所有联系人所有的列表的情况需要满足类似条件，以排除非自己的非共享用户：AND CompID = 1 AND (([Shared]=1 AND UserID <> 1) OR UserID = 1)
针对联系组成员的列表的情况需要满足类似条件，以排除非自己的非共享用户：AND CompID = 1 AND UserID = 1 AND (([Shared]=1 AND UserID <> COwnerUserID) OR UserID = COwnerUserID)
针对联系组成员的情况，只有UserID=COwnerUserID才是自有联系人
*/
    IF @SharedFlag = 0 
        BEGIN		
	--所有联系人,只需依据CompID和UserID
            IF ( @CompID = 0 ) --个人用户所有联系人
                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                    + ' AND A.UserID = ' + RTRIM(@UserID)
            ELSE --企业用户所有联系人
                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                    + ' AND (A.UserID = ' + RTRIM(@UserID) + ' OR Shared = 1)'
        END  
    ELSE 
        IF @SharedFlag = 1 --自己非共享用户
            BEGIN	
	--所有联系人中属于操作人自己的非共享部分
                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                    + ' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 0'
            END
        ELSE 
            IF @SharedFlag = 2 --自己共享用户(个人，企业同)
                BEGIN	
	--所有联系人中属于操作人自己的共享部分
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 1'
                END
            ELSE 
                IF @SharedFlag = 3 --他人共享用户(对于个人用户，此项无效，在入口处立即处理掉)
                    BEGIN
	--表示他人共享的联系人的条件为UserID <> @UserID And CompID = @CompID
	--表示他人共享的联系人的条件为UserID <> COwnerUserID And UserID = @UserID
                        SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                            + ' AND UserID <>' + RTRIM(@UserID)
                            + ' AND Shared = 1'
                    END
                ELSE 
                    IF @SharedFlag = 4 --不包含他人共享的联系人（含自己共享的，自己非共享的）(个人，企业同)
                        BEGIN
                            SET @Where = ' AND CompID =' + RTRIM(@CompID)
                                + 'AND UserID = ' + RTRIM(@UserID)
                        END
 
 --搜索内容
 IF @SearchContent <> '' 
 Set @Where = @Where + 'And (Name like ''%' + @SearchContent +'%'' OR Field like ''%' + @SearchContent +'%'')'

--从所有联系人中获取
    SET @Sql = N'
	SELECT *
	FROM
	(
		SELECT
			rowid = ROW_NUMBER() OVER(ORDER BY A.ContactorID DESC),
			A.[ContactorID],
			A.[UserID],
			[CompID],
			[Name],
			[JobPhone],
			[JobFax],
			[Mobile],
			[HomePhone],
			[Company],
			[Email],
			[DefaultWayID],
			[ShareType] = ' + @ShareType + ',
			[Field],
			(SELECT COUNT(1) FROM dbo.Addr_TB_ContactField WHERE ContactorID=A.[ContactorID]) AS WayCount
		FROM dbo.Addr_VW_AllContactors_FullInfo A WITH(NOLOCK)		
		WHERE A.DeleteMark = 0
		' + @Where
        + '
		AND NOT EXISTS (SELECT ContactorID FROM dbo.Addr_TB_ContactGroupMembers WHERE UserID='
        + RTRIM(@UserID) + ' AND DeleteMark=0 AND ContactorID=A.ContactorID)
	) T
	WHERE rowid BETWEEN ' + CAST(@startRowIndex AS VARCHAR) + ' AND '
        + CAST(@endRowIndex AS VARCHAR)

    PRINT ( @sql )
    EXEC sp_executesql @Sql,
        N'@CompID INT, @UserID INT,@startRowIndex INT,@endRowIndex INT,@SearchContent VARCHAR(200)',
        @CompID = @CompID, @UserID = @UserID, @startRowIndex = @startRowIndex,
        @endRowIndex = @endRowIndex, @SearchContent = @SearchContent

    RETURN 1;
End
go



/*=============================================================
对象名称: UP_Addr_ContactorGroupManager_GetUserContactorsCount
功能描述: 按照分页形式获取联系人记录列表
测试参数: EXEC UP_Addr_ContactorGroupManager_GetUserContactorsCount 254941, 254940,0,0,'',0
创 建 人: lj 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_ContactorGroupManager_GetUserContactorsCount]
    @UserID INT ,
    @CompID INT ,	--用于获取共享联系人
    @SharedFlag INT = 0 ,  --共享标识:0–所有的(默认)
    @GroupID INT , --0-全部  -2-未分组
    @SearchContent VARCHAR(200),
	@Count INT OUTPUT
AS 
    BEGIN
        SET NOCOUNT ON;

        IF @UserID <= 0 
            RETURN 0;

--个人用户查找他人共享的联系人，始终返回0行
        IF ( @CompID = 0
             AND @SharedFlag = 3
           ) 
            BEGIN
                RETURN -1;
            END

        DECLARE @Sql NVARCHAR(MAX) ,
            @Where NVARCHAR(MAX) ,
            @Table NVARCHAR(MAX)
        
        SELECT  @Sql = N'' ,
                @Where = N'' ,
                @Table = N''

        IF @SharedFlag = 0 
            BEGIN		
	--所有联系人,只需依据CompID和UserID
                IF ( @CompID = 0 ) --个人用户所有联系人
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND UserID = ' + RTRIM(@UserID)
                ELSE --企业用户所有联系人
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND (([Shared]=1 AND UserID <> '
                        + CAST(@UserID AS VARCHAR) + ') OR UserID = '
                        + CAST(@UserID AS VARCHAR) + ')'
            END  
        ELSE 
            IF @SharedFlag = 1 --自己非共享用户
                BEGIN	
	--所有联系人中属于操作人自己的非共享部分
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 0'
                END
            ELSE 
                IF @SharedFlag = 2 --自己共享用户(个人，企业同)
                    BEGIN	
	--所有联系人中属于操作人自己的共享部分
                        SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                            + ' AND UserID = ' + RTRIM(@UserID)
                            + ' AND Shared = 1'
                    END
                ELSE 
                    IF @SharedFlag = 3 --他人共享用户(对于个人用户，此项无效，在入口处立即处理掉)
                        BEGIN
	--表示他人共享的联系人的条件为UserID <> @UserID And CompID = @CompID
	--表示他人共享的联系人的条件为UserID <> COwnerUserID And UserID = @UserID
                            SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                                + ' AND UserID <> ' + RTRIM(@UserID)
                                + ' AND Shared = 1'
                        END
                    ELSE 
                        IF @SharedFlag = 4 --不包含他人共享的联系人（含自己共享的，自己非共享的）(个人，企业同)
                            BEGIN
                                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                                    + ' AND UserID = ' + RTRIM(@UserID) 
                            END

--搜索内容
        IF @SearchContent <> '' 
            SET @Where = @Where + 'And Name like ''%' + @SearchContent + '%'''
 
 --分组
        IF @GroupID > 0 
            BEGIN
                SET @Table = 'Addr_VW_Contactors_InContactGroup'
                SET @Where = @Where + ' AND ContactGroupID = '
                    + RTRIM(@GroupID)
            END
        ELSE 
            IF @GroupID = -2 
                BEGIN
                    SET @Table = 'Addr_VW_AllContactors_FullInfo'
                    SET @Where = @Where
                        + ' AND NOT EXISTS (SELECT ContactorID FROM dbo.Addr_TB_ContactGroupMembers WHERE UserID='
                        + RTRIM(@UserID)
                        + ' AND DeleteMark=0 AND ContactorID=A.ContactorID)'
                END
            ELSE 
                SET @Table = 'Addr_VW_AllContactors_FullInfo'         

        SET @Sql = N'
SELECT @level=COUNT(1) FROM ' + @Table + ' A WITH(NOLOCK) WHERE A.DeleteMark=0 '
            + @Where

        PRINT ( @Sql )

        EXEC sp_executesql @Sql,
            N'@CompID INT, @UserID INT, @GroupID INT,@SearchContent VARCHAR(200),@level int OUTPUT',
            @CompID = @CompID, @UserID = @UserID, @GroupID = @GroupID,
            @SearchContent = @SearchContent,@level=@Count OUT
		
		RETURN 1
    END
go



/*=============================================================

对象名称: UP_Addr_ContactorGroupManager_GetUserGroupContactors
功能描述: 按照分页形式获取联系人记录列表
		根据@SharedFlag 决定需要返回的数据(如果@CompID=0，则不会有以下的区分，仅按照UserID条件来取)
		针对返回所有联系人：
		= 0 时返回包含他人共享的联系人（仅在他人共享的联系组中的联系人不包含在内）
		= 1 时返回自己非共享的联系人
		= 2 时返回自己共享的联系人
		= 3 时返回他人共享的联系人
		= 4 时返回不包含他人共享的联系人（含自己共享的，自己非共享的）
		= 5 自己的还未添加到联系人中的联系方式
		= 6 他人的还未添加到联系人中的联系方式
		= 7 返回他人非共享的联系人
		= 8 返回他人的所有联系人（含他人共享的和他人非共享的）
		= 9 返回所有未添加到联系人中的联系方式

		针对返回自己的指定联系组中的联系人(即组编号<>0),@SharedFlag无效，也就是需要返回当前组中的所有未删除联系人
		针对他人共享的指定联系组中的联系人(即组编号<>0),@SharedFlag无效，也就是需要返回当前组中的所有未删除联系人

		以上均有带额外搜索条件和不带额外搜索条件两种
		返回的数据包含ShareType: 
		0-自有非共享联系人					"自己的非共享联系人"
		1-自有共享联系人					"自己的共享联系人"
		2-他有共享联系人					"他人的共享联系人"
		5-他有非共享联系人					"他人的非共享联系人"
测试参数: EXEC UP_Addr_ContactorGroupManager_GetUserGroupContactors 267553, 267552,6680,0,1,100,''
创 建 人: 高梦 2014-1-3 
		根据Addr_SP_Tele_Contactor_GetContactorsList修改		
=============================================================*/
Create PROC [dbo].[UP_Addr_ContactorGroupManager_GetUserGroupContactors]
	@UserID INT,
	@CompID INT,	--用于获取共享联系人
	@GroupID INT,   --组ID 
	@SharedFlag INT = 0,  --共享标识:0–所有的(默认),1–非共享用户,2–自己共享用户,3–他人共享用户,4-不包含他人共享的联系人(含自己共享的,自己非共享的)
	@PageIndex INT,
	@PageSize INT,
	@SearchContent VARCHAR(200)
AS
Begin
SET NOCOUNT ON

IF @UserID <= 0
	RETURN 0;

--个人用户查找他人共享的联系人，始终返回0行
IF(@CompID = 0 AND @SharedFlag=3) 
BEGIN
	RETURN 1;
END

DECLARE
	@Sql NVARCHAR(MAX),
	@ShareType NVARCHAR(255),
	@Where NVARCHAR(MAX),
	@startRowIndex INT,
	@endRowIndex INT
    
SET @startRowIndex = @PageSize * (@PageIndex - 1) + 1	-- 计算起始记录行
SET @endRowIndex = @PageIndex * @PageSize	-- 计算结束记录行

SELECT
	@Sql = N'',
	@Where = N''

--所有联系人页面使用的联系人共享属性判定
IF(@CompID = 0)  
BEGIN
	SET @ShareType = N'
			CASE
				WHEN [Shared]=0 THEN 0 
				WHEN [Shared]=1 THEN 1
			END' 
END
ELSE
BEGIN
	/*
	Addr_VW_InGroupContactors_FullInfo.UserID为联系人的所有人编号。
	UserID 与 @UserID是否相同即代表了该用户是否为他人共享用户
	CompID条件在这个case语句中不需要加，在where条件中进行获取有效数据时的判断
	*/
	SET @ShareType = N'
			CASE 
				WHEN [Shared]=0 AND A.UserID = '+RTRIM(@UserID)+' THEN 0 
				WHEN [Shared]=1 AND A.UserID = '+RTRIM(@UserID)+' THEN 1 
				WHEN [Shared]=1 AND A.UserID <> '+RTRIM(@UserID)+' THEN 2
				WHEN [Shared]=0 AND A.UserID <> '+RTRIM(@UserID)+' THEN 5
			END
		' 
END

--获取数据的显示搜索条件
/*
根据共享标记返回联系人 add by hongdi begin
共享标识 0 – 所有的（默认）1 – 自己非共享用户 2 – 自己共享用户 3 – 他人共享用户 4 - 不包含他人共享的联系人（含自己共享的，自己非共享的）
针对所有联系人所有的列表的情况需要满足类似条件，以排除非自己的非共享用户：AND CompID = 1 AND (([Shared]=1 AND UserID <> 1) OR UserID = 1)
针对联系组成员的列表的情况需要满足类似条件，以排除非自己的非共享用户：AND CompID = 1 AND UserID = 1 AND (([Shared]=1 AND UserID <> COwnerUserID) OR UserID = COwnerUserID)
针对联系组成员的情况，只有UserID=COwnerUserID才是自有联系人
*/
IF @SharedFlag = 0
BEGIN		
	--所有联系人,只需依据CompID和UserID
	IF(@CompID = 0) --个人用户所有联系人
		SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND A.UserID = '+RTRIM(@UserID)
	ELSE --企业用户所有联系人
		SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND (([Shared]=1 AND UserID <> '+Cast(@UserID As Varchar)+') OR UserID = '+Cast(@UserID As Varchar)+')'
END  
ELSE IF @SharedFlag = 1 --自己非共享用户
BEGIN	
	--所有联系人中属于操作人自己的非共享部分
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID = '+RTRIM(@UserID)+' AND Shared = 0'
END
ELSE IF @SharedFlag = 2 --自己共享用户(个人，企业同)
BEGIN	
	--所有联系人中属于操作人自己的共享部分
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID = '+RTRIM(@UserID)+' AND Shared = 1'
END
ELSE IF @SharedFlag = 3 --他人共享用户(对于个人用户，此项无效，在入口处立即处理掉)
BEGIN
	--表示他人共享的联系人的条件为UserID <> @UserID And CompID = @CompID
	--表示他人共享的联系人的条件为UserID <> COwnerUserID And UserID = @UserID
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID <> '+RTRIM(@UserID)+' AND Shared = 1'
END
ELSE IF @SharedFlag = 4 --不包含他人共享的联系人（含自己共享的，自己非共享的）(个人，企业同)
BEGIN
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID = '+RTRIM(@UserID)+''
END
 
 --搜索内容
 IF @SearchContent <> '' 
 Set @Where = @Where +  'And (Name like ''%' + @SearchContent +'%'' OR Field like ''%' + @SearchContent +'%'')'
 
--分组
IF @GroupID > 0
Set @Where = @Where + ' AND ContactGroupID = ' + RTRIM(@GroupID)
			
--从所有联系人中获取
SET @Sql = N'
	SELECT *
	FROM
	(
		SELECT
			rowid = ROW_NUMBER() OVER(ORDER BY A.ContactorID DESC),
			A.[ContactorID],
			A.[UserID],
			[CompID],
			[Name],
			[JobPhone],
			[JobFax],
			[Mobile],
			[HomePhone],
			[Company],
			[Email],
			[DefConfPhoneIdx],
			[ShareType] = '+ @ShareType +',
			[Field],
			(SELECT COUNT(1) FROM dbo.Addr_TB_ContactField WHERE ContactorID=A.[ContactorID]) AS WayCount
		FROM dbo.Addr_VW_Contactors_InContactGroup A WITH(NOLOCK)
		WHERE DeleteMark=0
		' + @Where + '
	) T
	WHERE rowid BETWEEN ' + CAST(@startRowIndex AS Varchar)	+ ' AND ' + CAST(@endRowIndex AS Varchar)
			
PRINT(@sql)
EXEC sp_executesql
	@Sql,
	N'@CompID INT, @UserID INT, @GroupID INT,@startRowIndex INT,@endRowIndex INT,@SearchContent VARCHAR(200)',
	@CompID = @CompID,
	@UserID = @UserID,
	@GroupID=@GroupID,
	@startRowIndex=@startRowIndex,
	@endRowIndex=@endRowIndex,
	@SearchContent=@SearchContent

RETURN 1;
End
go



/*=============================================================

对象名称: UP_Addr_Contactor_SetMutilField
功能描述: 批量添加联系人联系方式
测试参数: EXEC UP_Addr_Contactor_SetMutilField
创 建 人: lj,2014-07-19
修改记录: 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_SetMutilField]
    @UserID INT ,
    @CompID INT ,
    @ContactorID BIGINT ,
    @ContactWay XML ,
    @ConfParticipatePhoneNo VARCHAR(50)
AS 
Begin
    SET NOCOUNT ON
/*
<ContactWay>
	<Way>
		<WayType>1</WayType>
		<WayField>13810712519</WayField>
	</Way>
	<Way>
		<WayType>3</WayType>
		<WayField>346425159@qq.com</WayField>
	</Way>
</ContactWay>
*/
    DELETE  dbo.Addr_TB_ContactField
    WHERE   UserID = @UserID
            AND CompID = @CompID
            AND ContactorID = @ContactorID

    INSERT  INTO dbo.Addr_TB_ContactField
            ( ContactorID ,
              UserID ,
              CompID ,
              Field ,
              FieldType
            )
            SELECT  @ContactorID ,
                    @UserID ,
                    @CompID ,
                    Field = T.c.value('(./WayField/text())1', 'VARCHAR(200)') ,
                    FieldType = T.c.value('(./WayType/text())1', 'INT')
            FROM    @ContactWay.nodes('/ContactWay/Way') AS T ( c )

	--更新参会号码
    UPDATE  dbo.Addr_TB_Contactor
    SET     DefaultWayID = ( SELECT  SysID
                                FROM    dbo.Addr_TB_ContactField
                                WHERE   ContactorID = @ContactorID
                                        AND Field = @ConfParticipatePhoneNo
                              )
    WHERE   ContactorID = @ContactorID
End
go


/*=============================================================

对象名称: UP_Addr_Contactor_AddContactor
功能描述: 添加联系人信息
测试参数: EXEC UP_Addr_Contactor_AddContactor
创 建 人: lj 2014-07-19
修改记录: 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_AddContactor]
    @UserID INT,
    @CompID INT,
    @Name NVARCHAR(20),
    @ContactWay XML,
    @ContactGroup XML,
	@ConfParticipatePhoneNo VARCHAR(50)
AS
Begin
SET NOCOUNT ON;
/*
<ContactWay>
	<Way>
		<WayType>1</WayType>
		<WayField>13810712519</WayField>
	</Way>
	<Way>
		<WayType>3</WayType>
		<WayField>346425159@qq.com</WayField>
	</Way>
</ContactWay>
<ContactGroup>
	<Group>
		<GroupID>1</GroupID>
	</Group>
	<Group>
		<GroupID>3</GroupID>
	</Group>
</ContactGroup>
*/
DECLARE @contactorId INT
DECLARE @Now DATETIME 
SET @contactorId = 0
SET @Now = GETDATE()

--添加联系人基本信息
INSERT INTO dbo.Addr_TB_Contactor
( 
	UserID,
	CompID,
	Name,
	JobPhone,
	JobFax,
	Mobile,
	HomePhone,
	Shared,
	DeleteMark,
	LastModifyTime,
	ModifyUserID,
	CreateTime,
	Spell
)
VALUES  
(
	@UserID,
	@CompID,
	@Name,
	'',
	'',
	'',
	'',
	0,
	0,
	@Now,
	@UserID,
	@Now,
	N''
)    
SET @contactorId = SCOPE_IDENTITY()

--添加联系人详细信息
INSERT INTO dbo.Addr_TB_ContactorDetail
( 
	ContactorID,
	Sex,
	Birthday,
	Address,
	Company,
	Dept,
	Business,
	Email,
	Url,
	ZipCode,
	Remark,
	CreateTime,
	LastModifyTime
)
VALUES  
(
	@contactorId,
	0,
	'',
	N'',
	N'',
	N'',
	N'',
	N'',
	N'',
	N'',
	N'',
	@Now,
	@Now
)

--添加联系人分组
INSERT INTO dbo.Addr_TB_ContactGroupMembers
(
	UserID,
	ContactGroupID,
	ContactorID,
	DeleteMark
)
SELECT 
	@UserID,
	ContactGroupID = T.d.value('(./GroupID/text())1', 'INT'),
	@ContactorID,
	0
FROM @ContactGroup.nodes('/ContactGroup/Group') AS T(d)

--更新组memberCount
UPDATE A
SET A.MemberCount = A.MemberCount + 1
FROM dbo.Addr_TB_ContactGroup A
INNER JOIN 
(
	SELECT ContactGroupID= T.b.value('(./GroupID/text())1', 'INT')
	FROM @ContactGroup.nodes('/ContactGroup/Group') AS T(b) 
) B
on A.ContactGroupID= B.ContactGroupID
WHERE A.UserID=@UserID AND A.CompID=@CompID 


--添加联系人联系方式
EXEC UP_Addr_Contactor_SetMutilField
	@UserID,
	@CompID,
	@contactorId,
    @ContactWay,
	@ConfParticipatePhoneNo
 End
go



/*=============================================================
对象名称: Addr_SP_Contactor_AddMultiContactorToMultiGroup
功能描述: 将多个联系人添加,删除或移动到多个分组
测试参数: EXEC Addr_SP_Contactor_AddMultiContactorToMultiGroup 
创 建 人: 
修改记录: 
=============================================================*/
Create PROCEDURE [dbo].[Addr_SP_Contactor_AddMultiContactorToMultiGroup]
	@CompID INT,
	@UserID INT,
	@ContactorList XML,
	@GroupList XML
AS
Begin
SET NOCOUNT ON
/*
<ContactGroup>
	<Group>
		<GroupID>1</GroupID>
	</Group>
	<Group>
		<GroupID>3</GroupID>
	</Group>
</ContactGroup>
<ContactorInfo>
	<Contactor>
		<ContactorID>771388</ContactorID>
	</Contactor>
	<Contactor>
		<ContactorID>771387</ContactorID>
	</Contactor>
</ContactorInfo>
*/
DECLARE @tempGroupList TABLE
(
	ContactGroupID INT
)

DECLARE @tableGroupList TABLE
(
	ContactGroupID INT NOT NULL PRIMARY KEY
)
DECLARE @tableContactorList TABLE
(
	ContactorID INT NOT NULL PRIMARY KEY
)

IF(@CompID <= 0 OR @UserID <= 0)
BEGIN
	RETURN -1
END

--只能操作自己的人或同一CompID下共享的人(Shared=1)
INSERT INTO @tableContactorList
(
	ContactorID
)
SELECT DISTINCT A.ContactorID
FROM dbo.Addr_TB_Contactor A
	INNER JOIN
	(
		SELECT ContactorID = T.c.value('(./ContactorID/text())1', 'INT')
		FROM @ContactorList.nodes('/ContactorInfo/Contactor') AS T(c)
	) B
		ON A.ContactorID = B.ContactorID
WHERE A.UserID = @UserID OR (CompID = @CompID AND UserID <> @UserID AND Shared = 1)

--如果联系人无效,则返回
IF NOT EXISTS
(
	SELECT 1
	FROM @tableContactorList
)
BEGIN
	RETURN -2
END

--只能操作自己的(SeqNo)组
INSERT INTO @tableGroupList
(
	ContactGroupID
)
SELECT DISTINCT A.ContactGroupID
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN
	(
		SELECT ContactGroupID = T.c.value('(./GroupID/text())1', 'INT')
		FROM @GroupList.nodes('/ContactGroup/Group') AS T(c)
	) B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#1.1添加联系人到自己的分组(如果记录已经存在,则恢复删除标记)
DELETE @tempGroupList

UPDATE A
SET A.DeleteMark = 0
OUTPUT DELETED.ContactGroupID
INTO @tempGroupList(ContactGroupID)
FROM dbo.Addr_TB_ContactGroupMembers A
	INNER JOIN @tableGroupList B
		ON A.ContactGroupID = B.ContactGroupID
	INNER JOIN @tableContactorList C
		ON A.ContactorID = C.ContactorID
WHERE A.UserID = @UserID
	AND A.DeleteMark = 1

--更新组内联系人数量
UPDATE A
SET A.MemberCount = A.MemberCount + B.Cnt
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN 
	(
		SELECT 
			ContactGroupID,
			Cnt = COUNT(1)
		FROM @tempGroupList
		GROUP BY ContactGroupID
	) B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#1.2添加联系人到自己的分组(如果记录不存在,则插入)
DELETE @tempGroupList

INSERT INTO dbo.Addr_TB_ContactGroupMembers 
(
	UserID,
	ContactorID,
	ContactGroupID,
	DeleteMark
)
OUTPUT INSERTED.ContactGroupID
INTO @tempGroupList(ContactGroupID)
SELECT
	@UserID,
	B.ContactorID,
	A.ContactGroupID,
	0
FROM @tableGroupList A
	CROSS JOIN @tableContactorList B
WHERE NOT EXISTS
(
	SELECT 1
	FROM dbo.Addr_TB_ContactGroupMembers M WITH(NOLOCK)
	WHERE M.ContactGroupID = A.ContactGroupID
		AND M.ContactorID = B.ContactorID
)

--更新组内联系人数量
UPDATE A
SET A.MemberCount = A.MemberCount + B.Cnt
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN 
	(
		SELECT 
			ContactGroupID,
			Cnt = COUNT(1)
		FROM @tempGroupList
		GROUP BY ContactGroupID
	) B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#2.从自己的分组中删除联系人
DELETE @tempGroupList

UPDATE A
SET A.DeleteMark = 1
OUTPUT DELETED.ContactGroupID
INTO @tempGroupList(ContactGroupID)
FROM dbo.Addr_TB_ContactGroupMembers A
WHERE A.UserID = @UserID
	AND a.DeleteMark = 0
	AND EXISTS
	(
		SELECT 1
		FROM @tableContactorList M
		WHERE M.ContactorID = A.ContactorID
	)
	AND NOT EXISTS
	(
		SELECT 1
		FROM @tableGroupList N
		WHERE N.ContactGroupID = A.ContactGroupID
	)

--更新组内联系人数量
UPDATE A
SET A.MemberCount = (CASE WHEN A.MemberCount - B.Cnt < 0 THEN 0 ELSE A.MemberCount - B.Cnt END)
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN 
	(
		SELECT 
			ContactGroupID,
			Cnt = COUNT(1)
		FROM @tempGroupList
		GROUP BY ContactGroupID
	) B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID
End
go


/*=============================================================
对象名称: UP_Addr_Contactor_AddMutilField
功能描述: 批量添加联系人联系方式
测试参数: EXEC UP_Addr_Contactor_AddMutilField
创 建 人: lj
修改记录: 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_AddMutilField]
    @UserID INT ,
    @CompID INT ,
    @ContactorID BIGINT ,
    @ContactWay XML ,
    @ConfParticipatePhoneNo VARCHAR(50)
AS
Begin
    SET NOCOUNT ON
/*
<ContactWay>
	<Way>
		<WayType>1</WayType>
		<WayField>13810712519</WayField>
	</Way>
	<Way>
		<WayType>3</WayType>
		<WayField>346425159@qq.com</WayField>
	</Way>
</ContactWay>
*/
    DELETE  dbo.Addr_TB_ContactField
    WHERE   UserID = @UserID
            AND CompID = @CompID
            AND ContactorID = @ContactorID

    INSERT  INTO dbo.Addr_TB_ContactField
            ( ContactorID ,
              UserID ,
              CompID ,
              Field ,
              FieldType
            )
            SELECT  @ContactorID ,
                    @UserID ,
                    @CompID ,
                    Field = T.c.value('(./WayField/text())1', 'VARCHAR(200)') ,
                    FieldType = T.c.value('(./WayType/text())1', 'INT')
            FROM    @ContactWay.nodes('/ContactWay/Way') AS T ( c )

	--更新参会号码
    UPDATE  dbo.Addr_TB_Contactor
    SET     DefaultWayID = ( SELECT  SysID
                                FROM    dbo.Addr_TB_ContactField
                                WHERE   ContactorID = @ContactorID
                                        AND Field = @ConfParticipatePhoneNo
                              )
    WHERE   ContactorID = @ContactorID
End
go



/*=============================================================
对象名称: UP_Addr_Contactor_AddSingleToCGroups
功能描述: 将单个联系人加入或退出多个组
测试参数: EXEC UP_Addr_Contactor_AddSingleToCGroups 94,93,1,'<ContactGroup><Group><GroupID>1</GroupID></Group></ContactGroup>'
创 建 人: 骆进,2009-03-11
修改记录: #1.2009-04-18,调整加入或退出的逻辑:联系组必须是操作人本身创建的
		 #22013-12-09,重构逻辑
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_AddSingleToCGroups]
	@UserID INT, --用户编号
	@CompID INT, --企业编号
	@ContactorID INT, --联系人ID
	@ContactorGroupIDList XML	--组列表
AS
Begin
SET NOCOUNT ON
/*
<ContactGroup>
	<Group>
		<GroupID>1</GroupID>
	</Group>
	<Group>
		<GroupID>3</GroupID>
	</Group>
</ContactGroup>
*/
DECLARE @tempGroupList TABLE
(
	ContactGroupID INT NOT NULL PRIMARY KEY
)

DECLARE @tableContactorGroupList TABLE
(
	ContactGroupID INT NOT NULL PRIMARY KEY
)

IF (@UserID <= 0 OR @ContactorID <= 0)
BEGIN
	RETURN -1;
END

--联系人必须是本SeqNo的,或者同一个公司的其他SeqNo共享出来的.
IF NOT EXISTS
(
	SELECT 1
	FROM dbo.Addr_TB_Contactor WITH(NOLOCK)
	WHERE [ContactorID] = @ContactorID 
		AND (UserID = @UserID OR (CompID = @CompID AND UserID <> @UserID AND Shared = 1))
)
BEGIN
	RETURN -2
END

--只操作本SeqNo创建的分组
INSERT INTO @tableContactorGroupList
(
	ContactGroupID
)
SELECT DISTINCT A.ContactGroupID
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN
	(
		SELECT ContactGroupID = T.c.value('(./GroupID/text())1', 'INT')
		FROM @ContactorGroupIDList.nodes('/ContactGroup/Group') AS T(c)
	) B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#1.1添加联系人到自己的分组(如果记录已经存在,则恢复删除标记)
DELETE @tempGroupList

UPDATE A
SET A.DeleteMark = 0
OUTPUT DELETED.ContactGroupID
INTO @tempGroupList(ContactGroupID)
FROM dbo.Addr_TB_ContactGroupMembers A
WHERE A.UserID = @UserID
	AND A.ContactorID = @ContactorID
	AND A.DeleteMark = 1
	AND EXISTS
	(
		SELECT 1
		FROM @tableContactorGroupList B
		WHERE B.ContactGroupID = A.ContactGroupID
	)

--更新组内联系人数量
UPDATE A
SET A.MemberCount = A.MemberCount + 1
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN @tempGroupList B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#1.2添加联系人到自己的分组(如果记录不存在,则插入)
DELETE @tempGroupList

INSERT INTO dbo.Addr_TB_ContactGroupMembers 
(
	UserID,
	ContactorID,
	ContactGroupID,
	DeleteMark
)
OUTPUT INSERTED.ContactGroupID
INTO @tempGroupList(ContactGroupID)
SELECT
	@UserID,
	@ContactorID,
	A.ContactGroupID,
	0
FROM @tableContactorGroupList A
WHERE NOT EXISTS
(
	SELECT 1
	FROM dbo.Addr_TB_ContactGroupMembers B WITH(NOLOCK)
	WHERE B.ContactGroupID = A.ContactGroupID
		AND B.ContactorID = @ContactorID
)

--更新组内联系人数量
UPDATE A
SET A.MemberCount = A.MemberCount + 1
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN @tempGroupList B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#2.从自己的分组中删除联系人
DELETE @tempGroupList

UPDATE A
SET A.DeleteMark = 1
OUTPUT DELETED.ContactGroupID
INTO @tempGroupList(ContactGroupID)
FROM dbo.Addr_TB_ContactGroupMembers A
WHERE A.UserID = @UserID
	AND A.ContactorID = @ContactorID
	AND a.DeleteMark = 0
	AND NOT EXISTS
	(
		SELECT 1
		FROM @tableContactorGroupList B
		WHERE B.ContactGroupID = A.ContactGroupID
	)

--更新组内联系人数量
UPDATE A
SET A.MemberCount = A.MemberCount - (CASE WHEN A.MemberCount > 0 THEN 1 ELSE 0 END)
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN @tempGroupList B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID
End
go



/*
作用：从通讯录的所有联系人中删除多个联系人
作者：lj
参数说明：

修改人：

修改日期：

修改内容：
*/
Create Procedure [dbo].[UP_Addr_Contactor_DelFromAllContactors]
@UserID INT, --用户编号
@ContactorIDList VARCHAR(256),--每次最多删除10个联系人，应在页面上控制，暂不提供删除所有的操作
@Result INT OUTPUT
AS
Declare @ContactorID int
Begin
	SET @Result = 0;

	DECLARE @Temp Table ( ContactorID Int ) --add by wqy begin
	INSERT @Temp ( ContactorID )
	SELECT DISTINCT a From Addr_FN_Split(@ContactorIDList,',');
	IF @@Rowcount=0--认为是异常
	Begin Set @Result = 0;Return 0; End
	--过滤非法数据
	DELETE a
	FROM @Temp a LEFT JOIN Addr_TB_Contactor b 
	ON a.[ContactorID] = b.[ContactorID] AND b.[UserID] = @UserID
	WHERE a.[ContactorID] IS NULL
	
	Declare @TempContactorIDs Table ( ContactorID Int )--保存实际删除的ContactorID
	--1.0 更新联系人主表[Addr_TB_Contactor].[DeleteMark]
	Update a
	Set a.[DeleteMark] = 1,a.LastModifyTime=GETDATE()
	OUTPUT INSERTED.ContactorID
	INTO @TempContactorIDs
	From [Addr_TB_Contactor] a RIGHT JOIN @Temp b
	ON a.[ContactorID] = b.[ContactorID]
	Where a.[UserID] = @UserID And a.[DeleteMark] = 0 AND a.[ContactorID] > 0
	
	IF(NOT EXISTS(SELECT * FROM @TempContactorIDs)) 
	BEGIN Set @Result = 1;RETURN 1; End--如果没有需要删除的，则直接成功退出
	
	DECLARE @TempCGMembers TABLE(ContactGroupID INT,ContactorID INT);	
	
	--2.0 对添加了此联系人的 --他人-- 联系组的影响，更新后保存受影响的联系组数据
	UPDATE a		--Addr_TB_ContactGroupMembers a 
	SET a.[DeleteMark] = 1
	OUTPUT INSERTED.ContactGroupID,INSERTED.ContactorID
	INTO @TempCGMembers
	FROM Addr_TB_ContactGroupMembers a RIGHT JOIN @TempContactorIDs b
	ON a.[ContactorID] = b.[ContactorID]
	WHERE a.[ContactorID] > 0 AND a.DeleteMark = 0--Addr_TB_ContactGroupMembers.DeleteMark=0
	--IF(NOT EXISTS(SELECT * FROM @TempCGMembers)) 
	--BEGIN Set @Result = 1;RETURN 1; END--如果没有受影响的行，则直接成功退出	
	IF(EXISTS(SELECT * FROM @TempCGMembers)) 
	BEGIN
		--2.1 更新每个有关联的联系组的成员数，首先要计算在此次删除操作中，每个联系组的受影响数量
		DECLARE @TempContactorGroupIDs TABLE ( GroupID Int, DelCount Int );--保存组编号及对应的此次要执行删除的联系人数量
		INSERT INTO @TempContactorGroupIDs( GroupID, DelCount ) 
		SELECT [ContactGroupID] AS GroupID, COUNT(0) AS DelCount
		From @TempCGMembers
		GROUP BY [ContactGroupID];
		
		--3.2 更新每个有关联的联系组的成员数
		UPDATE a
		SET a.[MemberCount] = 
			CASE WHEN a.[MemberCount] > b.[DelCount] THEN a.[MemberCount] - b.[DelCount] ELSE 0 END
		FROM [Addr_TB_ContactGroup] a, @TempContactorGroupIDs b
		WHERE a.[ContactGroupID] = b.[GroupID];	
	END
/*
	--3.0 计算每个有关联的群发组所包含的，存在于@ContactorIDList中，并真正在此次操作中被删除的ContactorID数量	
	DECLARE @TempSGMembers TABLE( SendGroupID INT, MemberID INT, ContactorID INT, Property INT);
	UPDATE a
	SET a.[DeleteMark] = 1,a.UpdatedDate=GETDATE()
	OUTPUT INSERTED.SendGroupID, INSERTED.MemberID, INSERTED.ContactorID, INSERTED.Property
	INTO @TempSGMembers
	FROM dbo.Addr_TB_SendGroupMembers a RIGHT JOIN @TempContactorIDs b
	ON a.[ContactorID] = b.[ContactorID]
	WHERE a.[ContactorID] > 0 AND a.DeleteMark = 0--Addr_TB_ContactGroupMembers.DeleteMark=0
	IF(NOT EXISTS(SELECT * FROM @TempSGMembers))
	BEGIN SET @Result = 1; RETURN 1;	END--如果没有受影响的行，则直接成功退出	
	
	DECLARE @TempSGDelCount TABLE ( SendGroupID Int, DelCount Int, JobPhoneCount INT,JobFaxCount INT,MobileCount INT,HomePhoneCount INT);--保存组编号及对应的此次要执行删除的联系人数量
	--3.1 计算每个有关联的群发组所包含的，存在于@ContactorIDList中，并真正在此次操作中被删除的ContactorID数量
	--INSERT INTO @TempSGDelCount( GroupID, DelCount ) 
	INSERT INTO @TempSGDelCount( SendGroupID, DelCount,JobPhoneCount,JobFaxCount,MobileCount,HomePhoneCount ) 
	--SELECT [SendGroupID], COUNT(0) AS DelCount
	SELECT DISTINCT a.[SendGroupID],0,0,0,0,0
	From @TempSGMembers a, dbo.Addr_TB_SendGroup b
	WHERE a.[SendGroupID] = b.[SendGroupID] AND b.[DeleteMark]= 0;
	
	DECLARE @tmpCount INT;SET @tmpCount = 0;
	
	SELECT @tmpCount = COUNT(0)			--无属性号码
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE b.[Property] = 0 AND a.[SendGroupID] = b.[SendGroupID];	
	UPDATE @TempSGDelCount
	SET DelCount = @tmpCount			--无属性号码

	SELECT @tmpCount = COUNT(0)			--办公属性号码
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 1 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET JobPhoneCount = @tmpCount			--办公属性号码

	SELECT @tmpCount = COUNT(0)			--手机属性号码
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 2 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET MobileCount = @tmpCount			--手机属性号码

	SELECT @tmpCount = COUNT(0)			--传真属性号码
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 3 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET JobFaxCount = @tmpCount			--传真属性号码
	
	SELECT @tmpCount = COUNT(0)			--家庭属性号码
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 4 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET HomePhoneCount = @tmpCount			--家庭属性号码

	--3.2 更新每个有关联的群发组的成员数
	--UPDATE a
	--SET a.[MemberCount] = 
	--	CASE WHEN a.[MemberCount] > b.[DelCount] THEN a.[MemberCount] - b.[DelCount] ELSE 0 END
	--FROM [Addr_TB_SendGroup] a, @@TempSGDelCount b
	--WHERE a.[SendGroupID] = b.[GroupID]
	UPDATE a
	SET a.MemberCount = 
		CASE WHEN a.MemberCount > (b.[DelCount]+b.JobPhoneCount+b.JobFaxCount+b.MobileCount+b.HomePhoneCount) 
				THEN a.MemberCount - (b.[DelCount]+b.JobPhoneCount+b.JobFaxCount+b.MobileCount+b.HomePhoneCount)
			ELSE 0 END
		,a.JobPhoneCount = CASE WHEN a.JobPhoneCount > b.JobPhoneCount THEN a.JobPhoneCount - b.JobPhoneCount ELSE 0 END
		,a.JobFaxCount = CASE WHEN a.JobFaxCount > b.JobFaxCount THEN a.JobFaxCount - b.JobFaxCount ELSE 0 END
		,a.MobileCount = CASE WHEN a.MobileCount > b.MobileCount THEN a.MobileCount - b.MobileCount ELSE 0 END
		,a.HomePhoneCount = CASE WHEN a.HomePhoneCount > b.HomePhoneCount THEN a.HomePhoneCount - b.HomePhoneCount ELSE 0 END
	FROM dbo.Addr_TB_SendGroup a, @TempSGDelCount b
	WHERE a.SendGroupID = b.SendGroupID;
*/
	SET @Result = 1;
End
go



/*=============================================================

对象名称: UP_Addr_Contactor_DelFromSingleCGroup
功能描述: 某个终端客户删除某些联系人，从联系人分组中删除，批量操作
测试参数: EXEC UP_Addr_Contactor_DelFromSingleCGroup
创 建 人: lj,2014-07-19
修改记录: 
=============================================================*/
Create Procedure [dbo].[UP_Addr_Contactor_DelFromSingleCGroup]  
@UserID Int, --操作人的用户编号  
@ContactGroupID Int,  
@ContactorIDList Varchar(256)
AS
BEGIN  
	IF (NOT EXISTS(SELECT * FROM dbo.Addr_TB_ContactGroup WHERE UserID = @UserID AND ContactGroupID = @ContactGroupID))  
	BEGIN RETURN -1; END
    
	DECLARE @TempTable table (ContactorID int);  

	Insert @TempTable (ContactorID)  
	Select DISTINCT a   
	From dbo.Addr_FN_Split(@ContactorIDList,',') Where a > 0;  
	IF @@Rowcount = 0 RETURN -2;  

	--更新联系组中联系人删除标记  
	DECLARE @SuccCount INT; Set @SuccCount = 0;  
	UPDATE a  
	SET a.[DeleteMark] = 1  
	FROM [Addr_TB_ContactGroupMembers] a, @TempTable b  
	WHERE a.[UserID] = @UserID AND a.ContactorID = b.[ContactorID] 
	AND a.ContactGroupID = @ContactGroupID AND a.[DeleteMark] = 0;  
	SET @SuccCount = @SuccCount - @@ROWCOUNT;
	IF @SuccCount <> 0  
	Begin--更新联系组中联系人个数  
		Exec UP_Addr_ContactGroup_SetMemberCount @ContactGroupID,@SuccCount;  
	End

	RETURN 1;  
End
go



/*=============================================================

对象名称: UP_Addr_Contactor_GetSingleFullInfo
功能描述: 获取某个联系人的完整信息
测试参数: EXEC UP_Addr_Contactor_GetSingleFullInfo
创 建 人: lj
修改记录: 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_GetSingleFullInfo] 
@ContactorID INT --联系人ID  
AS
Begin 
    SET NOCOUNT ON

--联系人信息
    SELECT  A.[ContactorID] ,
            A.[UserID] ,
            A.[CompID] ,
            A.[Name] ,
            A.[JobPhone] ,
            A.[JobFax] ,
            A.[Mobile] ,
            A.[HomePhone] ,
            A.[Shared] ,
            A.[DeleteMark] ,
            C.[Field] ,
            B.[Sex] ,
            B.[Birthday] ,
            B.[Address] ,
            B.[Company] ,
            B.[Dept] ,
            B.[Business] ,
            B.[Email] ,
            B.[Url] ,
            B.[Remark],
			A.DefaultWayID
    FROM    dbo.Addr_TB_Contactor A WITH ( NOLOCK )
            LEFT JOIN Addr_TB_ContactorDetail B WITH ( NOLOCK ) ON A.ContactorID = B.ContactorID
            LEFT JOIN dbo.Addr_TB_ContactField C WITH ( NOLOCK ) ON A.DefaultWayID = C.SysID
    WHERE   A.ContactorID = @ContactorID	

--联系方式
    SELECT  SysID ,
            ContactorID ,
            UserID ,
            CompID ,
            Field ,
            FieldType
    FROM    dbo.Addr_TB_ContactField WITH ( NOLOCK )
    WHERE   ContactorID = @ContactorID

--所在分组
    SELECT  A.ContactGroupID ,
            A.ContactorID ,
            B.UserID ,
            B.CompID ,
            B.GroupName ,
            B.Shared ,
            B.MemberCount ,
            B.ModifyUserID ,
            B.LastModifyTime ,
            B.CreateTime ,
            B.Remark 
    FROM    dbo.Addr_TB_ContactGroupMembers A WITH ( NOLOCK )
            INNER JOIN dbo.Addr_TB_ContactGroup B WITH ( NOLOCK ) ON A.ContactGroupID = B.ContactGroupID
    WHERE   A.ContactorID = @ContactorID
            AND A.DeleteMark = 0
            AND b.DeleteMark = 0
End
go


/*=============================================================
对象名称: UP_Addr_Contactor_SetName
功能描述: 修改联系人姓名
测试参数: EXEC UP_Addr_Contactor_SetName
创 建 人: 
修改记录: 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_SetName]
    @ContactorID BIGINT ,
    @ContactorName NVARCHAR(20)
AS 
Begin
    SET NOCOUNT ON;
    UPDATE  dbo.Addr_TB_Contactor
    SET     Name = @ContactorName
    WHERE   ContactorID = @ContactorID
End
go

