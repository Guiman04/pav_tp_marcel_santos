﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCheque
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgv_cheque_consulta = New System.Windows.Forms.DataGridView()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgv_cheque_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_cheque_consulta
        '
        Me.dgv_cheque_consulta.AllowUserToAddRows = False
        Me.dgv_cheque_consulta.AllowUserToDeleteRows = False
        Me.dgv_cheque_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_cheque_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_cheque_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_cheque_consulta.Location = New System.Drawing.Point(13, 47)
        Me.dgv_cheque_consulta.Name = "dgv_cheque_consulta"
        Me.dgv_cheque_consulta.ReadOnly = True
        Me.dgv_cheque_consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_cheque_consulta.ShowEditingIcon = False
        Me.dgv_cheque_consulta.Size = New System.Drawing.Size(635, 325)
        Me.dgv_cheque_consulta.TabIndex = 0
        '
        'btn_cerrar
        '
        Me.btn_cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar.Location = New System.Drawing.Point(573, 378)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(75, 24)
        Me.btn_cerrar.TabIndex = 1
        Me.btn_cerrar.Text = "Cerrar"
        Me.btn_cerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 35)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Consulta de Cheques"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmConsultaCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 414)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.dgv_cheque_consulta)
        Me.Name = "frmConsultaCheque"
        Me.Text = "Consulta de Cheques"
        CType(Me.dgv_cheque_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_cheque_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
