using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Business.Common;


namespace CodingChallengeGreenSlate.Business
{
    public interface IProjectService : IEntityService<Project>
    {
        Project GetProjectById(int projectId);
    }
}
