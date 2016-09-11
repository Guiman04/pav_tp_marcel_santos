﻿Public Class DBUtils
    ''' <summary>
    ''' Para comprobar si un campo esta vacio.
    ''' Devuelve String.Empty si input es System.DBNULL
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ifNULLEmpty(input As Object) As String
        If TypeOf input Is System.DBNull Then Return ""
        Return input
    End Function

    ''' <summary>
    ''' Para el QueryBuilder. Devuelve '@null' si es vacia
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ifEmptyNULL(input As String)
        If input = "" Then Return "@null"
        Return input
    End Function

    ''' <summary>
    ''' Devuelve la entrada entre ' -> 'input'.
    ''' Si la entrada es vacia devuelve NULL.
    ''' Para cuando armas el SQL directamente
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function escape(input)
        If input = "" Then Return "NULL"
        Return "'" & input & "'"
    End Function

End Class