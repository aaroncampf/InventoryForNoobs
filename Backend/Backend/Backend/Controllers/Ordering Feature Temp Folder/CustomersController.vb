Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Description
Imports Newtonsoft.Json.Linq
Imports System.Data.Entity

Namespace Controllers
    Public Class CustomersController
        Inherits ApiController

        Private db As New Database

        ''' <summary>Gets all customers</summary>
        Function GetCustomers() As IQueryable(Of Customer)
            Return db.MasterInventory
        End Function

        ''' <summary>
        ''' Gets a single Customer (GET: api/Customers/5)
        ''' </summary>
        ''' <param name="id">The ID of the item you want</param>
        ''' <returns></returns>
        <ResponseType(GetType(Customer))>
        Function GetCustomer(ByVal id As Integer) As IHttpActionResult
            Dim Customer As Customer = db.Customers.Find(id)
            If IsNothing(Customer) Then
                Return NotFound()
            End If

            Return Ok(Customer)
        End Function

        ''' <summary>
        ''' Updates a Customer (PUT: api/Customers/5)
        ''' </summary>
        ''' <param name="id">The ID of the item you are updating</param>
        ''' <param name="Customer">An object representing a Customer with all the values you want</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' 
        ''' </remarks>
        <ResponseType(GetType(Void))>
        Function PutCustomer(ByVal id As Integer, ByVal Customer As JObject) As IHttpActionResult
            Dim Frack As Customer = Customer.ToObject(Of Customer)()

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = Frack.id Then
                Return BadRequest()
            End If

            db.Entry(Customer).State = EntityState.Modified
            db.SaveChanges()

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ''' <summary>
        ''' Updates a Customer (PUT: api/Customers)
        ''' </summary>
        ''' <param name="Customer">An object representing a Customer with all the values you want</param>
        ''' <returns></returns>
        <ResponseType(GetType(Customer))>
        Function PostCustomer(<FromBody> ByVal Customer As JObject) As IHttpActionResult
            'Function PostCustomer(<FromBody> ByVal Customer As Customer) As IHttpActionResult
            Dim Frack As Customer = Customer.ToObject(Of Customer)()


            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Customers.Add(Frack)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = Frack.id}, Frack)
        End Function

        ''' <summary>
        ''' Deleted an Customer (DELETE: api/Customers/5)
        ''' </summary>
        ''' <param name="id">The ID of the item you want to delete</param>
        ''' <returns></returns>
        <ResponseType(GetType(Customer))>
        Function DeleteCustomer(ByVal id As Integer) As IHttpActionResult
            Dim Customer As Customer = db.Customers.Where(Function(x) x.id = id).Include(Function(x) x.Orders).FirstOrDefault
            If IsNothing(Customer) Then
                Return NotFound()
            End If


            'TODO: Add in Cascade Delete for reals
            'TODO: Add in Cascade Delete for reals

            db.Customers.Remove(Customer)

            For Each Item In Customer.Orders
                db.Orders.Remove(Item)
            Next

            'TODO: Add in Cascade Delete for reals
            'TODO: Add in Cascade Delete for reals

            db.SaveChanges()

            Return Ok(Customer)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function CustomerExists(ByVal id As Integer) As Boolean
            Return db.MasterInventory.Count(Function(e) e.id = id) > 0
        End Function

    End Class
End Namespace
