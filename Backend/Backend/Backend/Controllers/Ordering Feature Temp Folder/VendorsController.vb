Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports Backend
Imports Newtonsoft.Json.Linq

Namespace Controllers
	Public Class VendorsController
		Inherits System.Web.Http.ApiController

		Private db As New Database

		' GET: api/Vendors
		Function GetVendors() As IQueryable(Of Vendor)
			Return db.Vendors
		End Function

		' GET: api/Vendors/5
		<ResponseType(GetType(Vendor))>
		Function GetVendor(ByVal id As Integer) As IHttpActionResult
			Dim vendor As Vendor = db.Vendors.Find(id)
			If IsNothing(vendor) Then
				Return NotFound()
			End If

			Return Ok(vendor)
		End Function

		' PUT: api/Vendors/5
		<ResponseType(GetType(Void))>
		Function PutVendor(ByVal id As Integer, ByVal vendor As JObject) As IHttpActionResult
			Dim Frack As Vendor = vendor.ToObject(Of Vendor)

			If Not ModelState.IsValid Then
				Return BadRequest(ModelState)
			End If

			If Not id = Frack.id Then
				Return BadRequest()
			End If

			db.Entry(Frack).State = EntityState.Modified

			Try
				db.SaveChanges()
			Catch ex As DbUpdateConcurrencyException
				If Not (VendorExists(id)) Then
					Return NotFound()
				Else
					Throw
				End If
			End Try

			Return StatusCode(HttpStatusCode.NoContent)
		End Function

		' POST: api/Vendors
		<ResponseType(GetType(Vendor))>
		Function PostVendor(ByVal vendor As JObject) As IHttpActionResult
			Dim Frack As Vendor = vendor.ToObject(Of Vendor)

			If Not ModelState.IsValid Then
				Return BadRequest(ModelState)
			End If

			db.Vendors.Add(Frack)
			db.SaveChanges()

			Return CreatedAtRoute("DefaultApi", New With {.id = Frack.id}, Frack)
		End Function

		' DELETE: api/Vendors/5
		<ResponseType(GetType(Vendor))>
		Function DeleteVendor(ByVal id As Integer) As IHttpActionResult
			Dim vendor As Vendor = db.Vendors.Find(id)
			If IsNothing(vendor) Then
				Return NotFound()
			End If

			db.Vendors.Remove(vendor)
			db.SaveChanges()

			Return Ok(vendor)
		End Function

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If (disposing) Then
				db.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Function VendorExists(ByVal id As Integer) As Boolean
			Return db.Vendors.Count(Function(e) e.id = id) > 0
		End Function
	End Class
End Namespace