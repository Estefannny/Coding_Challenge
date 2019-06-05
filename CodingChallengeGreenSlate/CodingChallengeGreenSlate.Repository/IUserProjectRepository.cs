using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository.Common;
using System.Collections.Generic;


namespace CodingChallengeGreenSlate.Repository
{
    public interface IUserProjectRepository : IGenericRepository<UserProject>
    {
        IEnumerable<UserProject> GetProjectsByUserId(int? userId);
    }
}
