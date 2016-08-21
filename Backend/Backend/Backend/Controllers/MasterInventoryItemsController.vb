Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Description
Imports Newtonsoft.Json.Linq

Namespace Controllers
	Public Class MasterInventoryItemsController
		Inherits ApiController

		Private db As New Database

		''' <summary>returns all inventory items</summary>
		Function GetMasterInventory() As IQueryable(Of MasterInventoryItem)
			Return db.MasterInventory
		End Function

		''' <summary>
		''' returns a single MasterInventoryItem (GET: api/MasterInventoryItems/5)
		''' </summary>
		''' <param name="id">The ID of the item you want</param>
		''' <returns></returns>
		<ResponseType(GetType(MasterInventoryItem))>
		Function GetMasterInventoryItem(ByVal id As Integer) As IHttpActionResult
			Dim masterInventoryItem As MasterInventoryItem = db.MasterInventory.Find(id)
			If IsNothing(masterInventoryItem) Then
				Return NotFound()
			End If

			Return Ok(masterInventoryItem)
		End Function

		''' <summary>
		''' Updates a MasterInventoryItem (PUT: api/MasterInventoryItems/5)
		''' </summary>
		''' <param name="id">The ID of the item you are updating</param>
		''' <param name="masterInventoryItem">An object representing a MasterInventoryItem with all the values you want</param>
		''' <returns></returns>
		''' <remarks>
		''' 
		''' </remarks>
		<ResponseType(GetType(Void))>
		Function PutMasterInventoryItem(ByVal id As Integer, ByVal masterInventoryItem As JObject) As IHttpActionResult
			Dim Frack As MasterInventoryItem = masterInventoryItem.ToObject(Of MasterInventoryItem)

			If Not ModelState.IsValid Then
				Return BadRequest(ModelState)
			End If

			If Not id = Frack.id Then
				Return BadRequest()
			End If

			Dim Prop = db.Entry(Frack).Property(NameOf(Frack.Qty))
			If Prop.IsModified Then
				Dim Change As Integer
				If Val(Prop.OriginalValue) > Val(Prop.CurrentValue) Then
					Change = -(Val(Prop.OriginalValue) - Val(Prop.CurrentValue))
				Else
					Change = (Val(Prop.OriginalValue) - Val(Prop.CurrentValue))
				End If

				'Dim Transaction As New Transaction With {.Amount = Math.Abs(Prop.OriginalValue) - Math.Abs(Prop.CurrentValue), .Date = Date.Now, .InventoryItem = masterInventoryItem}
				Dim Transaction As New Transaction With {.Amount = Val(Prop.OriginalValue) - Val(Prop.CurrentValue), .Date = Date.Now, .InventoryItem = Frack}
				db.Transactions.Add(Transaction)
			End If

			db.Entry(masterInventoryItem).State = EntityState.Modified

			Try
				db.SaveChanges()
			Catch ex As DbUpdateConcurrencyException
				If Not (MasterInventoryItemExists(id)) Then
					Return NotFound()
				Else
					Throw
				End If
			End Try

			Return StatusCode(HttpStatusCode.NoContent)
		End Function

		''' <summary>
		''' Updates a MasterInventoryItem (PUT: api/MasterInventoryItems)
		''' </summary>
		''' <param name="masterInventoryItem">An object representing a MasterInventoryItem with all the values you want</param>
		''' <returns></returns>
		<ResponseType(GetType(MasterInventoryItem))>
		Function PostMasterInventoryItem(<FromBody> ByVal masterInventoryItem As JObject) As IHttpActionResult
			'Function PostMasterInventoryItem(<FromBody> ByVal masterInventoryItem As MasterInventoryItem) As IHttpActionResult
			Dim Test As MasterInventoryItem = masterInventoryItem.ToObject(Of MasterInventoryItem)


			If Not ModelState.IsValid Then
				Return BadRequest(ModelState)
			End If

			db.MasterInventory.Add(Test)
			db.SaveChanges()

			Return CreatedAtRoute("DefaultApi", New With {.id = Test.id}, Test)
		End Function

		''' <summary>
		''' Deleted an MasterInventoryItem (DELETE: api/MasterInventoryItems/5)
		''' </summary>
		''' <param name="id">The ID of the item you want to delete</param>
		''' <returns></returns>
		<ResponseType(GetType(MasterInventoryItem))>
		Function DeleteMasterInventoryItem(ByVal id As Integer) As IHttpActionResult
			Dim masterInventoryItem As MasterInventoryItem = db.MasterInventory.Where(Function(x) x.id = id).Include(Function(x) x.Transactions).FirstOrDefault
			If IsNothing(masterInventoryItem) Then
				Return NotFound()
			End If


			'TODO: Add in Cascade Delete for reals
			'TODO: Add in Cascade Delete for reals
			db.MasterInventory.Remove(masterInventoryItem)

			For Each Item In masterInventoryItem.Transactions
				db.Transactions.Remove(Item)
			Next
			'TODO: Add in Cascade Delete for reals
			'TODO: Add in Cascade Delete for reals

			db.SaveChanges()

			Return Ok(masterInventoryItem)
		End Function

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If (disposing) Then
				db.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Function MasterInventoryItemExists(ByVal id As Integer) As Boolean
			Return db.MasterInventory.Count(Function(e) e.id = id) > 0
		End Function

	End Class
End Namespace