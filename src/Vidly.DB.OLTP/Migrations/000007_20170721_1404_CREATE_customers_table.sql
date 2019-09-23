-- <Migration ID="0eac1d97-0e3f-44c6-bece-ee70f4478430" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.21
** CREATION:     Create basic customer table.
**************************************************************************/
CREATE TABLE dbo.customers
(
	id INTEGER IDENTITY(1,1)
	,first_name VARCHAR(50) NOT NULL
	,last_name VARCHAR(50) NOT NULL
	,dob DATE NULL
	,email_address VARCHAR(50)  NOT NULL
	,CONSTRAINT PK_Customers PRIMARY KEY CLUSTERED (id)
)