using System.Runtime.Serialization;
using Libreria.LogicaDeNegocio.Entities;

namespace Libreria.Infraestructura.AccesoDatos.Excepciones;

public abstract class InfrastructuraException : Exception
{
    string _message;
    public InfrastructuraException()
    {
    }

    public InfrastructuraException(string? message) : base(message)
    {
        _message = message;
    }

    protected InfrastructuraException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public abstract int StatusCode();

    //Para arrojar el error hacia afuera con un JSON
    public Error Error()
    {
        return new Error(
            StatusCode(),
            _message
            );

    }

}
