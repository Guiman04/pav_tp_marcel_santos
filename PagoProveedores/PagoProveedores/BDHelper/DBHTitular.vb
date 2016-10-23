﻿Imports System.Data.SqlClient
Imports PagoProveedores.QB
Public Class DBHTitular

    Public Shared Function getTitulares() As DataTable
        Dim p As New QB.QueryBuilder
        p.table("Titulares").seleccionar({"id_titular Id", "@(nombre + ' ' + apellido) as Nombre", "cuit Cuit"})
        Return DBConn.executeSQL(p.build)
    End Function

    Public Shared Function modifyTitular(id_titular As Integer, nombre As String, apellido As String, cuit As Long, calle As String, altura As Integer) As Boolean
        Dim q As New QB.QueryBuilder
        'Verifico si el Cuit es -1 o un cuit valido.
        Dim c As String
        If cuit = -1 Then
            c = "@null"
        Else
            c = cuit
        End If

        'Otra vez. El where tiene que ir con @ el nombre del campo.
        'Cree la variable c arriba para ingresar null cunado me pasan -1... usar esa variable no cuit
        q.table("Titulares").update({
                                    {"apellido", apellido},
                                    {"nombre", nombre},
                                    {"cuit", c},
                                    {"calle", calle},
                                    {"altura", altura}
                                }).
                            where("@id_titular", id_titular)
        Return DBConn.executeOnlySQL(q.build)
    End Function


    Public Shared Function addTitular(nombre As String, apellido As String, cuit As Long, calle As String, altura As Integer) As Boolean
        Dim q As New QB.QueryBuilder

        'Verifico si el Cuit es -1 o un cuit valido.
        Dim c As String
        If cuit = -1 Then
            c = "@null"
        Else
            c = cuit
        End If
        q.table("Titulares").insert({
                                    {"nombre", nombre},
                                    {"apellido", apellido},
                                    {"cuit", c},
                                    {"calle", calle},
                                    {"altura", altura}
                                })
        Return DBConn.executeOnlySQL(q.build)
    End Function

    Public Shared Function getCuentas(id_titular As Integer)
        Dim q As New QB.QueryBuilder
        q.table("Cuentas").seleccionar({"nro_cuenta", "cbu"}).join("Bancos", "nro_banco", {"nombre Banco"}).where("@id_titular", id_titular)
        Return DBConn.executeSQL(q.build)
    End Function

    Public Shared Function getTitular(id_titular As Integer) As Titular
        Dim t As Titular
        Dim c As Cuenta
        Dim ban As Banco

        Dim q As New QB.QueryBuilder
        'Corrijo Tabla Titulares no Titular
        'Corrijo, Si en el where alguno de ambos lados es una exprecion va con @
        q.table("Titulares").seleccionar.where("@id_titular", id_titular)
        Dim b As DataTable = DBConn.executeSQL(q.build)

        'Metes el valor del nombre en la variable cuit
        Dim apellido As String = b.Rows(0).Item("apellido"),
            nombre As String = DBUtils.ifNULLEmpty(b.Rows(0).Item("nombre")),
            cuit As Long = DBUtils.ifNULLCero(b.Rows(0).Item("cuit")),
            calle As String = DBUtils.ifNULLEmpty(b.Rows(0).Item("calle")),
            altura As Integer = DBUtils.ifNULLCero(b.Rows(0).Item("altura"))


        'Esto provoca un NullPointerException porque nunca se hace un New Titular.
        t = New Titular With {
            .id_titular = id_titular,
            .apellido = apellido,
            .nombre = nombre,
            .calle = calle,
            .altura = altura,
            .cuit = cuit
        }

        q = New QB.QueryBuilder
        'La tabla se llama Cuentas no Cuenta. En el where como es el nombre de un campo va con @
        q.table("Cuentas").seleccionar.join("Bancos", "nro_banco").where("@id_titular", id_titular)

        b = New DataTable
        b = DBConn.executeSQL(q.build)

        For Each Cuenta As DataRow In b.Rows

            Dim nro_cuenta As String = Cuenta.Item("nro_cuenta"),
                nro_banco As Integer = Cuenta.Item("nro_banco"),
                nom_banco As String = Cuenta.Item("nombre"),
                sucursal As Integer = DBUtils.ifNULLCero(Cuenta.Item("sucursal")),
                cbu As String = DBUtils.ifNULLEmpty(Cuenta.Item("cbu"))

            c = New Cuenta
            ban = New Banco
            'c.id_titular = id_titular
            ban.id = nro_banco
            ban.nombre = nom_banco
            c.Banco = ban
            c.NroCuenta = nro_cuenta
            c.Sucursal = sucursal
            c.CBU = cbu
            t.cuentas.Add(c)


        Next
        Return t

    End Function

    Public Shared Function addCuenta(id_titular As Integer, nro_banco As Integer, sucursarl As Integer, nro_cuenta As String, cbu As String) As Boolean
        Dim c As String
        If cbu = -1 Then
            c = "@null"
        Else
            c = cbu
        End If
        Dim q As New QB.QueryBuilder
        q.table("Cuentas").insert({{"id_titular", id_titular},
                                  {"nro_banco", nro_banco},
                                  {"nro_cuenta", nro_cuenta},
                                  {"cbu", c},
                                  {"sucursal", sucursarl}})

        Return DBConn.executeOnlySQL(q.build)
    End Function
    Public Shared Function deleteCuenta(nro_cuenta As String, nro_banco As String) As Boolean
        Dim q As New QueryBuilder
        q.table("Cuentas").update({{"deleted_at", "@GETDATE()"}}) _
            .where("@nro_cuenta", nro_cuenta) _
            .where("@nro_banco", nro_banco)

        Return DBConn.executeOnlySQL(q.build)
    End Function

End Class
