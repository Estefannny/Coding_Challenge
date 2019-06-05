using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Service.Common;
using System.Collections.Generic;


namespace CodingChallengeGreenSlate.Service
{
    public interface IUserProjectService : IEntityService<UserProject>
    {
        IEnumerable<UserProject> GetProjectsByUserId(int? userId);
    }
}
