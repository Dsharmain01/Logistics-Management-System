using System.Runtime.Serialization;

namespace Libreria.Infraestructura.AccesoDatos.Excepciones;
public class BadRequestException : InfrastructuraException
{
    public BadRequestException()
    {
    }

    public BadRequestException(string? message) : base(message)
    {
    }

    protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override int StatusCode()
    {
        return 400;
    }
}
