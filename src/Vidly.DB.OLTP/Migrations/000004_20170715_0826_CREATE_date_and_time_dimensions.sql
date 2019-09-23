-- <Migration ID="03dedcb5-1af0-4c87-8e25-6a5d18fd5861" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.14
** CREATION:     Create simple date and time dimension tables.
**************************************************************************/
GO
CREATE TABLE dbo.time_dimension
(
	 time_dimension_id INTEGER IDENTITY(1,1) NOT NULL
	,time TIME(0) NOT NULL
	,hour CHAR(2) NOT NULL
	,military_hour CHAR(2) NOT NULL
	,minute CHAR(2) NOT NULL
	,second CHAR(2) NOT NULL
	,am_pm CHAR(2) NOT NULL
	,standard_time CHAR(11) NULL
	,CONSTRAINT PK_time_dimension PRIMARY KEY CLUSTERED (time_dimension_id ASC)
)
CREATE INDEX IX_time_dimension_time ON dbo.time_dimension ( time );

CREATE TABLE dbo.date_dimension
(
	 date_dimension_id INTEGER IDENTITY(1,1) NOT NULL
	,date DATE NOT NULL
	,day CHAR(2) NOT NULL
	,day_suffix VARCHAR(4) NOT NULL
	,day_of_week VARCHAR(9) NOT NULL
	,day_of_week_in_month TINYINT NOT NULL
	,day_of_year INT NOT NULL
	,week_of_year TINYINT NOT NULL
	,week_of_month TINYINT NOT NULL
	,month CHAR(2) NOT NULL
	,month_name VARCHAR(9) NOT NULL
	,quarter TINYINT NOT NULL
	,quarter_name VARCHAR(6) NOT NULL
	,year CHAR(4) NOT NULL
	,standard_date VARCHAR(10) NULL
	,holiday_text VARCHAR(50) NULL CONSTRAINT PK_date_dimension PRIMARY KEY CLUSTERED (date_dimension_id ASC)
)

CREATE INDEX IX_date_dimension_date ON dbo.date_dimension ( date );
