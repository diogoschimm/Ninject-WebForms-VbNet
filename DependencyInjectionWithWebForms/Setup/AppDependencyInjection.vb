Imports Ninject

Public Class AppDependencyInjection

    Public Shared Sub RegisterServices(ByVal kernel As IKernel)

        '/// repositorios
        kernel.Bind(Of IClienteRepository)().To(Of ClienteRepository)().InTransientScope()

        '/// Services
        kernel.Bind(Of IClienteService)().To(Of ClienteService)().InTransientScope()
        kernel.Bind(Of IProdutoService)().To(Of ProdutoService)().InTransientScope()

    End Sub

End Class
