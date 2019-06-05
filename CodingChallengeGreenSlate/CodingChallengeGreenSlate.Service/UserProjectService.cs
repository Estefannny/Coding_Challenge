using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository;
using CodingChallengeGreenSlate.Repository.Common;
using CodingChallengeGreenSlate.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Service
{
    public class UserProjectService : EntityService<UserProject>, IUserProjectService
    {
        IUnitOfWork _unitOfWork;
        IUserProjectRepository _userProjectRepository;

        public UserProjectService(IUnitOfWork unitOfWork, IUserProjectRepository userProjectRepository)
            : base(unitOfWork, userProjectRepository)
        {
            _unitOfWork = unitOfWork;
            _userProjectRepository = userProjectRepository;
        }

        public IEnumerable<UserProject> GetProjectsByUserId(int? userId)
        {
            return _userProjectRepository.GetProjectsByUserId(userId);
        }
    }
}
