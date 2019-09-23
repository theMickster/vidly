-- <Migration ID="b4dff568-87a9-47c4-ae03-f15f43c06dd1" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.22
** CREATION:     Create basic customer table.
**************************************************************************/
CREATE TABLE codes.data_type_codes
(
	data_type_code_id TINYINT IDENTITY(1,1) NOT NULL,
	data_type_name VARCHAR(20) NOT NULL,
    CONSTRAINT PK_data_type_codes PRIMARY KEY CLUSTERED (data_type_code_id ASC)
)

EXECUTE sys.sp_addextendedproperty @name='MS_Description', @value='The table to store a list of the data types used to map attributes in the EAV models.' , @level0type='SCHEMA',@level0name='codes', @level1type='TABLE',@level1name='data_type_codes';

SET IDENTITY_INSERT codes.data_type_codes ON; 
INSERT INTO codes.data_type_codes(data_type_code_id, data_type_name)
VALUES (1, 'BIT'), (2, 'VARCHAR'), (3,'DATETIME'), (4,'DECIMAL'), (5,'INTEGER')
SET IDENTITY_INSERT codes.data_type_codes OFF; 

CREATE TABLE codes.attributes
(
	attribute_id INTEGER IDENTITY(1,1) NOT NULL
	,attribute_name VARCHAR(100) NOT NULL
	,attribute_description VARCHAR(255) NOT NULL
	,data_type_code_id TINYINT NOT NULL CONSTRAINT FK_attribute_data_type_code_id FOREIGN KEY (data_type_code_id) REFERENCES codes.data_type_codes (data_type_code_id)
	,create_user INTEGER NOT NULL CONSTRAINT DF_attribute_create_user DEFAULT(1)
	,create_dttm DATETIME NOT NULL CONSTRAINT DF_attribute_create_dttm DEFAULT(GETDATE())
    ,CONSTRAINT PK_attribute PRIMARY KEY CLUSTERED (attribute_id ASC)
)

EXECUTE sys.sp_addextendedproperty @name='MS_Description', @value='The collection attributes that can be used to describe an entity' , @level0type='SCHEMA',@level0name='codes', @level1type='TABLE',@level1name='attributes';
