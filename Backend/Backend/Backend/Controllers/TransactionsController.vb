Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports Backend

Namespace Controllers
	Public Class TransactionsController
		Inherits System.Web.Http.ApiController

		Private db As New Database

		' GET: api/Transactions
		Function GetTransactions() As IQueryable(Of Transaction)
			Return db.Transactions
		End Function

		' GET: api/Transactions/5
		<ResponseType(GetType(Transaction))>
		Function GetTransaction(ByVal id As Integer) As IHttpActionResult
			Dim transaction As Transaction = db.Transactions.Find(id)
			If IsNothing(transaction) Then
				Return NotFound()
			End If

			Return Ok(transaction)
		End Function

		' PUT: api/Transactions/5
		<ResponseType(GetType(Void))>
		Function PutTransaction(ByVal id As Integer, ByVal transaction As Transaction) As IHttpActionResult
			If Not ModelState.IsValid Then
				Return BadRequest(ModelState)
			End If

			If Not id = transaction.id Then
				Return BadRequest()
			End If

			db.Entry(transaction).State = EntityState.Modified

			Try
				db.SaveChanges()
			Catch ex As DbUpdateConcurrencyException
				If Not (TransactionExists(id)) Then
					Return NotFound()
				Else
					Throw
				End If
			End Try

			Return StatusCode(HttpStatusCode.NoContent)
		End Function

		' POST: api/Transactions
		<ResponseType(GetType(Transaction))>
		Function PostTransaction(ByVal transaction As Transaction) As IHttpActionResult
			If Not ModelState.IsValid Then
				Return BadRequest(ModelState)
			End If

			db.Transactions.Add(transaction)
			db.SaveChanges()

			Return CreatedAtRoute("DefaultApi", New With {.id = transaction.id}, transaction)
		End Function

		' DELETE: api/Transactions/5
		<ResponseType(GetType(Transaction))>
		Function DeleteTransaction(ByVal id As Integer) As IHttpActionResult
			Dim transaction As Transaction = db.Transactions.Find(id)
			If IsNothing(transaction) Then
				Return NotFound()
			End If

			db.Transactions.Remove(transaction)
			db.SaveChanges()

			Return Ok(transaction)
		End Function

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If (disposing) Then
				db.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Function TransactionExists(ByVal id As Integer) As Boolean
			Return db.Transactions.Count(Function(e) e.id = id) > 0
		End Function
	End Class
End Namespace