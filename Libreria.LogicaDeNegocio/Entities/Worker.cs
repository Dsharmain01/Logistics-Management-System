using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Vo;

public class Worker : Employee
{
    protected Worker() { }
    public Worker(
        int id,
        Name name,
        LastName lastName,
        Email email,
        Password password)
        : base(id, name, lastName, email, password)
    {
   }
}