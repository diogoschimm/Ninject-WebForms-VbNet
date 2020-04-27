Imports Microsoft.Web.Infrastructure.DynamicModuleHelper
Imports Ninject.Web

<Assembly: WebActivatorEx.PreApplicationStartMethod(GetType(NinjectWeb), "Start")>
Module NinjectWeb

    Sub Start()
        DynamicModuleUtility.RegisterModule(GetType(NinjectHttpModule))
    End Sub

End Module
