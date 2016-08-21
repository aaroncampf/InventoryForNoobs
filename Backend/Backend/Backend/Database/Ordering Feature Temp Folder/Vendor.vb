<Serializable>
Public Class Vendor
	Public Property id As Integer
	Public Property Name As String
	Public Property Address As String
	Public Property City As String
	Public Property State As String
	Public Property Zip As String
	Public Property Phone As String
	Public Property Email As String

	<Runtime.Serialization.IgnoreDataMember, Newtonsoft.Json.JsonIgnore>
	Public Property CurrentItems As New HashSet(Of MasterInventoryItem)

	'TODO: Add a history of sales and in there, record the price of the item
	'TODO: Add a history of the times we have bought an item


End Class
