using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Service.Common;


namespace CodingChallengeGreenSlate.Service
{
    public interface IProjectService : IEntityService<Project>
    {
        Project GetProjectById(int projectId);
    }
}
