using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Service
{
    public interface IUserProjectService : IEntityService<UserProject>
    {
        IEnumerable<UserProject> GetProjectsByUserId(int? userId);
    }
}
