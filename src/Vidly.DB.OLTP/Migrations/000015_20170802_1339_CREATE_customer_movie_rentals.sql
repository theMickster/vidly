-- <Migration ID="b41d5dc3-220a-48ed-94f0-3cf453fe676e" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.02
** CREATION:     Create customer movie rentals table.
**************************************************************************/
CREATE TABLE dbo.customer_movie_rentals
(
	customer_movie_rental_id INTEGER IDENTITY(1,1) NOT NULL
	,customer_id INTEGER NOT NULL
	,movie_inventory_id INTEGER NOT NULL
	,checkout_date DATE NOT NULL
	,due_date DATE NOT NULL
	,return_date DATE NULL
	,create_user INTEGER NOT NULL CONSTRAINT DF_customer_movie_rentals_create_user DEFAULT(1)
	,create_date DATETIME NOT NULL CONSTRAINT DF_customer_movie_rentals_create_dttm DEFAULT(GETDATE())
	,update_user INTEGER NOT NULL CONSTRAINT DF_customer_movie_rentals_update_user DEFAULT(1)
	,update_date DATETIME NOT NULL CONSTRAINT DF_customer_movie_rentals_update_dttm DEFAULT(GETDATE())	
	,CONSTRAINT PK_customer_movie_rentals PRIMARY KEY NONCLUSTERED (customer_movie_rental_id ASC)
	,CONSTRAINT UK_customer_movie_rentals UNIQUE CLUSTERED (customer_id ASC, customer_movie_rental_id ASC) WITH FILLFACTOR= 90
	,CONSTRAINT FK_movie_inventory_customer_movie_rentals FOREIGN KEY (movie_inventory_id) REFERENCES dbo.movie_inventory (movie_inventory_id)
)