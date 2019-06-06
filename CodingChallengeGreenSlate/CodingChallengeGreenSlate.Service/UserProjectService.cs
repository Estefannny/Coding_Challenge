using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Data;
using CodingChallengeGreenSlate.Data.Common;
using CodingChallengeGreenSlate.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Business
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
