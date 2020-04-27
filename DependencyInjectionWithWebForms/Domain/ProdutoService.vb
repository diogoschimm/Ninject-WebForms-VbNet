Public Class ProdutoService
    Implements IProdutoService

    Public Function ObterProdutos() As IList(Of Produto) Implements IProdutoService.ObterProdutos
        Dim lista As New List(Of Produto)

        lista.Add(New Produto(1, "Camiseta ShowMe Code"))
        lista.Add(New Produto(2, "Camiseta Code +"))
        lista.Add(New Produto(3, "Caneca Code CS"))

        Return lista
    End Function
End Class
