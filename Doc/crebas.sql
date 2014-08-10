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
   '0.�ǹ���Ա 1.����Ա',
   'user', @CurrentUser, 'table', 'SMS_TB_SM_User', 'column', 'IsAdmin'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0.���� 1.����',
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
   '1 �ֹ�¼��
   2 �ı�����
   3 excel����',
   'user', @CurrentUser, 'table', 'SMS_TB_Send_Bill', 'column', 'InputType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1 ��ʱ
   2 ��ʱ',
   'user', @CurrentUser, 'table', 'SMS_TB_Send_Bill', 'column', 'SendWay'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1 ��ͨ����
   2 ������
   3 ��Ѷ���',
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
    --ʵ��split���� �ĺ���
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
���ã�������ϵ��
���ڣ�2009-03-11
���ߣ�lj
����˵����

�޸��ˣ�

�޸����ڣ�

�޸����ݣ�

*/
Create Procedure [dbo].[UP_Addr_ContactGroup_CreateSingleCGroup]
@UserID Int, --�û����
@CompID INT,
@GroupName NVarchar(50),
@SharedFlag TINYINT,--0 ������ 1 ����
@ContactorGroupID int output,
@Remark nvarchar(1024)
As
Begin
	IF @UserID<=0 OR @GroupName='' RETURN 0;

	--�������ͬ����δɾ�����飬������������һ��ͬ������
	IF(EXISTS(SELECT 1 FROM Addr_TB_ContactGroup WHERE UserID = @UserID AND GroupName = @GroupName AND DELETEMARK =0 ))
		RETURN -1;--do not edit this value
	--����Ǹ����û�(@CompID=0)����Ĭ��Ϊ�ǹ���
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
���ã�ɾ��һ��������ϵ�飬����Addr_SP_ContactGroup_DeleteCGroups�޸�
���ڣ�20140719
���ߣ�
*/
Create Procedure [dbo].[UP_Addr_ContactGroup_DeleteCGroups]
@UserID INT, --�û����
@CompID INT=0,--��ҵ��ţ������û�=0
@ContactGroupIDsList VARCHAR(256),--���10
@Result INT=0 OUTPUT
AS
BEGIN
	Set @Result = 0;
	Declare @TempContactGroupID Table ( ContactGroupID Int ) 
	INSERT @TempContactGroupID (ContactGroupID)
	SELECT distinct a From Addr_FN_Split(@ContactGroupIDsList,',');
	IF(@@Rowcount=0) Return 0;--��Ϊ���쳣
	
	--ɾ���飬��������ϵ������[Addr_TB_ContactGroup].[DeleteMark]�������������(��Ա����Ա������������)������
	Update a
	Set a.[DeleteMark] = 1,a.LastModifyTime=GETDATE()
	FROM [Addr_TB_ContactGroup] a, @TempContactGroupID b
	Where [UserID] = @UserID And CompID = @CompID AND a.[ContactGroupID] = b.[ContactGroupID];

	--ɾ�����Ա
	DELETE A FROM dbo.Addr_TB_ContactGroupMembers A, @TempContactGroupID b
	 WHERE [UserID] = @UserID AND a.[ContactGroupID] = b.[ContactGroupID];

	SET @Result = 1;
	RETURN 1;
END
go


/*
���ã�������ϵ������ϵ�˸���
���ڣ�2014-07-11
���ߣ�lj
����˵����
@ContactGroupID      	���ʶ��  	
@MemberCount      	����1��ʾ����1��������ʾ����1��
�޸��ˣ�

�޸����ڣ�

�޸����ݣ�

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
���ã��༭��ϵ����Ϣ
���ڣ�2014-07-19
���ߣ�lj
����˵����
�޸��ˣ�
�޸����ڣ�
�޸����ݣ�
*/
Create Procedure [dbo].[UP_Addr_ContactGroup_UpdateCGroupInfo]
@UserID Int,						--�û����
@CompID Int,
@GroupName NVarchar(50),	--����
@Remark  Varchar(1024),		--��ע
@Shared       Int,			--�Ƿ���
@ContactGroupID int			--��ϵ��ID
AS
BEGIN
	IF @GroupName = '' RETURN 0;
	--�������ͬ����δɾ�����飬������ʹ��ͬ������
	IF(EXISTS(SELECT 1 FROM Addr_TB_ContactGroup WHERE UserID = @UserID AND GroupName = @GroupName AND DELETEMARK =0 AND ContactGroupID<>@ContactGroupID ))
		RETURN -1;--do not edit this value	
	UPDATE dbo.Addr_TB_ContactGroup 
	SET GroupName=@GroupName,Shared=@Shared,Remark=@Remark,LastModifyTime=GETDATE()
	WHERE UserID=@UserID AND CompID = @CompID AND ContactGroupID=@ContactGroupID;
	
	RETURN 1;
End
go



