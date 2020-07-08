Imports System.Configuration
Imports System.Data.SqlClient

Public Class ConexionDA
    Public NotInheritable Class ConexionBD
        Public Shared Function GetConexion() As SqlConnection
            Try
                Dim vlCadenaConexion As String = String.Empty

                vlCadenaConexion = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString()

                Dim coo As New SqlConnection(vlCadenaConexion)
                coo.Open()
                Return coo
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Class
