Imports System.Data.SqlClient
Imports CapaModelo

Public Class UsuarioDA

    Public Shared Function ConsultarListaSociedadUsuario(ByVal idMandante As String, Optional ByVal idSociedad As String = "") As List(Of Sociedad)
        Using cn As SqlConnection = ConexionDA.ConexionBD.GetConexion()

            Dim sociedades As List(Of Sociedad) = New List(Of Sociedad)()
            Dim sociedad As Sociedad
            Dim cmd As New SqlCommand("ERPSS_DIRECTORIO_SOCIEDAD", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter With {.Value = idMandante, .DbType = DbType.String, .ParameterName = "@VI_CH_MANDT", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = idSociedad, .DbType = DbType.String, .ParameterName = "@VI_CH_SOCIEDAD", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = "", .DbType = DbType.String, .ParameterName = "@VI_VC_DESCRIPCION", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = "", .DbType = DbType.String, .ParameterName = "@VI_VC_DIRECCION", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = "", .DbType = DbType.String, .ParameterName = "@VI_CH_RUC", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = "", .DbType = DbType.String, .ParameterName = "@VI_CH_CORP", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = "", .DbType = DbType.String, .ParameterName = "@VI_CH_CIA", .Direction = ParameterDirection.Input})


            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While (dr.Read)
                sociedad = New Sociedad()
                sociedad.SociedadId = dr.GetValue(dr.GetOrdinal("SociedadId"))
                sociedad.Descripcion = dr.GetValue(dr.GetOrdinal("Descripcion"))
                sociedad.Corporacion = dr.GetValue(dr.GetOrdinal("CORP"))
                sociedad.Compania = dr.GetValue(dr.GetOrdinal("CIA"))

                sociedades.Add(sociedad)
            End While


            Return sociedades
        End Using
    End Function

    Public Shared Function ConsultarDatosTrabajadorSociedad(ByVal sociedad As String, ByVal codigo As String) As List(Of Usuario)
        Using cn As SqlConnection = ConexionDA.ConexionBD.GetConexion()

            Dim usuarios As List(Of Usuario) = New List(Of Usuario)()
            Dim usuario As Usuario
            Dim cmd As New SqlCommand("SEGSS_DATOS_TRABAJADORSOC", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter With {.Value = sociedad, .DbType = DbType.String, .ParameterName = "@VI_SOCIEDAD", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = codigo, .DbType = DbType.String, .ParameterName = "@VI_CODIGO", .Direction = ParameterDirection.Input})



            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While (dr.Read)
                usuario = New Usuario()
                usuario.LugarComercial = dr.GetValue(dr.GetOrdinal("LugarComercial"))
                usuario.CentroCosto = dr.GetValue(dr.GetOrdinal("CentroCosto"))
                usuario.SituacionTrabajador = dr.GetValue(dr.GetOrdinal("SituacionTrabaj"))
                usuario.CodigoAutogenerado = dr.GetValue(dr.GetOrdinal("CodigoAutogener"))
                usuario.SociedadVigente = dr.GetValue(dr.GetOrdinal("SociedadVigente"))

                usuarios.Add(usuario)
            End While


            Return usuarios
        End Using
    End Function
    Public Function ConsultarOficinaXSociedad(ByVal mandante As String, ByVal sociedad As String, ByVal division As String) As String

        Using cn As SqlConnection = ConexionDA.ConexionBD.GetConexion()

            Dim cmd As New SqlCommand("SEGSS_BUSCA_OFICINA_SOCIEDAD", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prmRetorno As SqlParameter = New SqlParameter With {.Size = 500, .DbType = DbType.String, .ParameterName = "@VO_VA_RETORNO", .Direction = ParameterDirection.Output}

            cmd.Parameters.Add(New SqlParameter With {.Value = mandante, .DbType = DbType.String, .ParameterName = "@VI_VC_MANDANTE", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = sociedad, .DbType = DbType.String, .ParameterName = "@VI_VC_SOCIEDAD", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = division, .DbType = DbType.String, .ParameterName = "@VI_VC_DIVISIONP", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(prmRetorno)
            cmd.ExecuteScalar()

            Return prmRetorno.Value
        End Using



    End Function


    Public Function ConsultarListaAlmacenOficina(ByVal idCompania As String, ByVal idOficina As String) As Oficina


        Dim oficina As Oficina = New Oficina()
        Using cn As SqlConnection = ConexionDA.ConexionBD.GetConexion()

            Dim cmd As New SqlCommand("SEGSS_LISTA_OFICINAS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter With {.Value = idCompania, .DbType = DbType.String, .ParameterName = "@VI_COMPANIA", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = idOficina, .DbType = DbType.String, .ParameterName = "@VI_OFICINAID", .Direction = ParameterDirection.Input})
            cmd.Parameters.Add(New SqlParameter With {.Value = "", .DbType = DbType.String, .ParameterName = "@VI_DESCRIPCION", .Direction = ParameterDirection.Input})

            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While (dr.Read)
                oficina = New Oficina()
                oficina.Oficina = dr.GetValue(dr.GetOrdinal("OFICINAID"))
                oficina.NombreOficina = dr.GetValue(dr.GetOrdinal("DESCRIPCION"))
                oficina.Centro = dr.GetValue(dr.GetOrdinal("CENTRO"))

            End While

        End Using

        Return oficina



    End Function


End Class