/*=============================================================
��������: [UP_Addr_ContactorGroupManager_GetCGroupsListPage]
��������: ���շ�ҳ��ʽ��ȡ��ϵ���¼�б�
		= 0 ʱ���ذ������˹����������ϵ��
		= 1 ʱ�����Լ��ǹ������ϵ��
		= 2 ʱ�����Լ��������ϵ��
		= 3 ʱ�������˹������ϵ��
		= 4 ʱ���ز��������˹������ϵ�飨���Լ�����ģ��Լ��ǹ���ģ�
���Բ���: 
�� �� ��: ,2009-03-24
�޸ļ�¼: #1.���ӶԸ����û��Ĵ��� 
		���ص����ݰ���ShareType: 0-���зǹ�����ϵ�� 1-���й�����ϵ�� 2-���˹�����ϵ��
		#2.,2013-07-24,�ع�+�����Ż�
		#3.2014-04-01����ҳ+��������ԭ�洢����Addr_SP_ContactGroup_GetCGroupsListPage_V2
		exec UP_Addr_ContactorGroupManager_GetCGroupsListPage 254941,254940,0,1,100,'1'
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_ContactorGroupManager_GetCGroupsListPage]
	@UserID INT,  
	@CompID INT,--�����û� CompID = 0,���������У�@CompID������ϣ����ڹ��˷Ƿ�����
	@SharedFlag TINYINT,--�����ʶ 0 �C ���еģ�Ĭ�ϣ�1 �C �ǹ�����ϵ��2 �C �Լ�������ϵ��3 �C ���˹�����ϵ�� 4 - ���������˹������ϵ�飨���Լ�����ģ��Լ��ǹ���ģ�  
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
    
    SET @startRowIndex = @PageSize * ( @PageIndex - 1 ) + 1	-- ������ʼ��¼��
    SET @endRowIndex = @PageIndex * @PageSize	-- ���������¼��

SELECT
	@Sql = N'',
	@Where = N'',
	@ShareType = N''
	
IF (@UserID <= 0 OR @CompID < 0)
	RETURN 0;

IF (@SharedFlag NOT IN(0,1,2,3,4))
	RETURN 0;

IF (@CompID = 0)	--�����û�
BEGIN
	IF(@SharedFlag=0 OR @SharedFlag=4)--���ظ����û���������ϵ��Ͳ��������˹������ϵ����һ����
	BEGIN
		SET @Where = ' AND UserID = @UserID'
		SET @ShareType = '
			CASE 
				WHEN [Shared]=0 THEN 0
				WHEN [Shared]=1 THEN 1 
			END'
	END
	ELSE IF(@SharedFlag=1)--�����Լ��ǹ������ϵ��  
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 0'
		SET @ShareType = '0'
	END
	ELSE IF(@SharedFlag=2)--�Լ��������ϵ��
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 1'
		SET @ShareType = '1'
	END    
END
ELSE	--��ҵ�û�
BEGIN
	IF(@SharedFlag=0)--������ҵ�û���������ϵ��
	BEGIN
		SET @Where = ' AND (UserID = @UserID OR [Shared] = 1)'
		SET @ShareType = '
			(CASE
				WHEN UserID = @UserID AND Shared = 0 THEN 0
				WHEN UserID = @UserID AND Shared = 1 THEN 1
				WHEN UserID <> @UserID AND Shared = 1 THEN 2
			END)'
	END
	ELSE IF(@SharedFlag=1)--�����Լ��ǹ������ϵ��  
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 0'
		SET @ShareType = '0'
	END
	ELSE IF(@SharedFlag=2)--�Լ��������ϵ��
	BEGIN
		SET @Where = ' AND UserID = @UserID AND [Shared] = 1'
		SET @ShareType = '1'
	END
	ELSE IF(@SharedFlag=3)--���˹������ϵ��
	BEGIN
		SET @Where = ' AND UserID <> @UserID AND [Shared] = 1'
		SET @ShareType = '2'
	END
	ELSE IF(@SharedFlag=4)--���������˹����������ϵ��
	BEGIN  
		SET @Where = ' AND UserID = @UserID'
		SET @ShareType =' 
			CASE 
				WHEN [Shared] = 0 THEN 0 
				WHEN [Shared] = 1 THEN 1		
			END'
	END
END

 --��������
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

��������: [UP_Addr_ContactorGroupManager_GetContactorsList]
��������: ���շ�ҳ��ʽ��ȡ��ϵ�˼�¼�б�
		����@SharedFlag ������Ҫ���ص�����(���@CompID=0���򲻻������µ����֣�������seqno������ȡ)
		��Է���������ϵ�ˣ�
		= 0 ʱ���ذ������˹������ϵ�ˣ��������˹������ϵ���е���ϵ�˲��������ڣ�
		= 1 ʱ�����Լ��ǹ������ϵ��
		= 2 ʱ�����Լ��������ϵ��
		= 3 ʱ�������˹������ϵ��
		= 4 ʱ���ز��������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�
		= 5 �Լ��Ļ�δ��ӵ���ϵ���е���ϵ��ʽ
		= 6 ���˵Ļ�δ��ӵ���ϵ���е���ϵ��ʽ
		= 7 �������˷ǹ������ϵ��
		= 8 �������˵�������ϵ�ˣ������˹���ĺ����˷ǹ���ģ�
		= 9 ��������δ��ӵ���ϵ���е���ϵ��ʽ

		��Է����Լ���ָ����ϵ���е���ϵ��(������<>0),@SharedFlag��Ч��Ҳ������Ҫ���ص�ǰ���е�����δɾ����ϵ��
		������˹����ָ����ϵ���е���ϵ��(������<>0),@SharedFlag��Ч��Ҳ������Ҫ���ص�ǰ���е�����δɾ����ϵ��

		���Ͼ��д��������������Ͳ�������������������
		���ص����ݰ���ShareType: 
		0-���зǹ�����ϵ��					"�Լ��ķǹ�����ϵ��"
		1-���й�����ϵ��					"�Լ��Ĺ�����ϵ��"
		2-���й�����ϵ��					"���˵Ĺ�����ϵ��"
		5-���зǹ�����ϵ��					"���˵ķǹ�����ϵ��"
���Բ���: EXEC [UP_Addr_ContactorGroupManager_GetContactorsList] 398839, 254940,0,1,500,''
�� �� ��: lj 2014-07-19
�޸ļ�¼: 
		 exec Addr_SP_Tele_Contactor_GetContactorsListPage_New 
=============================================================*/
Create PROC [dbo].[UP_Addr_ContactorGroupManager_GetContactorsList]
	@UserID INT,
	@CompID INT,	--���ڻ�ȡ������ϵ��
	@SharedFlag INT = 0,  --�����ʶ:0�C���е�(Ĭ��),1�C�ǹ����û�,2�C�Լ������û�,3�C���˹����û�,4-���������˹������ϵ��(���Լ������,�Լ��ǹ����)
	@PageIndex INT,
	@PageSize INT,
	@SearchContent VARCHAR(200)
