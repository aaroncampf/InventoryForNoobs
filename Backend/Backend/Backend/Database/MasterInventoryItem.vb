Imports System.ComponentModel.DataAnnotations
''' <summary>Represents a single item within the inventory</summary>
<Serializable>
Public Class MasterInventoryItem
	Implements IValidatableObject

	''' <summary>The key value of the table</summary>
	Public Property id As Integer
	''' <summary>The name of the item</summary>
	Public Property Name As String
	''' <summary>The quantity of items in stock</summary>
	Public Property Qty As Integer
	''' <summary>The location of the item</summary>
	Public Property Location As String
	''' <summary>The value of the item (think accounting)</summary>
	Public Property Value As Decimal
	''' <summary>A JSON object filled with arbitrary data (think MongoDB)</summary>
	Public Property Meta As String
	''' <summary>A list of all transactions made with this item</summary>
	Public Property Transactions As New HashSet(Of Transaction)

	Public Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
		If Qty < 0 Then
			Return {New ValidationResult("Qty is less then 0", {NameOf(Qty)})}
		End If

		Return Nothing
	End Function

	'Public Property Price As String



End Class
