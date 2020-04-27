# Ninject-WebForms-VbNet
Usando Ninject para projetos Legados com Web.Forms no VB.NET

Package Manager Console

```
Install-Package Ninject.Web
```

Converter os arquivos NinjectWeb.cs e NinjectWebCommon.cs para Visual Basic  

### Arquivo NinjectWeb.vb

```vb
Imports Microsoft.Web.Infrastructure.DynamicModuleHelper
Imports Ninject.Web

<Assembly: WebActivatorEx.PreApplicationStartMethod(GetType(NinjectWeb), "Start")>
Module NinjectWeb

    Sub Start()
        DynamicModuleUtility.RegisterModule(GetType(NinjectHttpModule))
    End Sub

End Module
```

### Arquivo NinjectWebCommon.vb

```vb
Imports Microsoft.Web.Infrastructure.DynamicModuleHelper
Imports Ninject
Imports Ninject.Web.Common

<Assembly: WebActivatorEx.PreApplicationStartMethod(GetType(NinjectWebCommon), "Start")>
<Assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(GetType(NinjectWebCommon), "Stop")>

Module NinjectWebCommon

    Private bootstrapper As Bootstrapper = New Bootstrapper()

    Sub Start()
        DynamicModuleUtility.RegisterModule(GetType(OnePerRequestHttpModule))
        DynamicModuleUtility.RegisterModule(GetType(NinjectHttpModule))
        bootstrapper.Initialize(AddressOf CreateKernel)
    End Sub

    Sub [Stop]()
        bootstrapper.ShutDown()
    End Sub

    Private Function CreateKernel() As IKernel
        Dim kernel = New StandardKernel()

        Try
            kernel.Bind(Of Func(Of IKernel))().ToMethod(Function(ctx) Function() New Bootstrapper().Kernel)
            kernel.Bind(Of IHttpModule)().[To](Of HttpApplicationInitializationHttpModule)()
            AppDependencyInjection.RegisterServices(kernel)
            Return kernel
        Catch
            kernel.Dispose()
            Throw
        End Try
    End Function

End Module
```

Crie um arquivo AppDependencyInjection.vb onde faremos o tratamento da injeção de dependencia.  

### Arquivo AppDependencyInjection.vb

```vb
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

```

Nesse arquivo criamos o método RegisterServices que é chamado no Arquivo NinjectWebCommon.vb  
Após isso podemos utilizar em nossos arquivos WebForms, MasterPage, WebService entre outros.

### Exemplo de uso para Default.aspx.vb

Lembrar de trocar a herança para Ninject.Web.PageBase e Usar o Atributo <Inject>

```vb
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
```

### Exemplo de Código para o Serviço de Cliente

Aqui fazemos a injeção de duas interfaces que são IClienteRepository e IProdutoService

```vb
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
```



