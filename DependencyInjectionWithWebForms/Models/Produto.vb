Public Class Produto

    Public Sub New(idProduto As Integer, nomeProduto As String)
        Me.IdProduto = idProduto
        Me.NomeProduto = nomeProduto
    End Sub

    Public Sub New()

    End Sub

    Public Property IdProduto As Integer
    Public Property NomeProduto As String

End Class
