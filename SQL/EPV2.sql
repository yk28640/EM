create database EP
on primary
(
name= 'EP',
filename='D:\Projects\EM\SQL\EP.mdf',
size=5MB,
MaxSize=2048MB,
filegrowth=20%
)
log on 
(
name='EP_log',
filename='D:\Projects\EM\SQL\EP.ldf',
size=5MB,
MaxSize=1024MB,
filegrowth=5mb
)
use EP  --创建之前先切换到这个数据库
create table Person_P
(
AutoID  int Identity(1,1)  primary key,
company_ID varchar(20) ,
First_Name varchar(20) not null,
Family_Name varchar(20) not null,
Call_Name varchar(20) not null,
BBAC bit not null,
BAIC bit not null ,
Daimler bit not null,
Supplier bit not null ,
L_ID varchar(20) 
)
alter table person_P --添加约束，必须四选一
Add constraint chk_person_CHECK check (cast(BBAC AS INteger)+cast(BAIC AS INteger)+cast(Daimler AS INteger)+cast(Supplier AS INteger)=1)

Create table Department_E4
(
AutoID  int Identity(1,1)  primary key,
Name varchar(20) not null,
Short_Name varchar(20),
Description Varchar(100),
CostCenter Varchar(10) not null
)

Create table DepartmentPerson_E4_P
(
AutoID  int Identity(1,1)  primary key,
--P_ID int  Foreign key References Person_P(AutoID) not null ,
E4_ID int Foreign key References Department_E4(AutoID) not null ,
Leader_P_ID int  Foreign key References Person_P(AutoID) not null ,
Assistant_P_ID int  Foreign key References Person_P(AutoID) not null ,
Direct_Member_P_ID int  Foreign key References Person_P(AutoID) not null 
)

create table Group_E5
(
AutoID  int Identity(1,1)  primary key,
Name varchar(20) not null,
ShortName varchar(20),
Descriptions Varchar(Max)
)

Create table DepartmentGroup_E4_E5
(
AutoID  int Identity(1,1)  primary key,
Department_E4_ID Int Foreign key references Department_E4(AutoID) not null ,
Group_E5_ID Int Foreign key references Group_E5(AutoID) not null
)

Create table GroupPerson_E5_P
(
AutoID  int Identity(1,1)  primary key,
--P_ID int  Foreign key References Person_P(AutoID) not null ,
Group_E5_ID Int Foreign Key References Group_E5(AutoID) not null,
Leader_P_ID int  Foreign key References Person_P(AutoID) not null ,
Direct_Member_P_ID int  Foreign key References Person_P(AutoID) not null 
)

Create table K1 --Knowledge Level
(
AutoID int identity(1,1) primary key ,
Number int not null ,
Name varchar(20) ,
Definitions varchar(20) ,
VeryComplex int not null ,
Complex int not null ,
Normal int not null ,
Easy int not null ,
VeryEasy int not null 
)


Create table E5_Prio_Levels       --Group_Manpower_inprio_levels
(
AutoID  int Identity(1,1)  primary key,
Group_E5_ID Int Foreign Key References Group_E5(AutoID) not null,
K1_ID Int Foreign key references K1(AutoID) not null,
Percentage0_10 INT NOT NULL,
Percentage11_20 INT NOT NULL,
Percentage21_30 INT NOT NULL,
Percentage31_40 INT NOT NULL,
Percentage41_50 INT NOT NULL,
Percentage51_60 INT NOT NULL,
Percentage61_70 INT NOT NULL,
Percentage71_80 INT NOT NULL,
Percentage81_90 INT NOT NULL,
Percentage91_100 INT NOT NULL,
PercentageMoreThan100 INT NOT NULL,

)

Create table Team
(
AutoID  int Identity(1,1)  primary key,
Name varchar(20) not null,
Short_Name varchar(20),
Descriptions varchar(Max) 
)

Create table E5_Team --Group/Team
(
AutoID  int Identity(1,1)  primary key,
Group_E5_ID Int Foreign Key References Group_E5(AutoID) not null,
Team_ID Int Foreign key References Team(AutoID) not null
)

