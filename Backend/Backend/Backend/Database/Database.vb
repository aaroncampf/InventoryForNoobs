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

	''' <summary>Represents the an inventory</summary>
	Public Overridable Property MasterInventory() As DbSet(Of MasterInventoryItem)

	''' <summary>Represents All transactions made to items in the inventory</summary>
	Public Overridable Property Transactions() As DbSet(Of Transaction)

End Class