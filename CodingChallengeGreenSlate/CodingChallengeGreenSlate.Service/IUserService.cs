using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Business
{
    public interface IUserService : IEntityService<User>
    {
        User GetUserById(int userId);
    }
}
