Public Interface IClienteRepository

    Function Add(c As Cliente) As Cliente
    Function Update(c As Cliente) As Cliente
    Function Delete(c As Cliente) As Boolean

End Interface
