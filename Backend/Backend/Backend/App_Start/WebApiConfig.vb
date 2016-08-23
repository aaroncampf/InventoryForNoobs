Imports System.Web.Http

Public Module WebApiConfig
	Public Sub Register(ByVal config As HttpConfiguration)
		Dim Cors = New Http.Cors.EnableCorsAttribute("*", "*", "*")
		config.EnableCors(Cors)
		'config.EnableCors()


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
