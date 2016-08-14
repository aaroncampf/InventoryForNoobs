''' <summary>Represents a transaction made with an inventory item</summary>
Public Class Transaction
	''' <summary>The key value of the table</summary>
	Public Property id As Integer
	''' <summary>The Date of the transaction</summary>
	Public Property [Date] As Date
	''' <summary>How many items where transfered</summary>
	Public Property Amount As Integer
	''' <summary>The item that the transaction was for</summary>
	Public Property InventoryItem As MasterInventoryItem
End Class
