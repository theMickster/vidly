-- <Migration ID="363eef72-02d5-4e30-8acb-4ee94ac8755f" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.07.21
** CREATION:     Create primary key on people email table
**************************************************************************/
ALTER TABLE dbo.people_email_addresses ADD CONSTRAINT PK_people_email_addresses PRIMARY KEY CLUSTERED (people_email_id);