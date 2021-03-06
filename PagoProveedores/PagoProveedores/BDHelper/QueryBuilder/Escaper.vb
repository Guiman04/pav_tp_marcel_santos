﻿Imports System
Imports System.Globalization
Public Class Escaper
    Private Sub New()
    End Sub

    Private Shared culture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
    Public Shared Function getIFormatProvider() As IFormatProvider
        Return culture
    End Function
    

    ''' <summary>
    ''' Escapa el caracter '
    ''' </summary>
    ''' <param name="asdf">Les'Parfum</param>
    ''' <returns>Les''Parfum</returns>
    ''' <remarks></remarks>
    Public Shared Function escape(asdf)
        Return asdf.Replace("'", "''")
    End Function

    ''' <summary>
    ''' Escapa y cierra el valor.
    ''' Deberia traducir el valor al adecuado para ser enviado.
    ''' String: Entre comillas 
    ''' Integer: Solo
    ''' Date: Formateada, entre comillas.
    ''' Para Ingresar campos usar el @ primero
    ''' NOTHING, @null => null
    ''' </summary>
    ''' <param name="asdf"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function escapeAndClose(asdf As Object) As String
        If isEspecialNull(asdf) Then Return "null"

        Dim d As Date
        If Date.TryParse(asdf, d) Then
            Dim r As String = "'" & d.ToString("yyyy-MM-dd HH:MM:ss") & "'"
            Return r
        End If
        If IsNumeric(asdf) Then
            Return numToString(asdf)
        Else
            If isEspecial(asdf) Then
                Return getEspecial(asdf)
            End If
            Return "'" & escape(asdf) & "'"
        End If

    End Function

    Private Shared Function isEspecialNull(asdf As Object) As Boolean
        If asdf Is Nothing Then Return True
        If asdf = "" Then Return True
        If isEspecial(asdf) And getEspecial(asdf) = "null" Then Return True
        Return False
    End Function

    Public Shared Function escapeAddTable(asdf As String, table As String) As String
        If isEspecial(asdf) Then Return getEspecial(asdf) 'asdf = getEspecial(asdf)
        Return table & "." & escape(asdf)
    End Function

    Private Shared Function isEspecial(asdf As String) As Boolean
        Return asdf(0) = "@"
    End Function
    Private Shared Function getEspecial(asdf As String) As String
        Return asdf.Substring(1)
    End Function

    Private Shared Function numToString(asdf As Decimal) As String

        Return asdf.ToString(culture)
    End Function
End Class
