using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Data;
using CodingChallengeGreenSlate.Data.Common;
using CodingChallengeGreenSlate.Business.Common;


namespace CodingChallengeGreenSlate.Business
{
    public class ProjectService : EntityService<Project>, IProjectService
    {
        IUnitOfWork _unitOfWork;
        IProjectRepository _projectRepository;

        public ProjectService(IUnitOfWork unitOfWork, IProjectRepository projectRepository)
            : base(unitOfWork, projectRepository)
        {
            _unitOfWork = unitOfWork;
            _projectRepository = projectRepository;
        }

        public Project GetProjectById(int projectId)
        {
            return _projectRepository.GetProjectById(projectId);
        }
    }
}
