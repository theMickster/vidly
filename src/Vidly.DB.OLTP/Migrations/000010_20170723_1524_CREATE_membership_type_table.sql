-- <Migration ID="822dfcdc-78a8-4545-8901-e76186ce84db" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.23
** CREATION:     Create membership type table
**************************************************************************/
CREATE TABLE codes.membership_type_codes
(
	membership_type_code_id TINYINT IDENTITY(1,1) NOT NULL 
	,membership_type_desc VARCHAR(50) NOT NULL CONSTRAINT UNQ_membership_type_codes UNIQUE
	,sign_up_fee SMALLINT NULL
	,duration_in_months TINYINT NULL
	,discount_rate TINYINT NOT NULL
	,active_flag BIT NOT NULL CONSTRAINT DF_membership_type_code_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_membership_type_code_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_membership_type_code_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_membership_type_code_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_membership_type_code_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_membership_type_code PRIMARY KEY CLUSTERED (membership_type_code_id)
)
EXECUTE sys.sp_addextendedproperty @name='MS_Description', @value='Table to store types of video rental memberships.' , @level0type='SCHEMA',@level0name='codes', @level1type='TABLE',@level1name='membership_type_codes'

SET IDENTITY_INSERT codes.membership_type_codes ON;
INSERT INTO codes.membership_type_codes(membership_type_code_id,membership_type_desc,sign_up_fee,duration_in_months,discount_rate,active_flag,create_user,create_date,update_user,update_date)
VALUES (1, 'Pay As You Go',20,0,0,1,1,GETDATE(),1,GETDATE()), (2, 'Monthly',20,1,5,1,1,GETDATE(),1,GETDATE()), (3, 'Quarterly',20,4,10,1,1,GETDATE(),1,GETDATE()), (4, 'Yearly',20,12,15,1,1,GETDATE(),1,GETDATE())
SET IDENTITY_INSERT codes.membership_type_codes OFF;

ALTER TABLE dbo.customers ADD membership_type_code_id TINYINT NULL 
	CONSTRAINT FK_customers_membership_type_codes FOREIGN KEY (membership_type_code_id) REFERENCES codes.membership_type_codes (membership_type_code_id);