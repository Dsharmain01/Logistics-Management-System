
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.LogicaNegocio.Entities;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaAplicacion.Mapper
{
    internal class MapperUser
    {

        public static User FromDto(UserDto userDto)
        {
            return new Worker(
                            0,
                            new Name(userDto.Name),
                            new LastName(userDto.LastName),
                            new Email(userDto.Email),
                            new Password(userDto.Password)
                             );
        }


        public static DtoListedUser ToDto(User user)
        {
            return new DtoListedUser(user.Id,
                                     user.Name.Value,
                                     user.LastName.Value,
                                     user.Email.Value,
                                     user.Password.Value,
                                     user.GetType().Name);

        }

        public static IEnumerable<DtoListedUser> ToListaDto(IEnumerable<User> users)
        {
            List<DtoListedUser> dtoListedUsers = new List<DtoListedUser>();
            foreach (var item in users)
            {
                dtoListedUsers.Add(new DtoListedUser(item.Id,
                                                             item.Name.Value,
                                                             item.LastName.Value,
                                                             item.Email.Value,
                                                             item.Password.Value,
                                                             item.GetType().Name));
            }
            return dtoListedUsers;
        }

    }
}
