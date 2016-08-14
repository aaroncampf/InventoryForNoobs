Imports System
Imports System.Data.Entity
Imports System.Linq

Public Class Database
	Inherits DbContext

	' Your context has been configured to use a 'Database' connection string from your application's 
	' configuration file (App.config or Web.config). By default, this connection string targets the 
	' 'Backend.Database' database on your LocalDb instance. 
	' 
	' If you wish to target a different database and/or database provider, modify the 'Database' 
	' connection string in the application configuration file.
	Public Sub New()
		MyBase.New("name=Database")
	End Sub

	' Add a DbSet for each entity type that you want to include in your model. For more information 
	' on configuring and using a Code First model, see http:'go.microsoft.com/fwlink/?LinkId=390109.
	' Public Overridable Property MyEntities() As DbSet(Of MyEntity)

End Class

'Public Class MyEntity
'    Public Property Id() As Int32
'    Public Property Name() As String
'End Class
