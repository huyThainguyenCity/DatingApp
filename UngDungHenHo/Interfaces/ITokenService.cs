using UngDungHenHo.Entities;

namespace UngDungHenHo.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
