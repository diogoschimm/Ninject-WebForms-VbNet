Public Class ClienteService
    Implements IClienteService

    Private ReadOnly _clienteRepository As IClienteRepository
    Private ReadOnly _produtoService As IProdutoService

    Public Sub New(clienteRepository As IClienteRepository, produtoService As IProdutoService)
        Me._clienteRepository = clienteRepository
        Me._produtoService = produtoService
    End Sub

    Public Function Adicionar(cliente As Cliente) As String Implements IClienteService.Adicionar

        Me._clienteRepository.Add(cliente)

        Dim str As String = ""
        For Each item As Produto In _produtoService.ObterProdutos
            str += item.NomeProduto + "; "
        Next

        Return "O Cliente foi adicionado com sucesso com os produtos " + str
    End Function

End Class
