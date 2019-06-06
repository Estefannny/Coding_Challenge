using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Data.Common;


namespace CodingChallengeGreenSlate.Data
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetUserById(int userId);
    }
}
