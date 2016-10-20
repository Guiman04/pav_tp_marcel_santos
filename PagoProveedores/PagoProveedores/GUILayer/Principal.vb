﻿Public Class frm_principal

    Private Sub btn_proveedor_Click(sender As Object, e As EventArgs) Handles btn_proveedor.Click
        frmProveedorConsulta.Show()
    End Sub

    Private Sub btn_banco_Click(sender As Object, e As EventArgs) Handles btn_banco.Click
        frmBancoConsulta.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rs As String = "alguien sa",
            dir = "calle nro",
            cuit = 1234
        Dim t As New Telefono With {.Telefono = "125 412", .Observacion = ""}
        Dim m As New Mail With {.Mail = "asf@asdf", .Observacion = ""}
        Dim lt As New List(Of Telefono)
        lt.Add(t)
        Dim lm As New List(Of Mail)
        lm.Add(m)

        DBHProveedor.addProveedor(rs, cuit, dir, "", lt, lm)


    End Sub

    Private Sub btn_titulares_Click(sender As Object, e As EventArgs) Handles btn_titulares.Click
        Dim f As New frmTitularesConsulta
        f.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New frmNuevaFactura
        f.ShowDialog()
    End Sub


    Private Sub frm_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Mensaje para avisar que hay cambios en la base de datos.
        'Cuando actualices la Base de datos simplemente comenta esta linea
        MsgBox("Cambio importante en la estructura de la DB" & vbCrLf & _
               "Desactivar este mensaje comentando la linea")
    End Sub
End Class