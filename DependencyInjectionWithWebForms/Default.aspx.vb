Imports Ninject

Public Class _Default
    Inherits Ninject.Web.PageBase

    <Inject>
    Public Property _clienteService As IClienteService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click

        Dim cliente As New Cliente
        cliente.IdCliente = 1
        cliente.NomeCliente = "Diogoschimm"

        Me.lit_mensagem.Text = _clienteService.Adicionar(cliente)

    End Sub

End Class