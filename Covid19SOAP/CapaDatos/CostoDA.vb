Imports System.Data.SqlClient
Imports CapaModelo
Public Class CostoDA
    Public Function ConsultarCostoPorTrabajador(ByVal mandante As String, ByVal sociedadId As String, ByVal centroCostoId As String) As String
        Dim costoAnt As String
        Using cn As SqlConnection = ConexionDA.ConexionBD.GetConexion()

            Dim cmd As New SqlCommand("SEGSS_COSTO_TRABAJADOR", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter With {.Value = mandante, .DbType = DbType.String, .ParameterName = "@VI_CH_MANDT", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = sociedadId, .DbType = DbType.String, .ParameterName = "@VI_CH_SOCIEDADID", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = centroCostoId, .DbType = DbType.String, .ParameterName = "@VI_CH_CENTROID", .Direction = ParameterDirection.Input})

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read
                costoAnt = dr.GetValue(dr.GetOrdinal("CentroCostoAnt"))
            End While

        End Using
        Return costoAnt
    End Function
End Class
