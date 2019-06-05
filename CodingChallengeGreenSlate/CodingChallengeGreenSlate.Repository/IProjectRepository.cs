using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository.Common;


namespace CodingChallengeGreenSlate.Repository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Project GetProjectById(int projectId);
    }
}
