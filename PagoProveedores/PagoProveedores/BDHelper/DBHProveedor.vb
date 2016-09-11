﻿Imports PagoProveedores.QB
Public Class DBHProveedor
    Public Shared Function getProveedores() As DataTable
        Dim p As New QB.QueryBuilder
        Dim campos As String() = {"id_proveedor", "razon_social", "cuit", "direccion", "observaciones", "deleted_at"}
        p.table("Proveedores").seleccionar()
        Return DBConn.executeSQL(p.build)
    End Function

    Public Shared Function addProveedor(razonSocial As String, cuit As Integer, direccion As String, observacion As String, telefonos As List(Of Telefono), mails As List(Of Mail)) As Boolean
        Dim p As New QueryBuilder

        Dim com As New List(Of String)

        p.table("Proveedores").insert({
                                      {"razon_social", razonSocial},
                                      {"cuit", cuit},
                                      {"direccion", direccion},
                                      {"observaciones", observacion}
                                  })

        com.Add(p.build)
        com.Add("DECLARE @ProvId INT = @@IDENTITY")


        For Each t As Telefono In telefonos
            p.clear.table("Proveedor_Telefonos").insert({
                                                  {"id_proveedor", "@@ProvId"},
                                                  {"telefono", t.Numero},
                                                  {"observaciones", t.Observacion}
                                              })
            com.Add(p.build)
        Next
        For Each m As Mail In mails
            p.clear.table("Proveedor_Mails").insert({
                                                {"id_proveedor", "@@ProvId"},
                                                {"mail", m.Direccion},
                                                {"observaciones", m.Observacion}
                                            })

            com.Add(p.build)
        Next

        Return DBConn.executeTransaction(com.ToArray)

    End Function

    Public Shared Function modificarProveedor(id As Integer) As Proveedor
        Dim q As New QueryBuilder
        q.table("Proveedores").seleccionar.where("@id_proveedor", id)
        Dim b As Data.DataTable = DBConn.executeSQL(q.build)

        Dim rs As String = b.Rows(0).Item("razon_social"),
            direccion As Object = DBUtils.ifNULLEmpty(b.Rows(0).Item("direccion")),
            cuit As Integer = b.Rows(0).Item("cuit"),
            observacion As String = DBUtils.ifNULLEmpty(b.Rows(0).Item("observaciones"))


        Dim mails As List(Of Mail) = getMailsProveedor(id)
        Dim telefonos As List(Of Telefono) = getTelefonosProveedor(id)


        Dim p As New Proveedor(id, telefonos, mails)
        p.RazonSocial = rs
        p.Cuit = cuit
        p.Observacion = observacion
        p.Direccion = direccion

        Return p
    End Function

    Public Shared Function agregarMailProveedor(id As Integer, mail As String, texto As String) As List(Of Mail)
        Dim q As New QueryBuilder
        q.table("Proveedor_Mails").insert({
                                          {"id_proveedor", id},
                                          {"direccion", mail},
                                          {"observaciones", texto}
                                      })
        If DBConn.executeOnlySQL(q.build) Then
            Return getMailsProveedor(id)
        End If
        Return Nothing
    End Function

    Public Shared Function agregarTelefonoProveedor(id As Integer, numero As String, texto As String) As List(Of Telefono)
        Dim q As New QueryBuilder
        q.table("Proveedor_Telefonos").insert({
                                          {"id_proveedor", id},
                                          {"numero", numero},
                                          {"observaciones", texto}
                                      })
        If DBConn.executeOnlySQL(q.build) Then
            Return getTelefonosProveedor(id)
        End If
        Return Nothing
    End Function

    Public Shared Function getMailsProveedor(id As Integer) As List(Of Mail)
        Dim q As New QueryBuilder
        q.table("Proveedor_Mails").seleccionar.where("@id_proveedor", id)
        Dim b = DBConn.executeSQL(q.build)
        Dim mails As New List(Of Mail)
        For Each r As Data.DataRow In b.Rows
            Dim m As New Mail
            m.Direccion = DBUtils.ifNULLEmpty(r.Item("mail"))
            m.Observacion = DBUtils.ifNULLEmpty(r.Item("observaciones"))
            mails.Add(m)
        Next
        Return mails
    End Function

    Private Shared Function getTelefonosProveedor(id As Integer) As List(Of Telefono)
        Dim q As New QB.QueryBuilder
        q.table("Proveedor_Telefonos").seleccionar.where("@id_proveedor", id)
        Dim b = DBConn.executeSQL(q.build)
        Dim telefonos As New List(Of Telefono)
        For Each r As Data.DataRow In b.Rows
            Dim t As New Telefono
            t.Numero = DBUtils.ifNULLEmpty(r.Item("telefono"))
            t.Observacion = DBUtils.ifNULLEmpty(r.Item("observaciones"))
            telefonos.Add(t)
        Next
        Return telefonos
    End Function

End Class