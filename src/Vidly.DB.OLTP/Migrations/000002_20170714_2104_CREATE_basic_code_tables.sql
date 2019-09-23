-- <Migration ID="bc21ee11-153a-4f55-89fb-39e3631e2221" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.14
** CREATION:     Create some basic codes tables
**************************************************************************/
CREATE TABLE codes.ordinal_type_codes
(
	ordinal_type_code_id TINYINT IDENTITY(1,1) NOT NULL 
	,ordinal_type_desc VARCHAR(50) NOT NULL CONSTRAINT UNQ_ordinal_type_codes UNIQUE
	,active_flag BIT NOT NULL CONSTRAINT DF_ordinal_type_code_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_ordinal_type_code_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_ordinal_type_code_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_ordinal_type_code_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_ordinal_type_code_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_ordinal_type_code PRIMARY KEY CLUSTERED (ordinal_type_code_id)
)
EXECUTE sys.sp_addextendedproperty @name='MS_Description', @value='Table to store types representing position or rank in a sequential order. The order may be of size, importance, chronology, etc.' , @level0type='SCHEMA',@level0name='codes', @level1type='TABLE',@level1name='ordinal_type_codes'

CREATE TABLE codes.address_location_codes
(
	address_location_code_id TINYINT IDENTITY(1,1) NOT NULL 
	,address_location_desc VARCHAR(50) NOT NULL CONSTRAINT UNQ_address_location_codes UNIQUE
	,active_flag BIT NOT NULL CONSTRAINT DF_address_location_code_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_address_location_code_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_address_location_code_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_address_location_code_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_address_location_code_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_address_location_code PRIMARY KEY CLUSTERED (address_location_code_id)
)
EXECUTE sys.sp_addextendedproperty @name='MS_Description', @value='Table to store the types of geographical addresses.' , @level0type='SCHEMA',@level0name='codes', @level1type='TABLE',@level1name='address_location_codes'

CREATE TABLE codes.generational_codes
(
	generational_code_id TINYINT IDENTITY(1,1) NOT NULL
	,generational_desc VARCHAR(50) NOT NULL CONSTRAINT UNQ_generational_codes UNIQUE
	,active_flag BIT NOT NULL CONSTRAINT DF_generational_codes_active_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_generational_codes_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_generational_codes_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_generational_codes_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_generational_codes_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_generational_codes PRIMARY KEY CLUSTERED (generational_code_id)
)
EXECUTE sys.sp_addextendedproperty @name='MS_Description', @value='Table to store the types of generational names.' , @level0type='SCHEMA',@level0name='codes', @level1type='TABLE',@level1name='generational_codes'


SET IDENTITY_INSERT codes.address_location_codes ON;
INSERT INTO codes.address_location_codes(address_location_code_id, address_location_desc,active_flag,create_user,create_date,update_user,update_date)
VALUES	(1,'PHYSICAL ADDRESS',1,1,GETDATE(),1,GETDATE()), (2,'MAILING ADDRESS',1,1,GETDATE(),1,GETDATE()), (3,'POST OFFICE BOX',1,1,GETDATE(),1,GETDATE()), (4,'SERVICE ADDRESS',1,1,GETDATE(),1,GETDATE())
SET IDENTITY_INSERT codes.address_location_codes OFF;

SET IDENTITY_INSERT codes.ordinal_type_codes ON;
INSERT INTO codes.ordinal_type_codes(ordinal_type_code_id, ordinal_type_desc,active_flag,create_user,create_date,update_user,update_date)
VALUES	(1,'PRIMARY',1,1,GETDATE(),1,GETDATE()), (2,'SECONDARY',1,1,GETDATE(),1,GETDATE()), (3,'TERTIARY',1,1,GETDATE(),1,GETDATE())
SET IDENTITY_INSERT codes.ordinal_type_codes OFF;

SET IDENTITY_INSERT codes.generational_codes ON;
INSERT INTO codes.generational_codes (generational_code_id, generational_desc, active_flag, create_user, create_date, update_user, update_date)
VALUES (1,'Jr',1,1,GETDATE(),1,GETDATE()),(2,'Sr',1,1,GETDATE(),1,GETDATE()),(3,'II',1,1,GETDATE(),1,GETDATE()),(4,'III',1,1,GETDATE(),1,GETDATE()),(5,'IV',1,1,GETDATE(),1,GETDATE()),
(6,'V',1,1,GETDATE(),1,GETDATE()),(7,'VI',1,1,GETDATE(),1,GETDATE()),(8,'VII',1,1,GETDATE(),1,GETDATE()),(9,'VIII',1,1,GETDATE(),1,GETDATE()),(10,'IX',1,1,GETDATE(),1,GETDATE()),(11,'X',1,1,GETDATE(),1,GETDATE())
SET IDENTITY_INSERT codes.generational_codes OFF;


