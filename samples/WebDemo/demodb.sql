/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2018-04-11 11:21:24                          */
/*==============================================================*/


drop procedure if exists p_demo_get_user_course;

drop table if exists admin_gen_addedit;

drop table if exists admin_gen_query;

drop table if exists admin_group;

drop table if exists admin_group_privilege;

drop table if exists admin_menu;

drop table if exists admin_privilege;

drop table if exists admin_user;

drop table if exists admin_user_group;

drop table if exists admin_user_privilege;

drop table if exists demo_user_course;

drop table if exists demo_class;

drop table if exists demo_course;

drop table if exists demo_user;

drop table if exists sys_china_area;

drop table if exists sys_log;

/*==============================================================*/
/* Table: admin_gen_addedit                                     */
/*==============================================================*/
create table admin_gen_addedit
(
   AddEditID            bigint not null auto_increment  comment '����',
   ConnStrName          varchar(50)  comment '������������',
   ServerName           varchar(50) not null  comment '������',
   DatabaseName         varchar(50) not null  comment '���ݿ�����',
   TableName            varchar(50) not null  comment '���ݿ������',
   Title                varchar(100)  comment 'ҳ�����',
   Width                varchar(20)  comment '������',
   Height               varchar(20)  comment '����߶�',
   GenPath              varchar(255)  comment '���ɱ���·��',
   Note                 varchar(255)  comment '����',
   TableSchema          blob  comment '���Schema����',
   ColumnsData          blob  comment '���л���������',
   Status               tinyint not null default 0  comment '״̬ 0-��ʼ 1-��Ч 2-��Ч',
   RecDate              datetime not null default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  comment '��¼����',
   primary key (AddEditID)
);

alter table admin_gen_addedit comment '����޸�ģ��';

/*==============================================================*/
/* Index: index_1                                               */
/*==============================================================*/
create unique index index_1 on admin_gen_addedit
(
   ServerName,
   DatabaseName,
   TableName
);

/*==============================================================*/
/* Table: admin_gen_query                                       */
/*==============================================================*/
create table admin_gen_query
(
   QueryID              bigint not null auto_increment  comment '��ѯģ������',
   ConnStrName          varchar(50)  comment '������������',
   ServerName           varchar(50) not null  comment '������',
   DatabaseName         varchar(50) not null  comment '���ݿ�����',
   `Sql`                text  comment 'SQL���',
   Title                varchar(100)  comment 'ҳ�����',
   HasAdd               bool not null default 1  comment '�Ƿ������',
   HasEdit              bool not null default 1  comment '�Ƿ��б༭',
   HasView              bool not null default 0  comment '�Ƿ��в鿴',
   HasDelete            bool not null default 1  comment '�Ƿ���ɾ��',
   AddEditID            bigint  comment '��ӱ༭����ģ�����',
   TableName            varchar(100)  comment 'Ŀ�����',
   PrimaryKey           blob  comment 'Ŀ�������',
   PageSize             int not null  comment 'ҳ��С',
   QueryItems           blob  comment '��ѯ�ؼ���������',
   GridColumns          blob  comment 'GUID����������',
   Note                 varchar(255)  comment '����',
   GenPath              varchar(255)  comment '���ɱ���·��',
   Status               tinyint not null default 0  comment '״̬ 0-��ʼ 1-��Ч 2-��Ч',
   RecDate              datetime not null default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  comment '��¼����',
   primary key (QueryID)
);

alter table admin_gen_query comment '��ѯģ��';

/*==============================================================*/
/* Table: admin_group                                           */
/*==============================================================*/
create table admin_group
(
   GroupID              bigint not null auto_increment  comment '�û���ID',
   GroupName            varchar(20)  comment '������',
   Status               tinyint not null default 0  comment '״̬ 0-��Ч 1-��Ч',
   RecDate              datetime not null default CURRENT_TIMESTAMP  comment '��¼����',
   primary key (GroupID)
);

alter table admin_group comment '�û���';

