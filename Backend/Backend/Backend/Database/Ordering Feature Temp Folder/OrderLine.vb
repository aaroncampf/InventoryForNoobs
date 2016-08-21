Public Class OrderLine
	Public Property id As Integer
	Public Property Price As Decimal
	Public Property Qty_Requested As Integer
	Public Property Qty_Shpped As Integer
	Public Property Item As MasterInventoryItem
	Public Property Header As Order
End Class
