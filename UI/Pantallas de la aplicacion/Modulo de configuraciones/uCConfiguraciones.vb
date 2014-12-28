Public Class uCConfiguraciones

    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill

        gridListaDatos.Rows.Add("Servidor base de datos:", "localhost")
        gridListaDatos.Rows.Add("Usuario base de datos:", "root")
        gridListaDatos.Rows.Add("Contraseña base de datos:", "root")
        gridListaDatos.Rows.Add("Puerto base de datos:", "495")

        gridListaDatos.Rows.Add("Servidor SMTP:", "smtp.gmail.com")
        gridListaDatos.Rows.Add("Seguridad SMTP:", "SSL")
        gridListaDatos.Rows.Add("Puerto SMTP:", "465")

        gridListaDatos.Rows.Add("Período académico:", "2")
        gridListaDatos.Rows.Add("Costo matrícula:", "50000")

        gridListaDatos.Rows.Add("Mínimo salarial (Becas socio-económica):", "125000")
        gridListaDatos.Rows.Add("Máximo salarial (Becas socio-económica):", "350000")

        gridListaDatos.Rows.Add("Zona horaria:", "America/Costa_Rica")

    End Sub

End Class