/*==============================================================*/
/* Table: admin_group_privilege                                 */
/*==============================================================*/
create table admin_group_privilege
(
   GroupID              bigint not null  comment '�û���ID',
   PrivilegeID          bigint not null  comment 'Ȩ��ID',
   PrivParamsValue      varchar(250)  comment '���ܺ�����Ȩ�޲�����
             ����-����-�Ƿ���Ȩ��| ����-����-�Ƿ���Ȩ��
             �磺ControlID-btnOk-true|ControlID-btnCancle-false
             
             ',
   MapUserID            varchar(20)  comment 'ӳ��ĵ�����ƽ̨�û�����
             ��ҳ���Ѵ�������һ������ƽ̨�У��Ѵ����û�����Ȩ�޵�����¡�
             ͨ��URL�������ݣ�������ƽ̨��Ҫֱ�����Ŵ��û�',
   primary key (GroupID, PrivilegeID)
);

alter table admin_group_privilege comment '�û���Ȩ��';

/*==============================================================*/
/* Table: admin_menu                                            */
/*==============================================================*/
create table admin_menu
(
   MenuID               bigint not null auto_increment  comment '�˵�����',
   Title                varchar(50)  comment '�˵���ʾ����',
   Kind                 tinyint not null default 0  comment '���� 0-Ŀ¼�� 1-������',
   Icon                 varchar(250)  comment 'ͼ��',
   Url                  varchar(250)  comment '�˵�URL������ʹ�����·��',
   UrlTarget            tinyint not null default 0  comment '����ģʽ 0-TAB�� 1-�´��ڴ�',
   PrivParams           varchar(250)  comment '���ܺ�����Ȩ�޲�������ʽ������-����| ����-����
             �����ڶ���ҳ����Ȩ��ʱ�����õ�Ȩ��ѡ���б�
             �磺ControlID-btnOk|ControlID-btnCancle',
   Pinyin               varchar(20)  comment 'ƴ��',
   Note                 varchar(500)  comment '����',
   OrderNum             int not null default 0  comment '���򣬴�С����',
   ParentID             bigint not null default 0  comment '���˵����� 0-���˵�',
   Status               tinyint not null default 0  comment '״̬ 0-��Ч 1-��Ч',
   primary key (MenuID)
);

alter table admin_menu comment '����˵�';

/*==============================================================*/
/* Table: admin_privilege                                       */
/*==============================================================*/
create table admin_privilege
(
   PrivilegeID          bigint not null auto_increment  comment 'Ȩ��ID',
   PrivilegeName        varchar(100)  comment 'Ȩ������',
   Kind                 tinyint not null default 0  comment 'Ȩ������ 0-�Զ��� 1-�˵���Menu',
   KindID               varchar(50)  comment '��Դ�����',
   Note                 varchar(255)  comment '����',
   Status               tinyint not null default 0  comment '״̬ 0-��Ч 1-��Ч',
   RecDate              datetime not null default CURRENT_TIMESTAMP  comment '��¼����',
   primary key (PrivilegeID)
);

alter table admin_privilege comment 'Ȩ��';

/*==============================================================*/
/* Index: index_1                                               */
/*==============================================================*/
create unique index index_1 on admin_privilege
(
   Kind,
   KindID
);

/*==============================================================*/
/* Table: admin_user                                            */
/*==============================================================*/
create table admin_user
(
   AdminID              varchar(20) not null  comment '�����û�ID',
   Password             varchar(100)  comment '��¼����',
   RealName             varchar(20)  comment '�û���ʵ����',
   Status               tinyint not null default 0  comment '״̬ 0-��Ч 1-��Ч',
   IsAdmin              bool not null default 0  comment '�Ƿ����Ա',
   RecDate              datetime not null default CURRENT_TIMESTAMP  comment '��¼����',
   primary key (AdminID)
);

alter table admin_user comment '��̨�û���';

/*==============================================================*/
/* Table: admin_user_group                                      */
/*==============================================================*/
create table admin_user_group
(
   AdminID              varchar(20) not null  comment '�û�ID',
   GroupID              bigint not null  comment '�û���ID',
   primary key (GroupID, AdminID)
);