AS
Begin
SET NOCOUNT ON

IF @UserID <= 0
	RETURN 0;

--�����û��������˹������ϵ�ˣ�ʼ�շ���0��
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
    
SET @startRowIndex = @PageSize * (@PageIndex - 1) + 1	-- ������ʼ��¼��
SET @endRowIndex = @PageIndex * @PageSize	-- ���������¼��


SELECT
	@Sql = N'',
	@Where = N''

--������ϵ��ҳ��ʹ�õ���ϵ�˹��������ж�
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
	Addr_VW_InGroupContactors_FullInfo.SeqNoΪ��ϵ�˵������˱�š�
	UserID �� @UserID�Ƿ���ͬ�������˸��û��Ƿ�Ϊ���˹����û�
	CompID���������case����в���Ҫ�ӣ���where�����н��л�ȡ��Ч����ʱ���ж�
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

--��ȡ���ݵ���ʾ��������
/*
���ݹ����Ƿ�����ϵ�� add by hongdi begin
�����ʶ 0 �C ���еģ�Ĭ�ϣ�1 �C �Լ��ǹ����û� 2 �C �Լ������û� 3 �C ���˹����û� 4 - ���������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�
���������ϵ�����е��б�������Ҫ�����������������ų����Լ��ķǹ����û���AND CompID = 1 AND (([Shared]=1 AND UserID <> 1) OR UserID = 1)
�����ϵ���Ա���б�������Ҫ�����������������ų����Լ��ķǹ����û���AND CompID = 1 AND UserID = 1 AND (([Shared]=1 AND UserID <> COwnerUserID) OR UserID = COwnerUserID)
�����ϵ���Ա�������ֻ��UserID=COwnerUserID����������ϵ��
*/
IF @SharedFlag = 0
BEGIN		
	--������ϵ��,ֻ������CompID��UserID
	IF(@CompID = 0) --�����û�������ϵ��
		SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID)
	ELSE --��ҵ�û�������ϵ��
		SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND (([Shared]=1 AND UserID <> '+Cast(@UserID As Varchar)+') OR UserID = '+Cast(@UserID As Varchar)+')'
END  
ELSE IF @SharedFlag = 1 --�Լ��ǹ����û�
BEGIN	
	--������ϵ�������ڲ������Լ��ķǹ�����
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 0'
END
ELSE IF @SharedFlag = 2 --�Լ������û�(���ˣ���ҵͬ)
BEGIN	
	--������ϵ�������ڲ������Լ��Ĺ�����
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 1'
END
ELSE IF @SharedFlag = 3 --���˹����û�(���ڸ����û���������Ч������ڴ����������)
BEGIN
	--��ʾ���˹������ϵ�˵�����ΪUserID <> @UserID And CompID = @CompID
	--��ʾ���˹������ϵ�˵�����ΪUserID <> COwnerUserID And UserID = @UserID
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID <> ' + RTRIM(@UserID) + ' AND Shared = 1'
END
ELSE IF @SharedFlag = 4 --���������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�(���ˣ���ҵͬ)
BEGIN
	SET @Where = ' AND CompID = ' + RTRIM(@CompID)+' AND UserID = ' + RTRIM(@UserID) 
END

--��������
 IF @SearchContent <> '' 
 Set @Where = @Where + 'And (Name like ''%' + @SearchContent +'%'' OR Field like ''%' + @SearchContent +'%'')'
 
--��������ϵ���л�ȡ
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

��������: UP_Addr_ContactorGroupManager_GetUnGroupedContactors
��������: ��ȡδ������ϵ��
		����@SharedFlag ������Ҫ���ص�����(���@CompID=0���򲻻������µ����֣�������UserID������ȡ)
		��Է���������ϵ�ˣ�
		= 0 ʱ���ذ������˹������ϵ�ˣ��������˹������ϵ���е���ϵ�˲��������ڣ�
		= 1 ʱ�����Լ��ǹ������ϵ��
		= 2 ʱ�����Լ��������ϵ��
		= 3 ʱ�������˹������ϵ��
		= 4 ʱ���ز��������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�
		= 5 �Լ��Ļ�δ��ӵ���ϵ���е���ϵ��ʽ
		= 6 ���˵Ļ�δ��ӵ���ϵ���е���ϵ��ʽ
		= 7 �������˷ǹ������ϵ��
		= 8 �������˵�������ϵ�ˣ������˹���ĺ����˷ǹ���ģ�
		= 9 ��������δ��ӵ���ϵ���е���ϵ��ʽ

		��Է����Լ���ָ����ϵ���е���ϵ��(������<>0),@SharedFlag��Ч��Ҳ������Ҫ���ص�ǰ���е�����δɾ����ϵ��
		������˹����ָ����ϵ���е���ϵ��(������<>0),@SharedFlag��Ч��Ҳ������Ҫ���ص�ǰ���е�����δɾ����ϵ��

		���Ͼ��д��������������Ͳ�������������������
		���ص����ݰ���ShareType: 
		0-���зǹ�����ϵ��					"�Լ��ķǹ�����ϵ��"
		1-���й�����ϵ��					"�Լ��Ĺ�����ϵ��"
		2-���й�����ϵ��					"���˵Ĺ�����ϵ��"
		5-���зǹ�����ϵ��					"���˵ķǹ�����ϵ��"
