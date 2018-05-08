Create database HRM
go

use HRM
go

create table tblDepartment
(
  DeptCode nvarchar(30) PRIMARY KEY,
  DeptName nvarchar(30) not null
)
go

select * from tblDepartment
go

Insert into tblDepartment values ('DP-001','IT')
go

create table tblDivision
(
  DivCode nvarchar(30) PRIMARY KEY,
  DivName nvarchar(30) not null
)
go

select * from tblDivision
go

insert into tblDivision values ('DV-001','Dhaka')
go

create table tblSection
(
  SceCode nvarchar(30) PRIMARY KEY,
  SecName nvarchar(30) not null
)
go

select * from tblSection
go

insert into tblSection values ('ST-001','Training')
go

create table tblDesignation
(
 DesigCode nvarchar(30) PRIMARY KEY,
 Designation nvarchar(30) not null,
 DeptCode nvarchar(30) FOREIGN KEY REFERENCES tblDepartment(DeptCode)
) 
go

select * from tblDesignation
go

insert into tblDesignation values ('DG-001','Instructor','DP-001')
go

create table tblEmployeeType
(
  ETCode nvarchar(30) PRIMARY KEY,
  EmployeeType nvarchar(30) not null
)
go

select * from tblEmployeeType
go

insert into tblEmployeeType values ('ET-001','Staff')
go

create table tblEmployee
(
  EmpCode nvarchar(30) PRIMARY KEY,
  EmpName nvarchar(30) not null,
  [Address] nvarchar(50) null,
  Gender nvarchar(15) not null,
  Email nvarchar(50) not null,
  Contact nvarchar(20) not null,
  DateOfBirth datetime not null,
  Religion nvarchar(20) null,
  Nationality nvarchar(30) null,
  NationalIDNo nvarchar(30) null,
  MaritalStatus nvarchar(20) null,
  FatherName nvarchar(30) null,
  MotherName nvarchar(30) null,
  BloodGroup nvarchar(20) null,
  JoiningDate datetime not null,
  CurrentSalary nvarchar(50) not null,
  DeptCode nvarchar(30) FOREIGN KEY REFERENCES tblDepartment(DeptCode),
  DivCode nvarchar(30) FOREIGN KEY REFERENCES tblDivision(DivCode),
  SceCode nvarchar(30) FOREIGN KEY REFERENCES tblSection(SceCode),
  DesigCode nvarchar(30) FOREIGN KEY REFERENCES tblDesignation(DesigCode),
  ETCode nvarchar(30) FOREIGN KEY REFERENCES tblEmployeeType(ETCode),
)
go

select * from tblEmployee
go

insert into tblEmployee values ('EMP-001','Rafat Ali','Dhaka','Male','az@gmail.com','01739478644','1.1.1990','Islam','Bangladeshi','19902378465334','Married','Jamal Ali','Laili Begum','A-positive','4.4.2010','60000','DP-001','DV-001','ST-001','DG-001','ET-001')
go

create table tblAttendance
(
 ATTCode INT IDENTITY,
 ATTDate datetime PRIMARY KEY not null,
 EmpCode nvarchar(30) FOREIGN KEY REFERENCES tblEmployee(EmpCode),
 InHour nvarchar(20) not null,
 InMinute nvarchar(20) not null,
 OutHour nvarchar(20) not null,
 OutMinute nvarchar(20) not null,
 ATTStatus nvarchar(20) not null,
 TotalRegularHour nvarchar(50) null,
 Remarks nvarchar(200) null
)
go

select * from tblAttendance
go

--insert into tblAttendance values ('11.11.2017','EMP-001','11','05','7','10','Late','8','Traffic Jam')
--go

create table tblSalaryCreate
(
 SalCreateCode int,
 EmpCode nvarchar(30),
 BasicAmt nvarchar(50),
 HouseRentAmt nvarchar(50) null,
 MedicalAmt nvarchar(50) null,
 OtherAllAmt nvarchar(50) null,
 GrossAmt nvarchar(50) null,
 MonthNo int null,
 YearNo int null,
 SFromDT datetime null,
 SToDT datetime null,
 CreateDate datetime null
)
go

select * from tblSalary
go

insert into tblSalary values ('40000','19000','500','500','60000','EMP-001')
go

create table tblSalaryInformation
(
 SHCode nvarchar(30) PRIMARY KEY,
 SHName nvarchar(40) null,
 SHAmount nvarchar(50) null,
 EmpCode nvarchar(30) FOREIGN KEY REFERENCES tblEmployee(EmpCode)
)
go

select * from tblSalaryInformation
go

--insert into tblSalaryInformation values ('SH-001','Basic','40000','EMP-001')
--go



create table tblBenefitRecord
(
  BenefitCode int PRIMARY KEY IDENTITY,
  EmpCode nvarchar(30) FOREIGN KEY REFERENCES tblEmployee(EmpCode),
  BenefitAmount nvarchar(50)  null,
  BenefitDate datetime null,
  BenefitType nvarchar(20) not null,
  PreviousNetSalary nvarchar(50) not null,
  NewNetSalary nvarchar(50) not null,
  Gross nvarchar(50)  null,
  [Basic] nvarchar(50)  null,
  HouseRent nvarchar(50) null,
  Medical nvarchar(50) null,
  OtherAllowance nvarchar(50) null,
  BenefitActiveDate datetime  null,
  IncentiveBonus nvarchar(50) null,
  StateStatus nvarchar(50) null,
  Remarks nvarchar(50) null
)
go

select * from tblBenefitRecord
go

insert into tblBenefitRecord values ('BF-001','EMP-001','5000','1.30.2018','Increment','2.1.2018','65000','45000','15000','500','500','4000','5000','55000','60000','Probitionary','Active')
go

create table tblTransferRecord
(
 TRCode int PRIMARY KEY identity,
 EmpCode nvarchar(30) FOREIGN KEY REFERENCES tblEmployee(EmpCode),
 TRDate datetime null,
 OldDeptCode nvarchar(30) null,
 NewDeptCode nvarchar(30) null,
 OldDivCode nvarchar(30) null,
 NewDivCode nvarchar(30) null,
 OldSecCode nvarchar(30) null,
 NewSecCode nvarchar(30) null,
 OldDesigCode nvarchar(30) null,
 NewDesigCode nvarchar(30) null,
 TRActiveDate datetime  null,
 StateStatus nvarchar(50)  null,
 Remarks nvarchar(100) null
)
go

select * from tblTransferRecord
go

select sl.EmpCode,sl.Gross,sl.Basic,sl.HouseRent,sl.Medical,sl.OtherAllowance from tblSalaryInformation si inner join tblSalary sl on sl.EmpCode=si.EmpCode

insert into tblTransferRecord(EmpCode,OldDeptCode,OldDesigCode,OldDivCode,NewDeptCode,NewDesigCode,NewDivCode,TRActiveDate) values('EMP-002','DP-001','DG-001','DV-001','DP-002','DG-002','DV-002','2-2-2018')