Create table Team_P
(
AutoID  int Identity(1,1)  primary key,
Team_ID Int Foreign key References Team(AutoID) not null,
--P_ID Int  Foreign key References Person_P(AutoID) not null ,
Leader_P_ID Int  Foreign key References Person_P(AutoID) not null ,
Direct_Member_P_ID Int  Foreign key References Person_P(AutoID) not null 
)
Create table Suplier_S 
(
AutoID  int Identity(1,1)  primary key,
Name varchar(20) not null,
Descriptions varchar(Max) 

)

Create table SuplierPerson_S_P
(
AutoID  int Identity(1,1)  primary key,
Supplier_S_ID Int Foreign key references Suplier_S(AutoID) not null,
Persona_P_ID int Foreign key References Person_P(AutoID) not null 
)

Create table Contacts_Co
(
AutoID  int Identity(1,1)  primary key,
Descriptions varchar(Max),
PhoneNumber varchar(20),
Email Varchar(30),
Web_Address varchar(30),
Fax varchar(30)
)
Alter table Contacts_Co 
Add Constraint chk_Contacts_Co Check( Web_Address like '%@%')

Create table A --Area/Machine
(
AutoID  int Identity(1,1)  primary key,
FunctionLocation varchar(20) ,
FunctionLocationName varchar(20) not null ,
MainteananceWorkCenter varchar(20) ,
PlannerGroup varchar(20),
Descriptions varchar(Max),
Supvisor_Area_A_ID varchar(20),
Machine bit ,
Zone bit ,
Line bit ,
Plant bit ,
SOP_Date date  not null,
BottleNeck bit ,
BreakdownFactor int ,
T3PartyResponsible bit ,
SupportOnsite bit not null,
SupportItech bit not null ,
SupportChina bit not null,
SupportInternational bit not null,
NoSupport bit not null
)

Create table Contacts_Linkin_Co_link
(
AutoID  int Identity(1,1)  primary key,
Co_ID Int Foreign key references Contacts_Co(AutoID) not null,
Person_P_ID Int Foreign key references Person_P(AutoID) ,
Department_E4_ID Int Foreign key References Department_E4(AutoID) ,
Group_E5_ID Int Foreign key references Group_E5(AutoID) ,
Team_ID Int Foreign key references Team(AutoID) ,
Supplier_S_ID Int Foreign key references Suplier_S(AutoID),
A_ID Int Foreign key references A(AutoID) 
)

Create table L -- Level/Position
(
AutoID  int Identity(1,1)  primary key,
ShortNameDaimler varchar(20) not null ,
NameDaimler varchar(20) ,
ShortNameBBAC varchar(20) not null ,
NameBBAC varchar(20) ,
Descriptions Varchar(Max)
)

create table Te --Technologies/skills/workprocess
(
AutoID  int Identity(1,1)  primary key,
Name Varchar(20) not null ,
Descriptions varchar(Max) not null,
Mechanic bit ,
Eelectric bit ,
IT bit ,
Technology bit not null ,
WorkProcess bit not null,
Skill bit not null,
Languages bit not null,
VeryComplex bit not null,
Complex bit not null,
Normal bit not null,
Easy bit not null,
VeryEasy bit not null,
T3PartyResponsible bit ,
SupportOnsite bit not null,
SupportItech bit not null ,
SupportChina bit not null ,
SupportInternational bit  not null ,
NoSupport bit not null 
)

create table TR --Training 
(
AutoID  int Identity(1,1)  primary key,
Title varchar(20) not null ,
Content varchar(100),
TargetGroupRequirement varchar(50) ,
TrainingGoal varchar(50),
EvaluatiobDescription varchar(50),
MinParticipiants int ,
MaxParticipiants int ,
RetrainNecessary bit ,
RetrainCycle varchar(20) ,
Creator  varchar(20),
Versions varchar(20),
LastUpdate date ,
Test bit ,
TestTime varchar(20),
TrainingDuration varchar(20),
DurationInHours float not null ,
DurationInDays float ,
CostPerParticipantRMB float ,
CostPerHoursRMB float ,
TeID varchar(20) not null ,
AID varchar(20) not null ,
S_ID varchar(20) not null ,
SPL bit not null ,
Internal bit not null ,
SupplierOnsite bit not null ,
TrainingCenter bit not null ,
ExternalChina bit not null ,
ExternalInternational bit not null
) 

