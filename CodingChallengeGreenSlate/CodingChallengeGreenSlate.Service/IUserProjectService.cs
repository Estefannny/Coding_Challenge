using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Business.Common;
using System.Collections.Generic;


namespace CodingChallengeGreenSlate.Business
{
    public interface IUserProjectService : IEntityService<UserProject>
    {
        IEnumerable<UserProject> GetProjectsByUserId(int? userId);
    }
}
