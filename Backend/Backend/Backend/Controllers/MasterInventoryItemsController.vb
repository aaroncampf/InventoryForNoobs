Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Description

Namespace Controllers
    Public Class MasterInventoryItemsController
		Inherits ApiController

		Private db As New Database

        ' GET: api/MasterInventoryItems
        Function GetMasterInventory() As IQueryable(Of MasterInventoryItem)
            Return db.MasterInventory
        End Function

        ' GET: api/MasterInventoryItems/5
        <ResponseType(GetType(MasterInventoryItem))>
        Function GetMasterInventoryItem(ByVal id As Integer) As IHttpActionResult
            Dim masterInventoryItem As MasterInventoryItem = db.MasterInventory.Find(id)
            If IsNothing(masterInventoryItem) Then
                Return NotFound()
            End If

            Return Ok(masterInventoryItem)
        End Function

		' PUT: api/MasterInventoryItems/5
		<ResponseType(GetType(Void))>
		Function PutMasterInventoryItem(ByVal id As Integer, ByVal masterInventoryItem As MasterInventoryItem) As IHttpActionResult
			If Not ModelState.IsValid Then
				Return BadRequest(ModelState)
			End If

			If Not id = masterInventoryItem.id Then
				Return BadRequest()
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

		' POST: api/MasterInventoryItems
		<ResponseType(GetType(MasterInventoryItem))>
        Function PostMasterInventoryItem(ByVal masterInventoryItem As MasterInventoryItem) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.MasterInventory.Add(masterInventoryItem)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = masterInventoryItem.id}, masterInventoryItem)
        End Function

        ' DELETE: api/MasterInventoryItems/5
        <ResponseType(GetType(MasterInventoryItem))>
        Function DeleteMasterInventoryItem(ByVal id As Integer) As IHttpActionResult
            Dim masterInventoryItem As MasterInventoryItem = db.MasterInventory.Find(id)
            If IsNothing(masterInventoryItem) Then
                Return NotFound()
            End If

            db.MasterInventory.Remove(masterInventoryItem)
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