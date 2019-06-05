using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository;
using CodingChallengeGreenSlate.Repository.Common;
using CodingChallengeGreenSlate.Service.Common;


namespace CodingChallengeGreenSlate.Service
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