���Բ���: EXEC UP_Addr_ContactorGroupManager_GetUnGroupedContactors 267553, 267552,0,1,100,''
�� �� ��: lj 2014-07-6
		����Addr_SP_Tele_Contactor_GetContactorsList�޸�
=============================================================*/
Create PROC [dbo].[UP_Addr_ContactorGroupManager_GetUnGroupedContactors]
    @UserID INT ,
    @CompID INT ,	--���ڻ�ȡ������ϵ��
    @SharedFlag INT = 0 ,  --�����ʶ:0�C���е�(Ĭ��),1�C�ǹ����û�,2�C�Լ������û�,3�C���˹����û�,4-���������˹������ϵ��(���Լ������,�Լ��ǹ����)
    @PageIndex INT ,
    @PageSize INT ,
    @SearchContent VARCHAR(200)
AS
Begin
    SET NOCOUNT ON

    IF @UserID <= 0 
        RETURN 0;

--�����û��������˹������ϵ�ˣ�ʼ�շ���0��
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
    
    SET @startRowIndex = @PageSize * ( @PageIndex - 1 ) + 1	-- ������ʼ��¼��
    SET @endRowIndex = @PageIndex * @PageSize	-- ���������¼��

    SELECT  @Sql = N'' ,
            @Where = N''

--������ϵ��ҳ��ʹ�õ���ϵ�˹��������ж�
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
	Addr_VW_InGroupContactors_FullInfo.UserIDΪ��ϵ�˵������˱�š�
	UserID �� @UserID�Ƿ���ͬ�������˸��û��Ƿ�Ϊ���˹����û�
	CompID���������case����в���Ҫ�ӣ���where�����н��л�ȡ��Ч����ʱ���ж�
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

--��ȡ���ݵ���ʾ��������
/*
���ݹ����Ƿ�����ϵ�� add by hongdi begin
�����ʶ 0 �C ���еģ�Ĭ�ϣ�1 �C �Լ��ǹ����û� 2 �C �Լ������û� 3 �C ���˹����û� 4 - ���������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�
���������ϵ�����е��б�������Ҫ�����������������ų����Լ��ķǹ����û���AND CompID = 1 AND (([Shared]=1 AND UserID <> 1) OR UserID = 1)
�����ϵ���Ա���б�������Ҫ�����������������ų����Լ��ķǹ����û���AND CompID = 1 AND UserID = 1 AND (([Shared]=1 AND UserID <> COwnerUserID) OR UserID = COwnerUserID)
�����ϵ���Ա�������ֻ��UserID=COwnerUserID����������ϵ��
*/
    IF @SharedFlag = 0 
        BEGIN		
	--������ϵ��,ֻ������CompID��UserID
            IF ( @CompID = 0 ) --�����û�������ϵ��
                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                    + ' AND A.UserID = ' + RTRIM(@UserID)
            ELSE --��ҵ�û�������ϵ��
                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                    + ' AND (A.UserID = ' + RTRIM(@UserID) + ' OR Shared = 1)'
        END  
    ELSE 
        IF @SharedFlag = 1 --�Լ��ǹ����û�
            BEGIN	
	--������ϵ�������ڲ������Լ��ķǹ�����
                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                    + ' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 0'
            END
        ELSE 
            IF @SharedFlag = 2 --�Լ������û�(���ˣ���ҵͬ)
                BEGIN	
	--������ϵ�������ڲ������Լ��Ĺ�����
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 1'
                END
            ELSE 
                IF @SharedFlag = 3 --���˹����û�(���ڸ����û���������Ч������ڴ����������)
                    BEGIN
	--��ʾ���˹������ϵ�˵�����ΪUserID <> @UserID And CompID = @CompID
	--��ʾ���˹������ϵ�˵�����ΪUserID <> COwnerUserID And UserID = @UserID
                        SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                            + ' AND UserID <>' + RTRIM(@UserID)
                            + ' AND Shared = 1'
                    END
                ELSE 
                    IF @SharedFlag = 4 --���������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�(���ˣ���ҵͬ)
                        BEGIN
                            SET @Where = ' AND CompID =' + RTRIM(@CompID)
                                + 'AND UserID = ' + RTRIM(@UserID)
                        END
 
 --��������
 IF @SearchContent <> '' 
 Set @Where = @Where + 'And (Name like ''%' + @SearchContent +'%'' OR Field like ''%' + @SearchContent +'%'')'

--��������ϵ���л�ȡ
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
��������: UP_Addr_ContactorGroupManager_GetUserContactorsCount
��������: ���շ�ҳ��ʽ��ȡ��ϵ�˼�¼�б�
���Բ���: EXEC UP_Addr_ContactorGroupManager_GetUserContactorsCount 254941, 254940,0,0,'',0
�� �� ��: lj 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_ContactorGroupManager_GetUserContactorsCount]
    @UserID INT ,
    @CompID INT ,	--���ڻ�ȡ������ϵ��
    @SharedFlag INT = 0 ,  --�����ʶ:0�C���е�(Ĭ��)
    @GroupID INT , --0-ȫ��  -2-δ����
    @SearchContent VARCHAR(200),
	@Count INT OUTPUT
AS 
    BEGIN
        SET NOCOUNT ON;

        IF @UserID <= 0 
            RETURN 0;

