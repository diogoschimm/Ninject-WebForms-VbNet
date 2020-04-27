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

