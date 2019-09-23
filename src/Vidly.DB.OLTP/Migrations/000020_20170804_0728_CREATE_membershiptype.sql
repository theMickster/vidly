-- <Migration ID="0cae1c24-244c-4f1b-8dcf-e878df07a6f8" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.04
** CREATION:     Add membership type table
**************************************************************************/
CREATE TABLE dbo.MembershipType
(
	MembershipTypeId INTEGER IDENTITY(1,1)
	,MembershipTypeName VARCHAR(25) NOT NULL
	,SignUpFee SMALLINT NULL
	,DurationInMonths TINYINT NULL
	,DiscountRate TINYINT NULL
	,ActiveFlag BIT NOT NULL
	,CreateUser INTEGER NOT NULL CONSTRAINT DF_MembershipType_CreateUser DEFAULT(1)
	,CreateDate DATETIME NOT NULL CONSTRAINT DF_MembershipType_CreateDttm DEFAULT(GETDATE())
	,UpdateUser INTEGER NOT NULL CONSTRAINT DF_MembershipType_UpdateUser DEFAULT(1)
	,UpdateDate DATETIME NOT NULL CONSTRAINT DF_MembershipType_UpdateDttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_MembershipType  PRIMARY KEY CLUSTERED (MembershipTypeId)
)

SET IDENTITY_INSERT dbo.MembershipType ON;
INSERT INTO dbo.MembershipType(MembershipTypeId, MembershipTypeName,SignUpFee,DurationInMonths,DiscountRate,ActiveFlag,CreateUser,CreateDate,UpdateUser,UpdateDate)
VALUES (1, 'Pay As You Go',20,0,0,1,1,GETDATE(),1,GETDATE()), (2, 'Monthly',20,1,5,1,1,GETDATE(),1,GETDATE()), (3, 'Quarterly',20,4,10,1,1,GETDATE(),1,GETDATE()), (4, 'Yearly',20,12,15,1,1,GETDATE(),1,GETDATE())
SET IDENTITY_INSERT dbo.MembershipType OFF;

ALTER TABLE dbo.customers DROP CONSTRAINT FK_customers_membership_type_codes 
ALTER TABLE dbo.customers ADD MembershipTypeId INTEGER NULL FOREIGN KEY (MembershipTypeId) REFERENCES dbo.MembershipType (MembershipTypeId);