create table Tr_Values -- Training Values
(
AutoID  int Identity(1,1)  primary key,
SPL int not null ,
Internal int not null ,
SupplierOnsite int not null ,
TrainingCenter int not null ,
ExternalChina int not null ,
ExternalInternational int not null 
)


Create table E1 --Experience_Level
(
AutoID  int Identity(1,1)  primary key,
Number Int not null ,
Name varchar(20) ,
Definitions Varchar(20)
)

Create table L1 --Language_Level
(
AutoID  int Identity(1,1)  primary key,
Number int not null ,
Levels varchar(20) not null ,
LevelName varchar(20) ,
Definitions varchar(20) 
)

Create table Tag
(
AutoID  int Identity(1,1)  primary key,
AllTableID varchar(20) not null ,
Name varchar(20) not null ,
Descriptions varchar(Max) 
)

Create table Content
(
AutoID  int Identity(1,1)  primary key,
Name varchar(20) not null ,
Descriptions varchar(Max) ,
Link varchar(20) not null ,
PassName varchar(20) ,
PassWords varchar(20) ,
Domain varchar(20),
Tr_ID Int Foreign Key References Tr_Values(AutoID),
A_ID Int Foreign Key References A(AutoID),
P_ID Int Foreign Key References Person_P(AutoID),
S_ID Int Foreign Key References Suplier_S(AutoID)
)

Create table  E5_A --group area 
(
AutoID  int Identity(1,1)  primary key,
E5_ID Int Foreign key references Group_E5(AutoID) not null,
A_ID Int Foreign key references A(AutoID) not null 
)


Create table E5_TE -- Group_Technology
(
AutoID  int Identity(1,1)  primary key,
E5ID Int Foreign key references Group_E5(AutoID) not null ,
TeIDManualInput Int Foreign key references Te(AutoID),
TeIDFromE5AID Int Foreign key references E5_A(AutoID),
Core bit ,
PriorityCaculatedValue int ,
PriorityOverrideValue int 
)

Create table A_Te --Area_Technology 
(
AutoID  int Identity(1,1)  primary key,
A_ID Int Foreign key references A(AutoID) ,
Te_ID Int Foreign key references Te(AutoID),
Sop_Date Date not null 
)

Create table P_Te_K1_E1_L1  --Person/Technology/Knowlege/Level/ExperienceLevel/LauguageLevel
(
AutoID  int Identity(1,1)  primary key,
Person_ID Int Foreign key references Person_P(AutoID) not null,
Technology_ID Int Foreign key references Te(AutoID) not null,
K1_ID_required Int Foreign key references K1(AutoID) not null,
K1_Target_Date date not null ,
K1_Actual_ID Int Foreign key references K1(AutoID)not null,
K1_Actual_value int not null ,
K1_Change_date date not null ,
Languages_ID_Required  Int Foreign key references L1(AutoID)not null ,
L1_TargetDate date not null ,
L1_ID_Actual Int Foreign key references L1(AutoID)not null ,
L1_ChangeDate date not null ,
Experience_ID_Required Int Foreign key references E1(AutoID)not null,
E1_Target_date date not null,
Experience_Actual_ID  varchar(20)not null,
E1_changeDate date not null 
)

Create Table Sch_Tr_date_P
(
AutoID  int Identity(1,1)  primary key,
Tr_ID Int Foreign key references Tr(AutoID) not null ,
Start_Dates date not null ,
End_date date ,
P_ID Int Foreign key references Person_P(AutoID),
Trainer bit not null ,
Trainee bit not null ,
Passed bit ,
Result_Points Int
) 









