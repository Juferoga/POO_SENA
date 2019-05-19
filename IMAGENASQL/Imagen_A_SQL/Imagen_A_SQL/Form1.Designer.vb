<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.cmdSeleccionarImagen = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdRegistrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSeleccionarImagen
        '
        Me.cmdSeleccionarImagen.Location = New System.Drawing.Point(12, 12)
        Me.cmdSeleccionarImagen.Name = "cmdSeleccionarImagen"
        Me.cmdSeleccionarImagen.Size = New System.Drawing.Size(120, 33)
        Me.cmdSeleccionarImagen.TabIndex = 0
        Me.cmdSeleccionarImagen.Text = "Seleccionar Imagen..."
        Me.cmdSeleccionarImagen.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(149, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(217, 144)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'cmdRegistrar
        '
        Me.cmdRegistrar.Location = New System.Drawing.Point(11, 49)
        Me.cmdRegistrar.Name = "cmdRegistrar"
        Me.cmdRegistrar.Size = New System.Drawing.Size(121, 33)
        Me.cmdRegistrar.TabIndex = 2
        Me.cmdRegistrar.Text = "Registrar"
        Me.cmdRegistrar.UseVisualStyleBackColor = True
        '
        'cmdRecuperar
        '
        Me.cmdRecuperar.Location = New System.Drawing.Point(11, 86)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(121, 33)
        Me.cmdRecuperar.TabIndex = 4
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(11, 136)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(121, 20)
        Me.txtId.TabIndex = 5
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Id de Imagen"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 176)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Controls.Add(Me.cmdRegistrar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdSeleccionarImagen)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardar Imagen a SQL Server"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSeleccionarImagen As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cmdRegistrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label1 As Label
End Class
