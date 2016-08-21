Public Class Order
	Public Property id As Integer
	Public Property Customer As Customer
	Public Property ShipedDate As Date
	Public Property OrderDate As Date
	Public Property RequestedDate As Date

	<Runtime.Serialization.IgnoreDataMember, Newtonsoft.Json.JsonIgnore>
	Public Property Details As New HashSet(Of OrderLine)

	'TODO: Make sure all SAHeader have a sales item added
End Class
