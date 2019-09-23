-- <Migration ID="491adc2b-d447-43fd-9022-792cd9e6fca8" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.03
** CREATION:     Create installments table
**************************************************************************/
CREATE TABLE codes.installment_codes
(
	installment_id INTEGER IDENTITY(1,1) NOT NULL
	,installment_desc VARCHAR(20) NOT NULL
	,active_flag BIT NOT NULL
	,create_user INTEGER NOT NULL CONSTRAINT DF_installment_codes_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_installment_codes_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_installment_codes_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_installment_codes_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_installment_codes PRIMARY KEY NONCLUSTERED (installment_id ASC)
)