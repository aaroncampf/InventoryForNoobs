Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
	Public Sub Register(ByVal config As HttpConfiguration)
		' Change for produciton -rex
		' http://www.infragistics.com/community/blogs/dhananjay_kumar/archive/2015/08/31/how-to-enable-cors-in-the-asp-net-web-api.aspx
		Dim Cors = New Http.Cors.EnableCorsAttribute("http://localhost:5901" "*", "*")
		config.EnableCors(Cors)


		' Web API configuration and services

		' Web API routes
		config.MapHttpAttributeRoutes()


		config.Routes.MapHttpRoute(
			name:="DefaultApi",
			routeTemplate:="api/{controller}/{id}",
			defaults:=New With {.id = RouteParameter.Optional}
		)
	End Sub
End Module