--�����û��������˹������ϵ�ˣ�ʼ�շ���0��
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
	--������ϵ��,ֻ������CompID��UserID
                IF ( @CompID = 0 ) --�����û�������ϵ��
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND UserID = ' + RTRIM(@UserID)
                ELSE --��ҵ�û�������ϵ��
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND (([Shared]=1 AND UserID <> '
                        + CAST(@UserID AS VARCHAR) + ') OR UserID = '
                        + CAST(@UserID AS VARCHAR) + ')'
            END  
        ELSE 
            IF @SharedFlag = 1 --�Լ��ǹ����û�
                BEGIN	
	--������ϵ�������ڲ������Լ��ķǹ�����
                    SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                        + ' AND UserID = ' + RTRIM(@UserID) + ' AND Shared = 0'
                END
            ELSE 
                IF @SharedFlag = 2 --�Լ������û�(���ˣ���ҵͬ)
                    BEGIN	
	--������ϵ�������ڲ������Լ��Ĺ�����
                        SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                            + ' AND UserID = ' + RTRIM(@UserID)
                            + ' AND Shared = 1'
                    END
                ELSE 
                    IF @SharedFlag = 3 --���˹����û�(���ڸ����û���������Ч������ڴ����������)
                        BEGIN
	--��ʾ���˹������ϵ�˵�����ΪUserID <> @UserID And CompID = @CompID
	--��ʾ���˹������ϵ�˵�����ΪUserID <> COwnerUserID And UserID = @UserID
                            SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                                + ' AND UserID <> ' + RTRIM(@UserID)
                                + ' AND Shared = 1'
                        END
                    ELSE 
                        IF @SharedFlag = 4 --���������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�(���ˣ���ҵͬ)
                            BEGIN
                                SET @Where = ' AND CompID = ' + RTRIM(@CompID)
                                    + ' AND UserID = ' + RTRIM(@UserID) 
                            END

--��������
        IF @SearchContent <> '' 
            SET @Where = @Where + 'And Name like ''%' + @SearchContent + '%'''
 
 --����
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

��������: UP_Addr_ContactorGroupManager_GetUserGroupContactors
��������: ���շ�ҳ��ʽ��ȡ��ϵ�˼�¼�б�
		����@SharedFlag ������Ҫ���ص�����(���@CompID=0���򲻻������µ����֣�������UserID������ȡ)
		��Է���������ϵ�ˣ�
		= 0 ʱ���ذ������˹������ϵ�ˣ��������˹������ϵ���е���ϵ�˲��������ڣ�
		= 1 ʱ�����Լ��ǹ������ϵ��
		= 2 ʱ�����Լ��������ϵ��
		= 3 ʱ�������˹������ϵ��
		= 4 ʱ���ز��������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�
		= 5 �Լ��Ļ�δ��ӵ���ϵ���е���ϵ��ʽ
		= 6 ���˵Ļ�δ��ӵ���ϵ���е���ϵ��ʽ
		= 7 �������˷ǹ������ϵ��
		= 8 �������˵�������ϵ�ˣ������˹���ĺ����˷ǹ���ģ�
		= 9 ��������δ��ӵ���ϵ���е���ϵ��ʽ

		��Է����Լ���ָ����ϵ���е���ϵ��(������<>0),@SharedFlag��Ч��Ҳ������Ҫ���ص�ǰ���е�����δɾ����ϵ��
		������˹����ָ����ϵ���е���ϵ��(������<>0),@SharedFlag��Ч��Ҳ������Ҫ���ص�ǰ���е�����δɾ����ϵ��

		���Ͼ��д��������������Ͳ�������������������
		���ص����ݰ���ShareType: 
		0-���зǹ�����ϵ��					"�Լ��ķǹ�����ϵ��"
		1-���й�����ϵ��					"�Լ��Ĺ�����ϵ��"
		2-���й�����ϵ��					"���˵Ĺ�����ϵ��"
		5-���зǹ�����ϵ��					"���˵ķǹ�����ϵ��"
���Բ���: EXEC UP_Addr_ContactorGroupManager_GetUserGroupContactors 267553, 267552,6680,0,1,100,''
�� �� ��: ���� 2014-1-3 
		����Addr_SP_Tele_Contactor_GetContactorsList�޸�		
=============================================================*/
Create PROC [dbo].[UP_Addr_ContactorGroupManager_GetUserGroupContactors]
	@UserID INT,
	@CompID INT,	--���ڻ�ȡ������ϵ��
	@GroupID INT,   --��ID 
	@SharedFlag INT = 0,  --�����ʶ:0�C���е�(Ĭ��),1�C�ǹ����û�,2�C�Լ������û�,3�C���˹����û�,4-���������˹������ϵ��(���Լ������,�Լ��ǹ����)
	@PageIndex INT,
	@PageSize INT,
	@SearchContent VARCHAR(200)
AS
Begin
SET NOCOUNT ON

IF @UserID <= 0
	RETURN 0;

--�����û��������˹������ϵ�ˣ�ʼ�շ���0��
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
    
SET @startRowIndex = @PageSize * (@PageIndex - 1) + 1	-- ������ʼ��¼��
SET @endRowIndex = @PageIndex * @PageSize	-- ���������¼��

SELECT
	@Sql = N'',
	@Where = N''

--������ϵ��ҳ��ʹ�õ���ϵ�˹��������ж�
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
	Addr_VW_InGroupContactors_FullInfo.UserIDΪ��ϵ�˵������˱�š�
	UserID �� @UserID�Ƿ���ͬ�������˸��û��Ƿ�Ϊ���˹����û�
	CompID���������case����в���Ҫ�ӣ���where�����н��л�ȡ��Ч����ʱ���ж�
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

--��ȡ���ݵ���ʾ��������
/*
���ݹ����Ƿ�����ϵ�� add by hongdi begin
�����ʶ 0 �C ���еģ�Ĭ�ϣ�1 �C �Լ��ǹ����û� 2 �C �Լ������û� 3 �C ���˹����û� 4 - ���������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�
���������ϵ�����е��б�������Ҫ�����������������ų����Լ��ķǹ����û���AND CompID = 1 AND (([Shared]=1 AND UserID <> 1) OR UserID = 1)
�����ϵ���Ա���б�������Ҫ�����������������ų����Լ��ķǹ����û���AND CompID = 1 AND UserID = 1 AND (([Shared]=1 AND UserID <> COwnerUserID) OR UserID = COwnerUserID)
�����ϵ���Ա�������ֻ��UserID=COwnerUserID����������ϵ��
*/
IF @SharedFlag = 0
BEGIN		
	--������ϵ��,ֻ������CompID��UserID
	IF(@CompID = 0) --�����û�������ϵ��
		SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND A.UserID = '+RTRIM(@UserID)
	ELSE --��ҵ�û�������ϵ��
		SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND (([Shared]=1 AND UserID <> '+Cast(@UserID As Varchar)+') OR UserID = '+Cast(@UserID As Varchar)+')'
END  
ELSE IF @SharedFlag = 1 --�Լ��ǹ����û�
BEGIN	
	--������ϵ�������ڲ������Լ��ķǹ�����
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID = '+RTRIM(@UserID)+' AND Shared = 0'
END
ELSE IF @SharedFlag = 2 --�Լ������û�(���ˣ���ҵͬ)
BEGIN	
	--������ϵ�������ڲ������Լ��Ĺ�����
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID = '+RTRIM(@UserID)+' AND Shared = 1'
END
ELSE IF @SharedFlag = 3 --���˹����û�(���ڸ����û���������Ч������ڴ����������)
BEGIN
	--��ʾ���˹������ϵ�˵�����ΪUserID <> @UserID And CompID = @CompID
	--��ʾ���˹������ϵ�˵�����ΪUserID <> COwnerUserID And UserID = @UserID
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID <> '+RTRIM(@UserID)+' AND Shared = 1'
END
ELSE IF @SharedFlag = 4 --���������˹������ϵ�ˣ����Լ�����ģ��Լ��ǹ���ģ�(���ˣ���ҵͬ)
BEGIN
	SET @Where = ' AND CompID = '+RTRIM(@CompID)+' AND UserID = '+RTRIM(@UserID)+''
END
 
 --��������
 IF @SearchContent <> '' 
 Set @Where = @Where +  'And (Name like ''%' + @SearchContent +'%'' OR Field like ''%' + @SearchContent +'%'')'
 
--����
IF @GroupID > 0
Set @Where = @Where + ' AND ContactGroupID = ' + RTRIM(@GroupID)
			
--��������ϵ���л�ȡ
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

��������: UP_Addr_Contactor_SetMutilField
��������: ���������ϵ����ϵ��ʽ
���Բ���: EXEC UP_Addr_Contactor_SetMutilField
�� �� ��: lj,2014-07-19
�޸ļ�¼: 
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

	--���²λ����
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

��������: UP_Addr_Contactor_AddContactor
��������: �����ϵ����Ϣ
���Բ���: EXEC UP_Addr_Contactor_AddContactor
�� �� ��: lj 2014-07-19
�޸ļ�¼: 
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

--�����ϵ�˻�����Ϣ
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

--�����ϵ����ϸ��Ϣ
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

--�����ϵ�˷���
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

--������memberCount
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


--�����ϵ����ϵ��ʽ
EXEC UP_Addr_Contactor_SetMutilField
	@UserID,
	@CompID,
	@contactorId,
    @ContactWay,
	@ConfParticipatePhoneNo
 End
go



/*=============================================================
��������: Addr_SP_Contactor_AddMultiContactorToMultiGroup
��������: �������ϵ�����,ɾ�����ƶ����������
���Բ���: EXEC Addr_SP_Contactor_AddMultiContactorToMultiGroup 
�� �� ��: 
�޸ļ�¼: 
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

--ֻ�ܲ����Լ����˻�ͬһCompID�¹������(Shared=1)
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

--�����ϵ����Ч,�򷵻�
IF NOT EXISTS
(
	SELECT 1
	FROM @tableContactorList
)
BEGIN
	RETURN -2
END

--ֻ�ܲ����Լ���(SeqNo)��
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

--#1.1�����ϵ�˵��Լ��ķ���(�����¼�Ѿ�����,��ָ�ɾ�����)
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

--����������ϵ������
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

--#1.2�����ϵ�˵��Լ��ķ���(�����¼������,�����)
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

--����������ϵ������
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

--#2.���Լ��ķ�����ɾ����ϵ��
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

--����������ϵ������
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
��������: UP_Addr_Contactor_AddMutilField
��������: ���������ϵ����ϵ��ʽ
���Բ���: EXEC UP_Addr_Contactor_AddMutilField
�� �� ��: lj
�޸ļ�¼: 
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

	--���²λ����
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
��������: UP_Addr_Contactor_AddSingleToCGroups
��������: ��������ϵ�˼�����˳������
���Բ���: EXEC UP_Addr_Contactor_AddSingleToCGroups 94,93,1,'<ContactGroup><Group><GroupID>1</GroupID></Group></ContactGroup>'
�� �� ��: ���,2009-03-11
�޸ļ�¼: #1.2009-04-18,����������˳����߼�:��ϵ������ǲ����˱�������
		 #22013-12-09,�ع��߼�
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_AddSingleToCGroups]
	@UserID INT, --�û����
	@CompID INT, --��ҵ���
	@ContactorID INT, --��ϵ��ID
	@ContactorGroupIDList XML	--���б�
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

--��ϵ�˱����Ǳ�SeqNo��,����ͬһ����˾������SeqNo���������.
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

--ֻ������SeqNo�����ķ���
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

--#1.1�����ϵ�˵��Լ��ķ���(�����¼�Ѿ�����,��ָ�ɾ�����)
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

--����������ϵ������
UPDATE A
SET A.MemberCount = A.MemberCount + 1
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN @tempGroupList B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#1.2�����ϵ�˵��Լ��ķ���(�����¼������,�����)
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

--����������ϵ������
UPDATE A
SET A.MemberCount = A.MemberCount + 1
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN @tempGroupList B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID

--#2.���Լ��ķ�����ɾ����ϵ��
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

--����������ϵ������
UPDATE A
SET A.MemberCount = A.MemberCount - (CASE WHEN A.MemberCount > 0 THEN 1 ELSE 0 END)
FROM dbo.Addr_TB_ContactGroup A
	INNER JOIN @tempGroupList B
		ON A.ContactGroupID = B.ContactGroupID
WHERE A.UserID = @UserID
End
go



/*
���ã���ͨѶ¼��������ϵ����ɾ�������ϵ��
���ߣ�lj
����˵����

�޸��ˣ�

�޸����ڣ�

�޸����ݣ�
*/
Create Procedure [dbo].[UP_Addr_Contactor_DelFromAllContactors]
@UserID INT, --�û����
@ContactorIDList VARCHAR(256),--ÿ�����ɾ��10����ϵ�ˣ�Ӧ��ҳ���Ͽ��ƣ��ݲ��ṩɾ�����еĲ���
@Result INT OUTPUT
AS
Declare @ContactorID int
Begin
	SET @Result = 0;

	DECLARE @Temp Table ( ContactorID Int ) --add by wqy begin
	INSERT @Temp ( ContactorID )
	SELECT DISTINCT a From Addr_FN_Split(@ContactorIDList,',');
	IF @@Rowcount=0--��Ϊ���쳣
	Begin Set @Result = 0;Return 0; End
	--���˷Ƿ�����
	DELETE a
	FROM @Temp a LEFT JOIN Addr_TB_Contactor b 
	ON a.[ContactorID] = b.[ContactorID] AND b.[UserID] = @UserID
	WHERE a.[ContactorID] IS NULL
	
	Declare @TempContactorIDs Table ( ContactorID Int )--����ʵ��ɾ����ContactorID
	--1.0 ������ϵ������[Addr_TB_Contactor].[DeleteMark]
	Update a
	Set a.[DeleteMark] = 1,a.LastModifyTime=GETDATE()
	OUTPUT INSERTED.ContactorID
	INTO @TempContactorIDs
	From [Addr_TB_Contactor] a RIGHT JOIN @Temp b
	ON a.[ContactorID] = b.[ContactorID]
	Where a.[UserID] = @UserID And a.[DeleteMark] = 0 AND a.[ContactorID] > 0
	
	IF(NOT EXISTS(SELECT * FROM @TempContactorIDs)) 
	BEGIN Set @Result = 1;RETURN 1; End--���û����Ҫɾ���ģ���ֱ�ӳɹ��˳�
	
	DECLARE @TempCGMembers TABLE(ContactGroupID INT,ContactorID INT);	
	
	--2.0 ������˴���ϵ�˵� --����-- ��ϵ���Ӱ�죬���º󱣴���Ӱ�����ϵ������
	UPDATE a		--Addr_TB_ContactGroupMembers a 
	SET a.[DeleteMark] = 1
	OUTPUT INSERTED.ContactGroupID,INSERTED.ContactorID
	INTO @TempCGMembers
	FROM Addr_TB_ContactGroupMembers a RIGHT JOIN @TempContactorIDs b
	ON a.[ContactorID] = b.[ContactorID]
	WHERE a.[ContactorID] > 0 AND a.DeleteMark = 0--Addr_TB_ContactGroupMembers.DeleteMark=0
	--IF(NOT EXISTS(SELECT * FROM @TempCGMembers)) 
	--BEGIN Set @Result = 1;RETURN 1; END--���û����Ӱ����У���ֱ�ӳɹ��˳�	
	IF(EXISTS(SELECT * FROM @TempCGMembers)) 
	BEGIN
		--2.1 ����ÿ���й�������ϵ��ĳ�Ա��������Ҫ�����ڴ˴�ɾ�������У�ÿ����ϵ�����Ӱ������
		DECLARE @TempContactorGroupIDs TABLE ( GroupID Int, DelCount Int );--�������ż���Ӧ�Ĵ˴�Ҫִ��ɾ������ϵ������
		INSERT INTO @TempContactorGroupIDs( GroupID, DelCount ) 
		SELECT [ContactGroupID] AS GroupID, COUNT(0) AS DelCount
		From @TempCGMembers
		GROUP BY [ContactGroupID];
		
		--3.2 ����ÿ���й�������ϵ��ĳ�Ա��
		UPDATE a
		SET a.[MemberCount] = 
			CASE WHEN a.[MemberCount] > b.[DelCount] THEN a.[MemberCount] - b.[DelCount] ELSE 0 END
		FROM [Addr_TB_ContactGroup] a, @TempContactorGroupIDs b
		WHERE a.[ContactGroupID] = b.[GroupID];	
	END
/*
	--3.0 ����ÿ���й�����Ⱥ�����������ģ�������@ContactorIDList�У��������ڴ˴β����б�ɾ����ContactorID����	
	DECLARE @TempSGMembers TABLE( SendGroupID INT, MemberID INT, ContactorID INT, Property INT);
	UPDATE a
	SET a.[DeleteMark] = 1,a.UpdatedDate=GETDATE()
	OUTPUT INSERTED.SendGroupID, INSERTED.MemberID, INSERTED.ContactorID, INSERTED.Property
	INTO @TempSGMembers
	FROM dbo.Addr_TB_SendGroupMembers a RIGHT JOIN @TempContactorIDs b
	ON a.[ContactorID] = b.[ContactorID]
	WHERE a.[ContactorID] > 0 AND a.DeleteMark = 0--Addr_TB_ContactGroupMembers.DeleteMark=0
	IF(NOT EXISTS(SELECT * FROM @TempSGMembers))
	BEGIN SET @Result = 1; RETURN 1;	END--���û����Ӱ����У���ֱ�ӳɹ��˳�	
	
	DECLARE @TempSGDelCount TABLE ( SendGroupID Int, DelCount Int, JobPhoneCount INT,JobFaxCount INT,MobileCount INT,HomePhoneCount INT);--�������ż���Ӧ�Ĵ˴�Ҫִ��ɾ������ϵ������
	--3.1 ����ÿ���й�����Ⱥ�����������ģ�������@ContactorIDList�У��������ڴ˴β����б�ɾ����ContactorID����
	--INSERT INTO @TempSGDelCount( GroupID, DelCount ) 
	INSERT INTO @TempSGDelCount( SendGroupID, DelCount,JobPhoneCount,JobFaxCount,MobileCount,HomePhoneCount ) 
	--SELECT [SendGroupID], COUNT(0) AS DelCount
	SELECT DISTINCT a.[SendGroupID],0,0,0,0,0
	From @TempSGMembers a, dbo.Addr_TB_SendGroup b
	WHERE a.[SendGroupID] = b.[SendGroupID] AND b.[DeleteMark]= 0;
	
	DECLARE @tmpCount INT;SET @tmpCount = 0;
	
	SELECT @tmpCount = COUNT(0)			--�����Ժ���
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE b.[Property] = 0 AND a.[SendGroupID] = b.[SendGroupID];	
	UPDATE @TempSGDelCount
	SET DelCount = @tmpCount			--�����Ժ���

	SELECT @tmpCount = COUNT(0)			--�칫���Ժ���
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 1 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET JobPhoneCount = @tmpCount			--�칫���Ժ���

	SELECT @tmpCount = COUNT(0)			--�ֻ����Ժ���
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 2 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET MobileCount = @tmpCount			--�ֻ����Ժ���

	SELECT @tmpCount = COUNT(0)			--�������Ժ���
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 3 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET JobFaxCount = @tmpCount			--�������Ժ���
	
	SELECT @tmpCount = COUNT(0)			--��ͥ���Ժ���
	FROM @TempSGDelCount a, @TempSGMembers b
	WHERE [Property] = 4 AND a.[SendGroupID] = b.[SendGroupID];		
	UPDATE @TempSGDelCount
	SET HomePhoneCount = @tmpCount			--��ͥ���Ժ���

	--3.2 ����ÿ���й�����Ⱥ����ĳ�Ա��
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

��������: UP_Addr_Contactor_DelFromSingleCGroup
��������: ĳ���ն˿ͻ�ɾ��ĳЩ��ϵ�ˣ�����ϵ�˷�����ɾ������������
���Բ���: EXEC UP_Addr_Contactor_DelFromSingleCGroup
�� �� ��: lj,2014-07-19
�޸ļ�¼: 
=============================================================*/
Create Procedure [dbo].[UP_Addr_Contactor_DelFromSingleCGroup]  
@UserID Int, --�����˵��û����  
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

	--������ϵ������ϵ��ɾ�����  
	DECLARE @SuccCount INT; Set @SuccCount = 0;  
	UPDATE a  
	SET a.[DeleteMark] = 1  
	FROM [Addr_TB_ContactGroupMembers] a, @TempTable b  
	WHERE a.[UserID] = @UserID AND a.ContactorID = b.[ContactorID] 
	AND a.ContactGroupID = @ContactGroupID AND a.[DeleteMark] = 0;  
	SET @SuccCount = @SuccCount - @@ROWCOUNT;
	IF @SuccCount <> 0  
	Begin--������ϵ������ϵ�˸���  
		Exec UP_Addr_ContactGroup_SetMemberCount @ContactGroupID,@SuccCount;  
	End

	RETURN 1;  
End
go



/*=============================================================

��������: UP_Addr_Contactor_GetSingleFullInfo
��������: ��ȡĳ����ϵ�˵�������Ϣ
���Բ���: EXEC UP_Addr_Contactor_GetSingleFullInfo
�� �� ��: lj
�޸ļ�¼: 
=============================================================*/
Create PROCEDURE [dbo].[UP_Addr_Contactor_GetSingleFullInfo] 
@ContactorID INT --��ϵ��ID  
AS
Begin 
    SET NOCOUNT ON

--��ϵ����Ϣ
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

--��ϵ��ʽ
    SELECT  SysID ,
            ContactorID ,
            UserID ,
            CompID ,
            Field ,
            FieldType
    FROM    dbo.Addr_TB_ContactField WITH ( NOLOCK )
    WHERE   ContactorID = @ContactorID

--���ڷ���
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
��������: UP_Addr_Contactor_SetName
��������: �޸���ϵ������
���Բ���: EXEC UP_Addr_Contactor_SetName
�� �� ��: 
�޸ļ�¼: 
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