alter table admin_user_group comment '�û����û���';

/*==============================================================*/
/* Table: admin_user_privilege                                  */
/*==============================================================*/
create table admin_user_privilege
(
   AdminID              varchar(20) not null  comment '�û�ID',
   PrivilegeID          bigint not null  comment 'Ȩ��ID',
   PrivParamsValue      varchar(250)  comment '���ܺ�����Ȩ�޲��������������д�Ȩ��
             ����-����-�Ƿ���Ȩ��| ����-����-�Ƿ���Ȩ��
             �磺ControlID-btnOk-true|ControlID-btnCancle-false',
   MapUserID            varchar(20)  comment 'ӳ��ĵ�����ƽ̨�û�����
             ��ҳ���Ѵ�������һ������ƽ̨�У��Ѵ����û�����Ȩ�޵�����¡�
             ͨ��URL�������ݣ�������ƽ̨��Ҫֱ�����Ŵ��û�',
   primary key (PrivilegeID, AdminID)
);

alter table admin_user_privilege comment '�û�Ȩ�ޱ�';

/*==============================================================*/
/* Table: demo_class                                            */
/*==============================================================*/
create table demo_class
(
   ClassID              varchar(10) not null  comment '������',
   Name                 varchar(10)  comment '���',
   Sort1                int not null  comment '',
   Sort2                int not null  comment '',
   primary key (ClassID)
);

alter table demo_class comment '���
�����кܶ�˵��';

/*==============================================================*/
/* Index: index_1                                               */
/*==============================================================*/
create unique index index_1 on demo_class
(
   Sort1,
   Sort2
);

/*==============================================================*/
/* Table: demo_course                                           */
/*==============================================================*/
create table demo_course
(
   Year                 year(4) not null  comment 'ѧ��',
   CourseID             char(36) not null  comment '�γ̱��루GUID��',
   Name                 varchar(10)  comment '����',
   OrderNum             int not null  comment '',
   primary key (Year, CourseID)
);

alter table demo_course comment '�γ�';

/*==============================================================*/
/* Index: index_1                                               */
/*==============================================================*/
create unique index index_1 on demo_course
(
   OrderNum
);

/*==============================================================*/
/* Table: demo_user                                             */
/*==============================================================*/
create table demo_user
(
   UserID               bigint not null auto_increment  comment '�û����루�����ֶΣ�',
   ClassID              varchar(10)  comment '������',
   FBit                 bit not null default 1  comment '�ֶ�1
                     ����1
                     ����2',
   FBit_Max             bit(64)  comment '',
   FTinyInt             tinyint not null default 127  comment '',
   FTinyInt_Unsigned    tinyint unsigned default 255  comment '',
   FBool                bool  comment '',
   F_Boolean            boolean not null default 1  comment '',
   FBool_TinyInt        tinyint(1) default 0  comment '',
   FSmallInt            smallint not null default -32768  comment '',
   FSmallInt_Unsigned   smallint unsigned default 65535  comment '',
   FMediumInt           mediumint not null default -8388608  comment '',
   FMediumInt_Unsigned  mediumint unsigned  comment '',
   FInt                 int not null default -2147483648  comment '',
   FInt_Unsigned        int unsigned default 4294967295  comment '',
   F_Integer            Integer  comment '',
   FBigInt              bigint not null default -9223372036854775808  comment '',
   FBigInt_Unsigned     bigint unsigned  comment '',
   FFloat               float not null default 12.345678  comment '',
   FFloat_Max           float(7,4) unsigned  comment '',
   FDouble              double not null default 123456789.1234567  comment '',
   FDouble_Max          double(15,4) unsigned  comment '',
   F_Real               real  comment '',
   F_Double_Precision   double precision unsigned  comment '',
   FYear                year(4)  comment '',
   FDate                date  comment '',
   FTime                time  comment '',
   FTimestamp           timestamp default CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP  comment '',
   FDateTime            datetime  comment '',
   FChar                char(4)  comment '',
   FVarChar             varchar(255)  comment '',
   FBinary              binary(2)  comment '',
   FVarBinary           varbinary(2)  comment '',
   FTinyText            tinytext  comment '',
   FText                text  comment '',
   FMediumText          mediumtext  comment '',
   FLongText            longtext  comment '',
   FTinyBlob            tinyblob  comment '',
   FBlob                blob  comment '',
   FMediumBlob          mediumblob  comment '',
   FLongBlob            longblob  comment '',
   FEnum                enum('m','f')  comment '',
   FSet                 set('one','two')  comment '',
   FDecimal             decimal not null default 123.45  comment '',
   FDecimal_Max         decimal(65,30) unsigned  comment '',
   F_Numeric            numeric  comment '',
   F_Dec                dec  comment '',
   F_Fixed              fixed  comment '',
   primary key (UserID)
);

