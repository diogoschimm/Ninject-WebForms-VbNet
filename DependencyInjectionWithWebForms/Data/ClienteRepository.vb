Public Class ClienteRepository
    Implements IClienteRepository

    Public Function Add(c As Cliente) As Cliente Implements IClienteRepository.Add
        Return c
    End Function

    Public Function Update(c As Cliente) As Cliente Implements IClienteRepository.Update
        Return c
    End Function

    Public Function Delete(c As Cliente) As Boolean Implements IClienteRepository.Delete
        Return True
    End Function

End Class
