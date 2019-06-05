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
    public class UserService : EntityService<User>, IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
            : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }


        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}
