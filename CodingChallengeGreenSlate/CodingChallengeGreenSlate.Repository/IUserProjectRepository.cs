using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Data.Common;
using System.Collections.Generic;


namespace CodingChallengeGreenSlate.Data
{
    public interface IUserProjectRepository : IGenericRepository<UserProject>
    {
        IEnumerable<UserProject> GetProjectsByUserId(int? userId);
    }
}
