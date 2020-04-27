Public Class Cliente

    Public Sub New(idCliente As Integer, nomeCliente As String)
        Me.IdCliente = idCliente
        Me.NomeCliente = nomeCliente
    End Sub

    Public Sub New()

    End Sub

    Public Property IdCliente As Integer
    Public Property NomeCliente As String

End Class
