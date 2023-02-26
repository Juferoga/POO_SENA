Imports System.Data.SqlClient
Public Class Form1
    'DATOS DE CONEXION A SQL SERVER
    Dim con As New SqlConnection("SERVER =192.168.1.15;uid=prueba;password=123456;database=ARTICULOS_DB")
    Dim da As SqlDataAdapter
    Dim sSql As String = ""
    Dim sExtencion As String
    Private Sub cmdSeleccionarImagen_Click(sender As Object, e As EventArgs) Handles cmdSeleccionarImagen.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'SELECCIONAMOS LA IMAGEN QUE QUEREMOS GUARDAR EN LA DB
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Cargamos la imagen en el PictureBox como .BackgroundImage solo para poder ajustar la imagen,
        'pero de igual manera la podemos cargar como .Image.
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            Dim openFileDialog1 As New OpenFileDialog()
            Dim dialogo As New DialogResult
            openFileDialog1.Filter = "Imagen (JPG,BMP,PNG)|*.JPG;*.BMP;*.PNG|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 1
            openFileDialog1.RestoreDirectory = True
            dialogo = openFileDialog1.ShowDialog()
            If (dialogo = DialogResult.OK) Then
                Dim bmp As New Bitmap(Image.FromFile(openFileDialog1.FileName))
                bmp = bmp.GetThumbnailImage(480, 480, Nothing, IntPtr.Zero) 'Redimencionamos pixeles deimagen (Opcional).
                PictureBox1.BackgroundImage = Nothing
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch 'Ajustamos la imagen a todo el picturebox.
                PictureBox1.BackgroundImage = bmp 'Cargamos la imagen al PictureBox.
                'sExtencion = System.IO.Path.GetExtension(openFileDialog1.FileName) 'Obtenemos la Extencion de la imagen cargada.
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdRegistrar_Click(sender As Object, e As EventArgs) Handles cmdRegistrar.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'GUARDAMOS LA IMAGEN EN LA BASE DE DATOS
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            Dim ms As New System.IO.MemoryStream() 'Creamos el MemoryStream.
            PictureBox1.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) 'Salvamos el imagen que tenomos cargada en el PictureBox en el MemoryStream.
            sSql = "INSERT INTO TBL_IMAGEN VALUES (@IMAGEN)" 'Creamos el Query.
            con.Close() 'Cerramos la conexion por si esta abierta.
            con.Open() 'Abrimos la Coenxion de la base de datos.
            Dim cmd As New SqlCommand(sSql, con) 'Creamos el comando.
            cmd.Parameters.Add(New SqlParameter("@IMAGEN", ms.GetBuffer())) 'Agregamos el MemoryStream a los parametros para poderlos guardar en la base de datos.
            cmd.ExecuteNonQuery() 'ejecutamos el query.
            con.Close()
            cmd = Nothing
            ms.Dispose()
            ms.Close()
            MsgBox("La imagen ha sido registrada", MsgBoxStyle.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdRecuperar_Click(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'OBTENEMOS LA IMAGEN EN LA BASE DE DATOS Y LA CARGAMOS EL PICTUREBOX
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim dt As New DataTable
        sSql = "SELECT  *FROM TBL_IMAGEN WHERE ID = " & "'" & Val(txtId.Text) & "'"
        da = New SqlDataAdapter(sSql, con)
        con.Close() 'Cerramos la conexion por si esta abierta.
        con.Open()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Dim ms As New System.IO.MemoryStream() 'Creamos el MemoryStream y poder cargar la imagen.
            Dim imageBuffer() As Byte = CType(dt.Rows(0).Item("IMAGEN"), Byte()) 'Conbertimos la imagen cargada en el datatable a Bytes.
            ms = New System.IO.MemoryStream(imageBuffer) 'Cargamos el MemoryStream con la imagen ya convertida en Bytes.
            PictureBox1.BackgroundImage = Nothing 'Si existe una imagen cargada en el PictureBox la borramos.
            PictureBox1.BackgroundImage = (Image.FromStream(ms)) 'Cargamos la imagen al PictureBox, Nota: Lo hacemos como .BackgroundImage pero igual lo podemos hacer como .Image.
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch 'Ajustamos la imagen al todo el PictureBox.
            con.Close()
            dt.Clear()
            dt.Reset()
            ms.Dispose()
            ms.Close()
            sSql = ""
        End If
    End Sub
End Class
