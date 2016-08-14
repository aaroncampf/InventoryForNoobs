Public Class HomeController
	Inherits Controller

	Function Index() As ActionResult
		ViewData("Title") = "Home Page"

		Return View()
	End Function


	''' <summary>
	''' Seeds the database with default data after deleting it
	''' </summary>
	''' <returns></returns>
	Function Seed() As ActionResult
		Dim db As New Database
		db.Database.Delete()
		db.Database.Create()

		Dim Item1 As New MasterInventoryItem With {.Name = "Soap", .Location = "1", .Qty = 0}

		db.MasterInventory.AddRange({
			New MasterInventoryItem With {.Name = "#4 BIO BOX KRAFT FTB4N  ", .Location = "1", .Qty = 0},
			New MasterInventoryItem With {.Name = "4304 C-FOLD WHITE TOWEL", .Location = "2", .Qty = 0},
			New MasterInventoryItem With {.Name = "40X48 NATURAL 16MIC  45 GAL HIGH DENSITY", .Location = "3", .Qty = 0},
			New MasterInventoryItem With {.Name = "D826E 2PLY  DISP NAPKIN", .Location = "4", .Qty = 0},
			New MasterInventoryItem With {.Name = "#1 GROCERY BAGS", .Location = "5", .Qty = 0},
			New MasterInventoryItem With {.Name = "#2 GROCERY BAGS", .Location = "6", .Qty = 0},
			New MasterInventoryItem With {.Name = "#4 GROCERY BAGS", .Location = "7", .Qty = 0},
			New MasterInventoryItem With {.Name = "#8 GROCERY BAGS", .Location = "8", .Qty = 0},
			New MasterInventoryItem With {.Name = "9818K 18 FLAT BLACK TRAY", .Location = "9", .Qty = 0},
			New MasterInventoryItem With {.Name = "#425 GROCERY BAGS ", .Location = "10", .Qty = 0},
			New MasterInventoryItem With {.Name = "FULL SIZE STEAM TABLE PAN LID ", .Location = "11", .Qty = 0},
			New MasterInventoryItem With {.Name = "PP-FC-LID 8oz LIDS", .Location = "12", .Qty = 0},
			New MasterInventoryItem With {.Name = "#8 PB8 (450008)  FRENCH FRY BAG", .Location = "13", .Qty = 0},
			New MasterInventoryItem With {.Name = "#4 BIO PLUS EARTH 7.75X5.5X3.5", .Location = "14", .Qty = 0},
			New MasterInventoryItem With {.Name = "30IN 30# KRAFT 1625'", .Location = "15", .Qty = 0},
			New MasterInventoryItem With {.Name = "*0521 #250 FOOD TRAY ECO KRAFT", .Location = "16", .Qty = 0},
			New MasterInventoryItem With {.Name = "#500  FOOD TRAY 5LB HEARTHSTONE", .Location = "17", .Qty = 0},
			New MasterInventoryItem With {.Name = "#250  FOOD TRAY  2.5LB HEARTHSTONE", .Location = "18", .Qty = 0},
			New MasterInventoryItem With {.Name = "C-K516W 16oz WHITE HOT CUP", .Location = "19", .Qty = 0}
		})

		db.SaveChanges()

		Dim GetAmount = Function() As Integer
							Dim RNumber As New Random()
							Dim IsNegitive As New Random()
							If IsNegitive.Next(1, 2) = 1 Then
								Return RNumber.Next(1, 20)
							Else
								Return RNumber.Next(1, 20) * -1
							End If
						End Function

		Dim GetDate = Function() As Date
						  Dim RNumber As New Random()
						  Dim IsNegitive As New Random()
						  If IsNegitive.Next(1, 2) = 1 Then
							  Return Date.Today.AddDays(RNumber.Next(1, 30))
						  Else
							  Return Date.Today.AddDays(RNumber.Next(1, 30) * -1)
						  End If
					  End Function

		For Each Item In db.MasterInventory
			Item.Transactions.UnionWith({
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()},
				New Transaction With {.Date = GetDate(), .Amount = GetAmount()}
			})
		Next


		db.SaveChanges()

		Return RedirectToActionPermanent(NameOf(Index))
	End Function

End Class
