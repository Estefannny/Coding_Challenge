using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository.Common;


namespace CodingChallengeGreenSlate.Repository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetUserById(int userId);
    }
}