alter table demo_user comment '�û���';

/*==============================================================*/
/* Index: index_1                                               */
/*==============================================================*/
create index index_1 on demo_user
(
   FInt
);

/*==============================================================*/
/* Index: index_3                                               */
/*==============================================================*/
create index index_3 on demo_user
(
   FYear,
   FDate
);

/*==============================================================*/
/* Table: demo_user_course                                      */
/*==============================================================*/
create table demo_user_course
(
   UserID               bigint not null  comment '�û����루�����ֶΣ�',
   Year                 year(4) not null  comment 'ѧ��',
   CourseID             char(36) not null  comment '�γ̱��루GUID��',
   Note                 text  comment '˵��',
   primary key (UserID, CourseID, Year)
);

alter table demo_user_course comment '�û������';

/*==============================================================*/
/* Table: sys_china_area                                        */
/*==============================================================*/
create table sys_china_area
(
   AreaID               int not null  comment '����������',
   Name                 varchar(20)  comment 'ʡ�����ƣ��籱����',
   ParentId             int not null  comment '��������
             0- ��
             100000 -�й�',
   ShortName            varchar(20)  comment '���Ƽ�д���籱��',
   Level                int not null  comment '����
             0-��
             1-ʡ����������ֱϽ�У��ر�������
             2-�У������������ݣ��ˣ�ֱϽ��������Ͻ������
             3-�أ���Ͻ�����ؼ��У���
             4-���򣨽ֵ����´���',
   CityCode             varchar(10)  comment '���д��루�绰���ţ�',
   ZipCode              varchar(10)  comment '��������',
   MergerName           varchar(50)  comment '�����ƣ����й���������������',
   Lng                  double(10,5) not null  comment '����',
   Lat                  double(10,5) not null  comment 'γ��',
   PinYin               varchar(20)  comment 'ƴ��',
   JianPin              varchar(20)  comment '��ƴ',
   Alias                varchar(6)  comment '�������紨',
   OtherAlias           varchar(10)  comment '��������������',
   Status               int not null default 0  comment '��Ч״̬
             0-��Ч
             1-��Ч
             2-���
             3-ɾ��',
   primary key (AreaID)
);

alter table sys_china_area comment '�й�ʡ��4������';

/*==============================================================*/
/* Table: sys_log                                               */
/*==============================================================*/
create table sys_log
(
   LogID                bigint unsigned not null auto_increment  comment '��־����',
   LogDate              datetime not null  comment '��־����ʱ��',
   Level                varchar(10) not null  comment '��־�ȼ�
             0-δ֪
             1-DEBUG
             2-INFO
             3-WARN
             4-ERROR
             5-FATAL',
   Logger               varchar(50)  comment '��־��¼������',
   Message              text  comment '��־��Ϣ',
   Exception            text  comment '�쳣',
   ExpUserData          text  comment '�쳣�û�����',
   Thread               varchar(100)  comment '�߳�ID',
   Location             varchar(500)  comment '��������Դ�ļ����к�
             ���棺��Ӱ�����ܡ�û��pdb�ļ��Ļ���ֻ�з�������û��Դ�ļ������кš�',
   HostName             varchar(100)  comment '������',
   HostIp               varchar(20)  comment '����IP',
   Operator             varchar(50)  comment '������',
   ProjectId            varchar(100)  comment '�����ʶ',
   primary key (LogID)
);

