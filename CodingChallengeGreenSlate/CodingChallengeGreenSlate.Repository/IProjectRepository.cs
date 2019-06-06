using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Data.Common;


namespace CodingChallengeGreenSlate.Data
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Project GetProjectById(int projectId);
    }
}
