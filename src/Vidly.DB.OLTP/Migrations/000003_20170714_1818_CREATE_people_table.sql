-- <Migration ID="f94b1fc1-3a78-4f61-8c7b-70569a1b2ef3" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.14
** CREATION:     Create simple people tables.
**************************************************************************/
GO
CREATE TABLE dbo.people
(
	people_id INTEGER IDENTITY(1,1) NOT NULL
	,first_name VARCHAR(100) NOT NULL
	,middle_name VARCHAR(100) NULL
	,last_name VARCHAR(100) NOT NULL
	,generational_code_id TINYINT NOT NULL CONSTRAINT FK_people_generational_codes FOREIGN KEY REFERENCES codes.generational_codes (generational_code_id)
	,dob DATE NULL
	,deleted_flag BIT NOT NULL CONSTRAINT DF_people_deleted_flag DEFAULT (1)
	,create_user INTEGER NOT NULL CONSTRAINT DF_people_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_people_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_people_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_people_update_dttm DEFAULT(GETDATE())
    ,CONSTRAINT PK_people PRIMARY KEY CLUSTERED (people_id ASC)
)

CREATE TABLE dbo.people_email_addresses
(
	people_email_id INTEGER IDENTITY(1,1) NOT NULL
	,people_id INTEGER NOT NULL CONSTRAINT FK_people_email_addresses_people FOREIGN KEY REFERENCES dbo.people (people_id)
	,email_address VARCHAR(250) CONSTRAINT UNQ_people_email_addresses UNIQUE
	,active_flag BIT NOT NULL CONSTRAINT DF_people_email_addresses_active_flag DEFAULT (1)
	,primary_flag BIT NOT NULL CONSTRAINT DF_people_email_addresses_primary_flag DEFAULT (0)
	,create_user INTEGER NOT NULL CONSTRAINT DF_people_email_addresses_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_people_email_addresses_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_people_email_addresses_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_people_email_addresses_update_dttm DEFAULT(GETDATE())
)

CREATE TABLE dbo.people_addresses
(
	people_address_id INTEGER IDENTITY(1,1) NOT NULL
	,people_id INTEGER NOT NULL CONSTRAINT FK_people_addresses_people_id FOREIGN KEY (people_id) REFERENCES dbo.people (people_id)
	,ordinal_type_code_id TINYINT NOT NULL CONSTRAINT FK_people_addresses_ordinal_type_codes FOREIGN KEY (ordinal_type_code_id) REFERENCES codes.ordinal_type_codes (ordinal_type_code_id)
	,address_location_code_id TINYINT NOT NULL CONSTRAINT FK_people_addresses_address_location_codes FOREIGN KEY (address_location_code_id) REFERENCES codes.address_location_codes (address_location_code_id)
	,street_number VARCHAR(25) NULL
	,street_prefix_code_id INTEGER NULL
	,street_name varchar(250) NULL
	,street_type_code_id INTEGER NULL
	,suffix_street_prefix_code_id INTEGER NULL
	,apt_number varchar(30) NULL
	,city_code_id INTEGER NULL
	,county_code_id INTEGER NULL
	,state_code_id INTEGER NULL
	,country_code_id INTEGER NULL
	,zip_code VARCHAR(25) NULL	
	,po_box VARCHAR(25) NULL
	,active_flag BIT NOT NULL CONSTRAINT DF_people_addresses_active_flag DEFAULT (1)
	,create_user int NOT NULL CONSTRAINT DF_people_gis_addresses_create_user  DEFAULT ((1))
	,create_dttm datetime NOT NULL CONSTRAINT DF_people_gis_addresses_create_dttm  DEFAULT (getdate())
	,update_user int NOT NULL CONSTRAINT DF_people_gis_addresses_update_user  DEFAULT ((1))
	,update_dttm datetime NOT NULL CONSTRAINT DF_people_gis_addresses_update_dttm  DEFAULT (getdate())	
	,CONSTRAINT PK_people_gis_address PRIMARY KEY NONCLUSTERED (people_address_id ASC)
)