alter table sys_log comment 'ϵͳ����־������ƽ̨Ӧ��';

/*==============================================================*/
/* Index: index_1                                               */
/*==============================================================*/
create index index_1 on sys_log
(
   LogDate
);

/*==============================================================*/
/* Index: index_2                                               */
/*==============================================================*/
create index index_2 on sys_log
(
   LogDate,
   Level
);

/*==============================================================*/
/* View: v_admin_priv                                           */
/*==============================================================*/
create or replace view v_admin_priv as
select t1.PrivilegeID, t1.PrivilegeName, t1.Kind as PrivKind, t2.MenuID, t2.Title as MenuTitle, t2.Icon as MenuIcon, t2.Kind as MenuKind
	, t2.Url as MenuUrl, t2.UrlTarget as MenuUrlTarget, t2.PrivParams as MenuPrivParams, t2.OrderNum as MenuOrderNum, t2.ParentID as MenuParentID
	, t2.Pinyin as MenuPinyin, t2.Note as MenuNote, t1.Note as PrivNote
from admin_privilege t1 
	left join admin_menu t2 on t1.Kind = 1 and t1.KindID = t2.MenuID and t2.`Status` = 1
where t1.`Status` = 1;

/*==============================================================*/
/* View: v_admin_user_group                                     */
/*==============================================================*/
create or replace view v_admin_user_group as
select t2.AdminID, t2.RealName, t3.GroupID, t3.GroupName
from admin_user_group t1 
	left join admin_user t2 on t2.`Status`=1 and t1.AdminID = t2.AdminID
	left join admin_group t3 on t3.`Status`=1 and t1.GroupID=t3.GroupID;

/*==============================================================*/
/* View: v_admin_user_priv                                      */
/*==============================================================*/
create or replace view v_admin_user_priv as
select
   t1.AdminID,
   null as GroupID,
   t1.PrivParamsValue,
   t1.MapUserID,
   t2.*
from
   admin_user_privilege t1
   left join v_admin_priv t2 on  t1.PrivilegeID = t2.PrivilegeID
group by
   PrivilegeID

UNION
select
   t2.AdminID,
   t1.GroupID,
   t1.PrivParamsValue,
   t1.MapUserID,
   t3.*
from
   admin_group_privilege t1
   left join v_admin_user_group t2 on  t1.GroupID = t2.GroupID
   left join v_admin_priv t3 on  t1.PrivilegeID = t3.PrivilegeID;

/*==============================================================*/
/* View: v_demo_user_course                                     */
/*==============================================================*/
create or replace view v_demo_user_course as
select t2.UserID, t2.ClassID, t3.CourseID, t3.Name, t1.Note, '������' as TestColumn
from demo_user_course as t1
	left join demo_user as t2 on t1.UserID = t2.UserID
	left join demo_course as t3 on t1.CourseID = t3.CourseID;

alter table demo_user add constraint FK_DEMO_USER_DEMO_CLASS foreign key (ClassID)
      references demo_class (ClassID) on delete restrict on update restrict;

alter table demo_user_course add constraint FK_DEMO_USER_COURSE_DEMO_USER foreign key (UserID)
      references demo_user (UserID) on delete restrict on update restrict;

alter table demo_user_course add constraint FK_DEMO_USER_COURSE_DEMO_COURSE foreign key (Year, CourseID)
      references demo_course (Year, CourseID) on delete restrict on update restrict;


create procedure p_demo_get_user_course(in pUserID bigint,out pPageCount int)
comment '�洢��������'
begin
	select count(0) into pPageCount from demo_user_course where UserID = pUserID;
	select * from demo_user_course where UserID = pUserID;
	select 'abc';
	-- return 123
end;

